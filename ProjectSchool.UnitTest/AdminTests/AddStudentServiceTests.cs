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
    class AddStudentServiceTests
    {
        private Mock<IDbAccess> _myDbAccess;
        private AddStudentService _addStudentService;
       
        private string _connectionString = "connectionstring";
        string fName = "jhony";
        string  lName = "jhon";
        string sCode = "jj123";
      
        [SetUp]
        public void Setup()
        {
            _myDbAccess = new Mock<IDbAccess>();
            _addStudentService = new AddStudentService(_connectionString, _myDbAccess.Object);
        }
        [Test]
        public void AddNewStudent_WhenCalled_VerifyTheCommandStringBeingCalled()
        {

            var command = String.Format("Insert into student (FirstName , LastName, StudentCode) Values('{0}','{1}','{2}')", fName, lName, sCode);
            var result = _addStudentService.AddNewStudent(fName, lName, sCode);
            _myDbAccess.Verify(db => db.Insert(command, _connectionString), Times.Once);
        }

        [Test]
        public void AddNewStudent_InsertDataIntoStudentTable_IfNoErrorsWithDataReturnTrue()
        {
            
            var result = _addStudentService.AddNewStudent(fName, lName, sCode);
            Assert.IsTrue(result);
        }

        [Test]
        public void AddNewStudent_InsertDataIntoStudentTable_IfErrorsWithDataReturnFalse()
        {
            
            var result = _addStudentService.AddNewStudent("", lName, "");
            Assert.IsFalse(result);
        }

    }
}
