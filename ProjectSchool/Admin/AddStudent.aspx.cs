using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceLayer;


namespace ProjectSchool.Admin
{
    public partial class AddStudent : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["StudentDataBaseConnection"].ConnectionString;
        AddStudentService addStudentService;
        public AddStudent()
        {
            addStudentService= new AddStudentService(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        { 
            if(addStudentService.AddNewStudent(FName.Text, Lname.Text, SCode.Text))
            {
                Response.Redirect(@"\Admin\AdminPage.aspx");
            }
            else
            {
                ErrorLbl.Visible = true;
                ErrorLbl.Text = "Fields with (*) are required";
            }

        }
    }
}