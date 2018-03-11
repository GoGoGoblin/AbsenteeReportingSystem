using System.Data;

    public interface IStorageAgent
    {
        IDbConnection GetStorageConnection();
        void CloseStorageConnection(IDbConnection con);
        DataTable GetData(IDbConnection con, string strQuery);
    }
