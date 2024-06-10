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
                            if (typeof(T) == typeof(dluznikA))
                            {
                                return (T)Convert.ChangeType(new dluznikA
                                {
                                    MyProperty = reader.GetValue(0).ToString(),
                                }, typeof(T));
                            }
                            if (typeof(T) == typeof(dluznikB))
                            {
                                return (T)Convert.ChangeType(new dluznikB
                                {
                                    MyProperty = reader.GetValue(0).ToString(),
                                    MyProperty2 = reader.GetValue(1).ToString(),
                                }, typeof(T));
                            }

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
        return default;
    }

}
class dluznikA
{
    public string MyProperty { get; set; }
    public string MyProperty2 { get; set; }
    public string MyProperty3 { get; set; }

    public override string ToString()
    {
        return $"{MyProperty} {MyProperty2} {MyProperty3}";
    }
}
class dluznikB
{
    public string MyProperty { get; set; }
    public string MyProperty2 { get; set; }
    public string MyProperty3 { get; set; }

    public override string ToString()
    {
        return $"{MyProperty} {MyProperty2} {MyProperty3}";
    }
}


