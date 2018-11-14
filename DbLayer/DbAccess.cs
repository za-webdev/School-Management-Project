using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer
{
    public class DbAccess : IDbAccess
    {
        public DataTable Select(string command, string connectionString)
        {
            var dataTable = new DataTable();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                    using (var dataReader = objSqlCommand.ExecuteReader())
                    {
                        dataTable.Load(dataReader);
                    }
                }
                sqlConnection.Close();
            }

            return dataTable;
        }

        public void Insert(string command, string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                    objSqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public void Delete (string command ,string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                    objSqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }

        public Double SumOfTotal(string command, string connectionString)
        {
            Double sum;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                     sum = Convert.ToInt32(objSqlCommand.ExecuteScalar());
                }
                sqlConnection.Close();
            }
            return sum;
        }

        public int CountOfSubjects(string command, string connectionString)
        {
            int countOfSubjects;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                    countOfSubjects = Convert.ToInt32(objSqlCommand.ExecuteScalar());
                }
                sqlConnection.Close();
            }
            return countOfSubjects;

        }

        public void UpdateGPA(string command,string connectionString)
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand objSqlCommand = new SqlCommand(command, sqlConnection))
                {
                    objSqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
            
        }
    }
}
