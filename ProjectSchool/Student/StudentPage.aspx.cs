using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;
using ServiceLayer;


namespace ProjectSchool
{
    public partial class StudentPage : System.Web.UI.Page
    {
        public string studentCode;
        string connectionString = WebConfigurationManager.ConnectionStrings["StudentDataBaseConnection"].ConnectionString;

        IndividualStudentService studentService;
        public StudentPage()
        {
            studentService = new IndividualStudentService(connectionString);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                myGrid.DataSource = GetStudentByStudentCode();
                courseGrid.DataSource = GetStudentByStudentCourses();
                myGrid.DataBind();
                courseGrid.DataBind();
                //StudentCodeLable.Text = myGrid.DataKeyNames.GetValue(myGrid[0]);
                
            }
        }
        public DataTable GetStudentByStudentCode()
        {
            var studentCode = Convert.ToString(Session["StudentCode"]);
            var data = studentService.ShowStudentByStudentCode(studentCode);
            return data;
        }
        public DataTable GetStudentByStudentCourses()
        {

            var studentCode = Convert.ToString(Session["StudentCode"]);
            var data = studentService.ShowStudentCourses(studentCode);
            return data;
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            var studentCode = Convert.ToString(Session["StudentCode"]);
            string description = DescriptionBox.Text;
            if (studentService.AdDescription(studentCode,description))
            {
                myGrid.DataSource = GetStudentByStudentCode();
                myGrid.DataBind();
                DescriptionBox.Text = null;
            }
            else
            {
                Response.Redirect(@"\Student\StudentPage.aspx");

            }
            
        }
    }
}
