using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using NGDemo_Models.Models.Base;
using Sheng_Core;

namespace NGDemo_Repository.Base
{
    public class Command : IDataAccess
    {
        string _connStr = Text.GetConfigConParm("NGDemo");
        SqlConnection _conn = null;

        public Command()
        {
            _conn = new SqlConnection(_connStr);
            Open();
        }

        public void Open()
        {
            if (_conn != null)
            {
                _conn.Open();
            }
        }

        public void Close()
        {
            if (_conn != null)
            {
                _conn.Close();
            }
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }

        public int ExecuteNonQuery<TRequest>(string Sql, TRequest RequestModel, out Result Result)
        {
            Result = new Result();

            try
            {
                return _conn.Execute(Sql, RequestModel);
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
                return 0;
            }
        }

        public IQueryable<TResponse> ExecuteQuery<TRequest, TResponse>(string Sql, TRequest RequestModel, out Result Result)
        {
            Result = new Result();

            try
            {
                return _conn.Query<TResponse>(Sql, RequestModel).AsQueryable();
            }
            catch (Exception ex)
            {
                Result.Success = false;
                Result.Message = ex.Message;
                return null;
            }
        }

    }
}
