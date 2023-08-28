using System.Data;

namespace loadtestapi.Factory
{
    public static class DataReaderExtensions
    {
        // Helper extension method to map the data reader to a list of objects
        public static List<T> MapToList<T>(this IDataReader reader)
        {
            var list = new List<T>();
            var properties = typeof(T).GetProperties();

            while (reader.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (var prop in properties)
                {
                    if (!Equals(reader[prop.Name], DBNull.Value))
                    {
                        if (reader[prop.Name].GetType() == System.Type.GetType("System.DateTimeOffset"))
                        {
                            var time = reader[prop.Name].ToString();
                            prop.SetValue(obj, Convert.ToDateTime(time), null);
                        }
                        else
                        {
                            prop.SetValue(obj, reader[prop.Name], null);
                        }

                    }
                }
                list.Add(obj);
            }
            return list;
        }
    }
}
