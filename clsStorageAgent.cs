﻿using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

public class clsStorageAgent : IStorageAgent
{
    public IDbConnection GetStorageConnection()
    {
        string conStr = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        return new MySqlConnection(conStr);
    }

    public void CloseStorageConnection(IDbConnection con)
    {
        con.Close();
        con.Dispose();
    }


    public DataTable GetData(IDbConnection con, string strQuery)
    {
        var sqlCmd = new MySqlCommand(strQuery, (MySqlConnection)con);
        sqlCmd.CommandType = CommandType.StoredProcedure;
        MySqlDataReader clsRdr = sqlCmd.ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load(clsRdr);

        return dataTable;
    }

    public void SaveData(IDbConnection Connection, string strQuery)
    {
        throw new NotImplementedException();
    }  

}
