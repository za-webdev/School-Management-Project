using DbLayer;
using Moq;
using NUnit.Framework;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSchool.UnitTest.IndividualStudent.Tests
{
	[TestFixture]
    class IndividaulStudentServiceTests
    {
        private Mock<IDbAccess> _myDbAccess;
        private IndividualStudentService _studentService;
        private string _connectionString = "connectionstring";
        string studentCode = "Code123";
        string description = "student description";


        [SetUp]
        public void Setup()
        {
            _myDbAccess = new Mock<IDbAccess>();
            _studentService = new IndividualStudentService(_connectionString, _myDbAccess.Object);
        }
        [Test]
        public void ShowStudentByStudentCode_WhenCalled_VerifyTheRightCommandBeingCalled()
        {
            var command = String.Format("Select FirstName, LastName,Description,GPA from Student where StudentCode = '{0}'", studentCode);
            _studentService.ShowStudentByStudentCode(studentCode);
            _myDbAccess.Verify(db => db.Select(command, _connectionString), Times.Once);
        }

        [Test]
        public void ShowStudentCourses_WhenCalled_VerifyTheRightCommandBeingCalled()
        {
            var command = String.Format("Select sb.CourseName, sc.Attendence, sc.Quiz, sc.HomeWork,sc.Research,sc.LabPractice,sc.FinalExam from student s left join StudentCourses sc on s.StudentId = sc.StudentId inner join Subject sb on sb.Id = sc.CourseId where s.StudentCode = '{0}'", studentCode);
            _studentService.ShowStudentCourses(studentCode);
            _myDbAccess.Verify(db => db.Select(command, _connectionString), Times.Once);
        }
        [Test]
        public void AddDescription_WhenCalled_VarifyTheRightCommandBeingCalled()
        {
            var command = String.Format("Update Student Set Description = '{0}' where StudentCode = '{1}'", description, studentCode);
            _studentService.AdDescription(studentCode,description);
            _myDbAccess.Verify(db => db.Insert(command, _connectionString), Times.Once);
        }
        [Test]
        public void AddDescription_IfDescriptionIsValid_ReturnsTrue()
        {
            var result = _studentService.AdDescription(studentCode,description);
            Assert.IsTrue(result);
        }
        [Test]
        public void AddDescription_IfDescriptionIsEmptyOrWhiteSpace_ReturnsTrue()
        {
            string description = " ";
            var result = _studentService.AdDescription(studentCode, description);
            Assert.IsFalse(result);
        }
    }
}
