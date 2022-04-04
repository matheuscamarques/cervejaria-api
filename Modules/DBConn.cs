namespace cervejaria_api.Modules;
using  System.Data.SqlClient;

public class AzureConn
{
    public static  SqlConnection GetConnection()
    {
        string host = "cervejariadb.database.windows.net";
        string username = "develop";
        string password = "Cervejaria@";
        string database = "cervejaria";
        // AZURE CONNECTION STRING
        //Server=tcp:cervejariadb.database.windows.net,1433;Initial Catalog=cervejaria;Persist Security Info=False;User ID=develop;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        string connectionString = $"Server={host};Initial Catalog={database};Persist Security Info=False;User ID={username};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        SqlConnection connection = new SqlConnection(connectionString);
        return connection;
    }
}