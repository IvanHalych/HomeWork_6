using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Task2.Model;

namespace Task2
{
    public static class FileWork
    {
        public static List<Setting> Read()
        {
            return JsonSerializer.Deserialize<List<Setting>>(File.ReadAllText("settings.json"));
        }

        public static void Write(Result result)
        {
            File.WriteAllText("result.json", JsonSerializer.Serialize(result));
        }
    }
}
