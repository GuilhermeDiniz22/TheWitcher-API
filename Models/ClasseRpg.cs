using System.Text.Json.Serialization;

namespace rpgapi.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))] //inverte os valores do json
    public enum ClasseRpg
    {
        Bruxo = 1,

        Mago = 2,

        Healer = 3
    }
}