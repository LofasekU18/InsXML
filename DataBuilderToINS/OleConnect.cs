using System.Configuration;
using System.Data.OleDb;

namespace InsXml;

// string query = ConfigurationManager.AppSettings["Query1"];

class OleConnect
{
    public static T GetRowFromDatabase<T>(string query)
    {
        // Connection string to your database
        string connectionString = ConfigurationManager.ConnectionStrings["MyOleDbConnectionString"].ConnectionString;

        // SQL query to select data

        try
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (typeof(T) == typeof(DataMsAccess))
                            {
                                return (T)Convert.ChangeType(new DataMsAccess
                                {
                                    RozhodnutiVydal = reader?.GetValue(0).ToString(),
                                }, typeof(T));
                            }
                            if (typeof(T) == typeof(List<string>)) // + SQL(Povinny + adresa - RC a IC) + If(RC == NULL) => IC a opacne
                            {
                                return (T)Convert.ChangeType(new List<string> { reader.GetValue(0).ToString(), reader.GetValue(1).ToString() }
                               , typeof(T));
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Environment.Exit(0);
        }

        // Return null if no data found or an error occurred
        return default;
    }

}



