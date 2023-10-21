using Dapper;
using System.Data.SqlClient;

public class DbContext
{
    public IEnumerable<T> ExecuteQuery<T>(string query, object Params)
    {
        using (SqlConnection dbConnection = new SqlConnection("Server=FULL-90\\SQLEXPRESS01;Trusted_Connection=True;Database=Tool;initial catalog=Tool;"))
        {
            dbConnection.Open();
            return dbConnection.Query<T>(query, Params);
        }
    }

    public int ExecuteUpdate(string updateQuery)
    {
        using (SqlConnection dbConnection = new SqlConnection("Server=FULL-90\\SQLEXPRESS01;Trusted_Connection=True;Database=Tool;initial catalog=Tool;"))
        {
            dbConnection.Open();
            return dbConnection.Execute(updateQuery);
        }
    }
}