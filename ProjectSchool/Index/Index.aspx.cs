using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceLayer;
using DbLayer;



namespace ProjectSchool
{
    public partial class Index : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["StudentDataBaseConnection"].ConnectionString;
        IndexService indexService;
        public Index()
        {
             indexService = new IndexService(connectionString);
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (DropDownList.SelectedValue == "Admin")
            {
                Response.Redirect(@"\Admin\AdminPage.aspx");
            }
            else if (DropDownList.SelectedValue == "Student")
            {
                StudentCode.Visible = true;
                StudentCodeBox.Visible = true;
                SubmitBtn.Visible = true;
            }
        }
        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StudentCodeBox.Text))
            {
                StudentCode.Visible = true;
            }
            else
            {
                string studentCode = StudentCodeBox.Text;
                
                if (indexService.DoesStudentExists(studentCode))
                {
                    Session["StudentCode"] = StudentCodeBox.Text;
                    Response.Redirect(@"\Student\StudentPage.aspx");
                }
                else
                {
                    StudentCode.Visible = false;
                    ErrorLbl.Visible = true;
                    ErrorLbl.Text = "Invalid Student Code";
                }
            }

        }
    }
}

