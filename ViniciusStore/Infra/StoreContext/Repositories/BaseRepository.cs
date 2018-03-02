using Infra.StoreContext.DataContexts;
using System;
using System.Data;

namespace Infra.StoreContext.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected readonly ViniciusDataContext DbContext = new ViniciusDataContext();

        public void Dispose()
        {
            if (DbContext.SqlConnection.State != ConnectionState.Closed)
                DbContext.SqlConnection.Close();
        }
    }
}
