using System.Text.Json.Serialization;

namespace Task3.Model
{
    public class Result
    {
        public Result()
        {
        }

        public Result(int successful, int failed)
        {
            Successful = successful;
            Failed = failed;
        }

        [JsonPropertyName("successful")]
        private int Successful { get; set; }

        [JsonPropertyName("failed")]
        private int Failed { get; set; }
    }
}
