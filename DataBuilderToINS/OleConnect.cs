using System.Configuration;
using System.Data.OleDb;

namespace InsXml;

        // string query = ConfigurationManager.AppSettings["Query1"];

class OleConnect
{
    public static (object Column1, object Column2, object Column3)? GetRowFromDatabase(string query)
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
                            // Read data from the first row and return it as a tuple
                            return (
                                reader.GetValue(0),
                                reader.GetValue(1),
                                reader.GetValue(2)
                            );
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        // Return null if no data found or an error occurred
        return null;
    }

}


