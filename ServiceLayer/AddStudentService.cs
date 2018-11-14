using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer;

namespace ServiceLayer
{
    public class AddStudentService
    {
        string connectionString;
        private IDbAccess _dbaccess;

        public AddStudentService(string inputConnectionString, IDbAccess dbaccess = null)
        {
            connectionString = inputConnectionString;
            _dbaccess = dbaccess ?? new DbAccess();
        }

        public bool AddNewStudent(string fName, string lName, string sCode)
        {

            var command = String.Format("Insert into student (FirstName , LastName, StudentCode) Values('{0}','{1}','{2}')", fName, lName, sCode);
            if (string.IsNullOrWhiteSpace(fName) || string.IsNullOrWhiteSpace(lName) || string.IsNullOrWhiteSpace(sCode))
            {
                return false;
            }

            else{
                _dbaccess.Insert(command, connectionString);
                return true;
            }
        }

    }
}
