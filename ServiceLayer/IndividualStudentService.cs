using DbLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
  public class IndividualStudentService
    {
        string connectionString;
        private IDbAccess _dbaccess;

        public IndividualStudentService(string inputConnectionString, IDbAccess dbaccess = null)
        {
            connectionString = inputConnectionString;
            _dbaccess = dbaccess ?? new DbAccess();
        }

        public DataTable ShowStudentByStudentCode(string studentCode)
        {
            var command = String.Format("Select FirstName, LastName,Description,GPA from Student where StudentCode = '{0}'", studentCode);
            DataTable dataTable = _dbaccess.Select(command, connectionString);
            return dataTable;
        }
        public DataTable ShowStudentCourses( string studentCode)
        {
            var command = String.Format("Select sb.CourseName, sc.Attendence, sc.Quiz, sc.HomeWork,sc.Research,sc.LabPractice,sc.FinalExam from student s left join StudentCourses sc on s.StudentId = sc.StudentId inner join Subject sb on sb.Id = sc.CourseId where s.StudentCode = '{0}'", studentCode);
            DataTable dataTable = _dbaccess.Select(command, connectionString);
            return dataTable;
        }
        public bool AdDescription(string studentCode,string description)
        {
            var command = String.Format("Update Student Set Description = '{0}' where StudentCode = '{1}'", description, studentCode);
            if (string.IsNullOrWhiteSpace(description))
            {
                return false;
            }
            else
            {
                _dbaccess.Insert(command, connectionString);
                return true;
            }

        }
    }
}
