using DbLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
   public class StudentService
    {
        string connectionString;
        private IDbAccess _dbaccess;

        public StudentService(string inputConnectionString, IDbAccess dbaccess = null)
        {
            connectionString = inputConnectionString;
            _dbaccess = dbaccess ?? new DbAccess();
        }

        public DataTable ShowAllStudents()
        {
            var command = "Select * from Student";
            DataTable dataTable = _dbaccess.Select(command, connectionString);
            return dataTable;
        }

        public void DeleteStudent(Object StudentId)
        {
            var command = String.Format("DELETE FROM Student WHERE StudentId = {0}", StudentId);
            _dbaccess.Delete(command, connectionString);
        }

        public DataTable ShowStudentInfo(int studentId)
        {
            var command = String.Format("Select CourseId, CourseName, Attendence, Quiz, HomeWork,Research,LabPractice,FinalExam, Total from student s left join StudentCourses sc on s.StudentId = sc.StudentId inner join Subject sb on sb.Id = sc.CourseId where s.StudentId = {0}", studentId);
            return _dbaccess.Select(command, connectionString);
        }

        public void InsertListOfSubjects(List<string> listOfSubjects,int studentId)
        {
            StringBuilder stringbuild = new StringBuilder(string.Empty);
            foreach (string item in listOfSubjects)
            {

                stringbuild.Append($"Insert into [StudentCourses] (CourseId,StudentId) Values ({item},{studentId});");

            }
            var command = stringbuild.ToString();
            _dbaccess.Insert(command, connectionString);
        }

        public void SubmitScore(int courseId,int studentId ,string attendence,string quiz, string homeWork,string research,string labPractice ,string finalExam)
        {
            int total = Convert.ToInt32(attendence) + Convert.ToInt32(quiz) + Convert.ToInt32(homeWork) + Convert.ToInt32(research) + Convert.ToInt32(labPractice) + Convert.ToInt32(finalExam);
            var command = String.Format("Update StudentCourses Set Attendence = {0},Quiz= {1},HomeWork={2},Research={3},LabPractice={4},FinalExam={5},Total={6} Where CourseId = {7} AND StudentId = {8}", attendence, quiz, homeWork, research, labPractice, finalExam, total, courseId, studentId);
            _dbaccess.Insert(command, connectionString);
        }

        public Double CalculateGPA(int studentId)
        {
            var commandForSum = String.Format("SELECT SUM(Total) FROM StudentCourses where StudentId = {0}",studentId);

            var commandForCountOfSubjects = String.Format("SELECT count(*) FROM StudentCourses where StudentId = {0} GROUP by StudentId", studentId);

            var sum = _dbaccess.SumOfTotal(commandForSum, connectionString);
            var countOfSubjects = _dbaccess.CountOfSubjects(commandForCountOfSubjects,connectionString);

            var total = sum / countOfSubjects;
            Double GPA = (total - 50) / 10;
            if (GPA < 0)
            {
                GPA = 0;
            }
            else if (GPA > 5)
            {
                GPA = 5;
            }

            var GPACommand = String.Format("Update Student set GPA = {0} where StudentId = {1}", GPA, studentId);
             _dbaccess.UpdateGPA(GPACommand, connectionString);
            return GPA;
        }
    }
}
