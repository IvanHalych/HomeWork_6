using System.Text.Json.Serialization;

namespace Task2.Model
{
    public class Setting
    {
        [JsonPropertyName("primesFrom")]
        public int PrimesFrom { get; set; }

        [JsonPropertyName("primesTo")]
        public int PrimesTo { get; set; }
    }
}
