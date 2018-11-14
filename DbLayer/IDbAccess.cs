using System;
using System.Data;

namespace DbLayer
{
    public interface IDbAccess
    {
        DataTable Select(string command, string connectionString);
        void Insert(string command, string connectionString);
        void Delete(string command, string connectionString);
        Double SumOfTotal(string command, string connectionString);
        int CountOfSubjects(string command, string connectionString);
        void UpdateGPA(string command, string connectionString);



    }
}