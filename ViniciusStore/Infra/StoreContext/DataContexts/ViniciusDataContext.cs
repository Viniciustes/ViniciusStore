using System;
using System.Data.SqlClient;
using System.Data;
using Shared.Configurations;

namespace Infra.StoreContext.DataContexts
{
    public class ViniciusDataContext : IViniciusDataContext, IDisposable
    {
        public SqlConnection SqlConnection { get; set; }

        public ViniciusDataContext()
        {
            SqlConnection = new SqlConnection(Settings.ConnectionString);
            SqlConnection.Open();
        }

        public void Dispose()
        {
            if (SqlConnection.State != ConnectionState.Closed)
                SqlConnection.Close();
        }
    }
}