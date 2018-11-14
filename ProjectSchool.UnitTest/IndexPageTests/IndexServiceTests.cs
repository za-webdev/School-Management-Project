using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;
using DbLayer;
using Moq;
using System.Data;

namespace ProjectSchool.UnitTest.IndexPageTests
{
    [TestFixture]
    class IndexServiceTests
    {
        private int _id = 1;
        private string _firstName = "Jhon";
        private string _lastName = "Jhonny";
        private string _description = "just code";
        private string _studentCode = "jj123";
        private Mock<IDbAccess> _myDbAccess;
        private IndexService _indexService;
        
        [SetUp]
        public void Setup()
        {
            _myDbAccess = new Mock<IDbAccess>();
            _indexService = new IndexService("connectionstring", _myDbAccess.Object);
        }
      
        [Test]
        public void DoesStudentExists_LoopThroughStudentTable_IfStudentCodeFoundReturnTrue()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("StudentId", typeof(int));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("StudentCode", typeof(string));

            dataTable.Rows.Add(_id, _firstName, _lastName,_description, _studentCode);
            _myDbAccess.Setup(db => db.Select(It.IsAny<string>(), It.IsAny<string>())).Returns(dataTable);

            var result = _indexService.DoesStudentExists(_studentCode);
            Assert.IsTrue(result);
        }

        // Testing loops
        
        //[Test]
        //public void DoesStudentExist_CheckCodeWithSameCodes_StudentShouldExist()
        //{
        //    // Create your student data to check against..

        //    var service = new IndexService();

        //    var result = service.DoesStudentExists("123");

        //    Assert.IsTrue(result);
        //}

        //[Test]
        //public void DoesStudentExist_NoStudentsExistInTheDatabase_ReturnsFalse()
        //{
        //    // Nothing in the results

        //    var service = new IndexService();

        //    var result = service.DoesStudentExists("123");

        //    Assert.IsFalse(result);
        //}

        //[Test]
        //public void DoesStudentExist_100RecordsAndCodeIsFor100thRecord_ReturnsTrue()
        //{
        //    // Nothing in the results

        //    var service = new IndexService();

        //    var result = service.DoesStudentExists("123");

        //    Assert.IsFalse(result);
        //}


        [Test]
        public void DoesStudentExists_LoopThroughStudentTable_IfStudentCodeNotFoundReturnFalse()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("StudentId", typeof(int));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Description", typeof(string));
            dataTable.Columns.Add("StudentCode", typeof(string));

            dataTable.Rows.Add(_id, _firstName, _lastName, _description, _studentCode);
            _myDbAccess.Setup(db => db.Select(It.IsAny<string>(), It.IsAny<string>())).Returns(dataTable);

            var result = _indexService.DoesStudentExists("kk123");
            Assert.IsFalse(result);
        }
    }
}
