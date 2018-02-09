using Infra.StoreContext.DataContexts;
using System;
using System.Data;

namespace Infra.StoreContext.Repositories
{
    public class BaseRepository: IDisposable
    {
        protected readonly ViniciusDataContext viniciusDataContext = new ViniciusDataContext();

        public void Dispose()
        {
            if (viniciusDataContext.SqlConnection.State != ConnectionState.Closed)
                viniciusDataContext.SqlConnection.Close();
        }
    }
}
