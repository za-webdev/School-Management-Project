using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectSchool.Admin
{
    public partial class AddSchedule : System.Web.UI.Page
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["StudentDataBaseConnection"].ConnectionString;
        StudentService studentService;

        public AddSchedule()
        {
            studentService = new StudentService(connectionString);
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentNameLabel.Text = Session["StudentName"]?.ToString();
                StudentGrid.DataSource = GetStudentInfo();
                StudentGrid.DataBind();
            }
        }
        public DataTable GetStudentInfo()
        {
            var studentId = Convert.ToInt32(Session["StudentId"]);
            var data = studentService.ShowStudentInfo(studentId);
            return data;

        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            var studentId = Convert.ToInt32(Session["StudentId"]);

            List<string> listOfSubjects = new List<string>();
            foreach (ListItem listItem in ListBoxSubjects.Items)
            {
                if (listItem.Selected)
                {
                    listOfSubjects.Add(listItem.Value);

                }
            }
            studentService.InsertListOfSubjects(listOfSubjects,studentId);
            StudentGrid.DataSource = GetStudentInfo();
            StudentGrid.DataBind();
        }
       
        protected void StudentGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
            int RowIndex = row.RowIndex;
            
            if (e.CommandName == "score")
            {
                Session["CourseId"] = StudentGrid.DataKeys[RowIndex].Values[0];
                SubjectLbl.Text = StudentGrid.DataKeys[RowIndex].Values[1].ToString()+" Score:";
                SubjectLbl.Visible = true;
                scorediv.Visible = true;
            }
        }
        protected void Submit_Score(object sender, EventArgs e)
        {
            var courseId = Convert.ToInt32(Session["CourseId"]);
            var studentId = Convert.ToInt32(Session["StudentId"]);
            string attendence = Attendence.Text;
            string Quiz = quiz.Text;
            string homeWork = HomeWork.Text;
            string research = Reasearch.Text;
            string labPractice = LabPractice.Text;
            string finalExam = FinalExam.Text;

            studentService.SubmitScore(courseId,studentId,attendence,Quiz,homeWork,research,labPractice,finalExam);
            StudentGrid.DataSource = GetStudentInfo();
            StudentGrid.DataBind();
            SubjectLbl.Visible = false;
            scorediv.Visible = false;
            Attendence.Text = "0";
            quiz.Text = "0";
            HomeWork.Text = "0";
            Reasearch.Text = "0";
            LabPractice.Text = "0";
            FinalExam.Text = "0";

        }

        protected void Cal_GPA(object sender, EventArgs e)
        {
            var studentId = Convert.ToInt32(Session["StudentId"]);
            var GPA =studentService.CalculateGPA(studentId);
            var str = String.Format("{0:F1}",GPA);
            GPALbl.Visible = true;
            GPALbl.Text = "GPA : "+str;
        }
    }
}


