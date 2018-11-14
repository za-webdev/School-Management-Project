using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer;
namespace ServiceLayer
{
    public class IndexService
    {
        string connectionString;
        private IDbAccess _dbaccess;
        public IndexService(string inputConnectionString ,IDbAccess dbaccess = null)
        {
            connectionString = inputConnectionString;
            _dbaccess = dbaccess ?? new DbAccess();
        }
        public bool DoesStudentExists(string studentCode)
        {
            var command = String.Format("Select * From student where code=" + studentCode);
            DataTable dataTable = _dbaccess.Select(command, connectionString);
            for (var i = 0; i < dataTable.Rows.Count; i++)
            { 
                if (IsStudentCodeFound(dataTable.Rows[i][4].ToString(), studentCode))
                    return true;
            }
            return false;
        }

        // udemy
        // UDEMY
        // uDeMy
        // 
        // ''
        public bool IsStudentCodeFound(string firstCode, string secondCode)
        {
            var studenCodesMatch = false;
            
            if (!string.IsNullOrEmpty(secondCode) && !string.IsNullOrEmpty(firstCode) && 
                firstCode.ToLower() == secondCode.ToLower())
            {
                studenCodesMatch = true;
            }

            return studenCodesMatch;
        }
    }
}
