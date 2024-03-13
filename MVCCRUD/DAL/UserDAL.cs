using MVCCRUD.Models;
using MVCCRUD.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCCRUD.DAL
{
    public class UserDAL : BaseService
    {
        #region CRUD


        public List<UserModal> UserList()
        {
            List<UserModal> users = new List<UserModal>();
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            string sqlQuery = String.Format("SELECT [UserID],[ADUserName],[ReportRoles],[IsActive] FROM [dbo].[User]");
            command.CommandText = sqlQuery;
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                users.Add(new UserModal
                {
                    Id = GetDBInt(dr["UserID"]),
                    ReportRoles = GetDBList(dr["ReportRoles"]),
                    Name = GetDBString(dr["ADUserName"].ToString())
                });
            }

            return users;
        }

        public UserModal GetUser(UserModal userModal)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = "SELECT [UserID],[ADUserName],[ReportRoles],[IsActive] FROM [dbo].[User] WHERE UserID=@id;";
            command.Parameters.AddWithValue("@id", userModal.Id);
            sqlConnection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                userModal.Name = GetDBString(reader["ADUserName"]);
                userModal.ReportRoles = GetDBList(reader["ReportRoles"]);
                userModal.Reports = GetReports();
            }

            return userModal;
        }
        
        public List<ReportModal> GetReports()
        {
            List<ReportModal> reports = new List<ReportModal>();
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            string sqlQuery = String.Format("SELECT [ReportID],[ReportName],[IsActive] FROM [dbo].[Report]");
            command.CommandText = sqlQuery;
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                reports.Add(new ReportModal
                {
                    Id = GetDBInt(dr["ReportID"]),
                    Name = GetDBString(dr["ReportName"].ToString())
                });
            }

            return reports;
        }
        #endregion


    }
}