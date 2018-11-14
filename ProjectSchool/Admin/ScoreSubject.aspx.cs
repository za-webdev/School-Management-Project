using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectSchool.Admin
{
    public partial class ScoreSubject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StudentId.Text = Session["StudentId"]?.ToString();
                CourseId.Text = Session["CourseId"]?.ToString();
            }
        }

        
    }
}