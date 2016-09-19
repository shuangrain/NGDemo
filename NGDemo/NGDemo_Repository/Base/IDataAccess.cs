using System;
using System.Linq;
using NGDemo_Models.Models.Base;

namespace NGDemo_Repository.Base
{
    interface IDataAccess : IDisposable
    {
        void Open();

        void Close();

        int ExecuteNonQuery<TRequest>(string Sql, TRequest RequestModel, out Result Result);

        IQueryable<TResponse> ExecuteQuery<TRequest, TResponse>(string Sql, TRequest RequestModel, out Result Result);
    }
}
