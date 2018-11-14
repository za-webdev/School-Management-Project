using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceLayer;

namespace ProjectSchool
{
    public partial class AdminPage : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["StudentDataBaseConnection"].ConnectionString;
        StudentService studentService;

        public AdminPage()
        {
            studentService = new StudentService(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentGrid.DataSource = ShowListOfStudents();
                StudentGrid.DataBind();
            }
        }
      
        public DataTable ShowListOfStudents()
        {
            var data =studentService.ShowAllStudents();
            return data;
        }

        protected void StudentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            if (e.CommandName == "delete")
            {
                var StudentId = StudentGrid.DataKeys[RowIndex].Value;
                studentService.DeleteStudent(StudentId);
                e.Handled = true;
                StudentGrid.DataSource = ShowListOfStudents();
                StudentGrid.DataBind();
            }

            else if(e.CommandName == "schedule")
            {
                Session["StudentId"] = StudentGrid.DataKeys[RowIndex].Values[0];
                Session["StudentName"] = StudentGrid.DataKeys[RowIndex].Values[1];
                Response.Redirect(@"\Admin\AddSchedule.aspx");
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect(@"\Admin\AddStudent.aspx");
        }


    }
}
