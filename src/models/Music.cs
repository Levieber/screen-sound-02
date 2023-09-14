using System.Text.Json.Serialization;

namespace ScreenSound.Models;

internal class Music
{
    private string[] tonalities = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B", };

    [JsonPropertyName("song")]
    public string? Name { get; set; }

    [JsonPropertyName("artist")]
    public string? Artist { get; set; }

    [JsonPropertyName("duration_ms")]
    public int Duration { get; set; }

    [JsonPropertyName("genre")]
    public string? Genre { get; set; }

    [JsonPropertyName("year")]
    public string? yearString { get; set; }

    [JsonIgnore()]
    public int Year
    {
        get
        {
            return int.Parse(yearString!);
        }
    }

    [JsonPropertyName("key")]
    public int Key { get; set; }

    [JsonIgnore()]
    public string Tonality
    {
        get
        {
            return tonalities[Key];
        }
    }

    public void ShowDetails()
    {
        Console.WriteLine($"Nome: {Name}");
        Console.WriteLine($"Artista: {Artist}");
        Console.WriteLine($"Duração em minutos: {(Duration / 1000 / 60).ToString("F")}");
        Console.WriteLine($"Gênero: {Genre}");
        Console.WriteLine($"Lançado em: {Year}");
        Console.WriteLine($"Tonalidade: {Tonality}");
    }
}