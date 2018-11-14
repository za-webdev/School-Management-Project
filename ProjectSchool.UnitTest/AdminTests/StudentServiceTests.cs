using DbLayer;
using Moq;
using NUnit.Framework;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSchool.UnitTest.AdminTests
{
    [TestFixture]
    class StudentServiceTests
    {
        private Mock<IDbAccess> _myDbAccess;
        private StudentService _studentService;
        private string _connectionString = "connectionstring";
        int studentId = 1;
        int courseId = 2;

        [SetUp]
        public void Setup()
        {
            _myDbAccess = new Mock<IDbAccess>();
            _studentService = new StudentService(_connectionString, _myDbAccess.Object);
        }
        [Test]
        public void ShowAllStuents_WhenCalled_VerifyTheRightCommandBeingCalled()
        {
            var command = "Select * from Student";
            _studentService.ShowAllStudents();
            _myDbAccess.Verify(db => db.Select(command, _connectionString), Times.Once);

        }
        [Test]
        public void ShowAllStuents_WhenCalled_ReturnsDataTable()
        {
            var command = "Select * from Student";
            var dataTable = new DataTable();
            _myDbAccess.Setup(db => db.Select(command, _connectionString)).Returns(dataTable);
            var runMethod = _studentService.ShowAllStudents();
            Assert.IsInstanceOf<DataTable>(runMethod);

        }
        [Test]
        public void DeleteStudent_WhenCalled_VerifyTheDeleteCommandBeingCalled()
        {
            var command = String.Format("DELETE FROM Student WHERE StudentId = {0}", studentId);
            _studentService.DeleteStudent(studentId);
            _myDbAccess.Verify(db => db.Delete(command, _connectionString), Times.Once);

        }
        [Test]
        public void ShowStuentInfo_WhenCalled_VerifyTheCommandBeingCalledReturnsDataTable()
        {
            var command = String.Format("Select CourseId, CourseName, Attendence, Quiz, HomeWork,Research,LabPractice,FinalExam, Total from student s left join StudentCourses sc on s.StudentId = sc.StudentId inner join Subject sb on sb.Id = sc.CourseId where s.StudentId = {0}", studentId);
            var runMethod = _studentService.ShowStudentInfo(studentId);
            _myDbAccess.Verify(db => db.Select(command, _connectionString), Times.Once);

        }

        [Test]
        public void InsertListOfSubjects_WhenCalled_VerifyTheRightCommandBeingCalled()
        {
            List<string> listOfSubjects = new List<string>();
            listOfSubjects.Add("math");
            listOfSubjects.Add("bio");
            listOfSubjects.Add("chem");
            _studentService.InsertListOfSubjects(listOfSubjects, studentId);
            _myDbAccess.Verify(db => db.Insert(It.IsAny<string>(), _connectionString), Times.Once);
        }

        [Test]
        public void SumbitScore_WhenCalled_VerifyTheCommandBeingCalled()
        {
            int total = 90;
            string attendence = "10";
            string Quiz = "10";
            string homeWork = "20";
            string research = "0";
            string labPractice = "0";
            string finalExam = "50";
            var command = String.Format("Update StudentCourses Set Attendence = {0},Quiz= {1},HomeWork={2},Research={3},LabPractice={4},FinalExam={5},Total={6} Where CourseId = {7} AND StudentId = {8}", attendence, Quiz, homeWork, research, labPractice, finalExam, total, courseId, studentId);
            _studentService.SubmitScore(courseId, studentId, attendence, Quiz, homeWork, research, labPractice, finalExam);
            _myDbAccess.Verify(db => db.Insert(command, _connectionString), Times.Once);



        }
        [Test]
        public void CalculateGPA_WhenCalled_VerifyCommandForSumBeingCalled()
        {
            var commandForSum = String.Format("SELECT SUM(Total) FROM StudentCourses where StudentId = {0}", studentId);
            _studentService.CalculateGPA(studentId);
            _myDbAccess.Verify(db => db.SumOfTotal(commandForSum, _connectionString), Times.Once);

        }
        [Test]
        public void CalculateGPA_WhenCalled_VerifyCommandForCountOfSubjectsBeingCalled()
        {
            var commandForCountOfSubjects = String.Format("SELECT count(*) FROM StudentCourses where StudentId = {0} GROUP by StudentId", studentId);
            _studentService.CalculateGPA(studentId);
            _myDbAccess.Verify(db => db.CountOfSubjects(commandForCountOfSubjects, _connectionString), Times.Once);
        }
        [Test]
        public void CalculateGPA_WhenCalled_VerifyCommandForGPABeingCalled()
        {
            _myDbAccess.Setup(db => db.SumOfTotal(It.IsAny<string>(), It.IsAny<string>())).Returns(350.0);
            _myDbAccess.Setup(db => db.CountOfSubjects(It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            Double GPA = 3.75;
            var GPACommand = String.Format("Update Student set GPA = {0} where StudentId = {1}", GPA, studentId);
            _studentService.CalculateGPA(studentId);
            _myDbAccess.Verify(db => db.UpdateGPA(GPACommand, _connectionString), Times.Once);
        }
        [Test]
        public void CalculateGPA_IfGPAIsGreaterThan5_Returns5()
        {
            _myDbAccess.Setup(db => db.SumOfTotal(It.IsAny<string>(), It.IsAny<string>())).Returns(500.0);
            _myDbAccess.Setup(db => db.CountOfSubjects(It.IsAny<string>(), It.IsAny<string>())).Returns(4);

            Double GPA = 7.5;
            var GPACommand = String.Format("Update Student set GPA = {0} where StudentId = {1}", GPA, studentId);
            var result = _studentService.CalculateGPA(studentId);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void CalculateGPA_IfGPAIsLessThanZero_ReturnsZer0()
        {
            _myDbAccess.Setup(db => db.SumOfTotal(It.IsAny<string>(), It.IsAny<string>())).Returns(200.0);
            _myDbAccess.Setup(db => db.CountOfSubjects(It.IsAny<string>(), It.IsAny<string>())).Returns(5);

            Double GPA = -1;
            var GPACommand = String.Format("Update Student set GPA = {0} where StudentId = {1}", GPA, studentId);
            var result = _studentService.CalculateGPA(studentId);
            Assert.AreEqual(0, result);
        }

    }



}
