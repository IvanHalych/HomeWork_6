using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Task3.Model;

namespace Task3
{
    internal class WorkWithFile
    {
        public static IEnumerable<(string, string)> Read()
        {
            var list = File.ReadAllLines("logins.csv").Select(line =>
            {
                var items = line.Split(";");
                return (items[0], items[1]);
            });

            return list;
        }

        public static void Write(Result result)
        {
            File.WriteAllText("result.json", JsonSerializer.Serialize(result));
        }
    }
}
