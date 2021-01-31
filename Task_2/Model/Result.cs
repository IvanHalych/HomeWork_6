using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Task2.Model
{
    public class Result
    {
        public Result(string duration, bool success, IList<int> primes, string error )
        {
            Success = success;
            Error = error;
            Primes = primes;
            Duration = duration;
        }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("primes")]
        public IList<int> Primes { get; set; }
    }
}
