using System.Text.Json;
using ScreenSound.Utils;
using ScreenSound.Models;

using (HttpClient client = new())
{
    try
    {
        string response = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");

        var musics = JsonSerializer.Deserialize<List<Music>>(response) ?? throw new Exception("Não há músicas!");

        Favorite favoriteMusics = new("Levi Eber");
        favoriteMusics.AddFavorite(musics[1]);
        favoriteMusics.AddFavorite(musics[1900]);
        favoriteMusics.AddFavorite(musics[1901]);
        favoriteMusics.AddFavorite(musics[1920]);

        favoriteMusics.ShowFavorites();
        favoriteMusics.ExportToJsonFile();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Tivemos um problema! Erro: {ex.Message}");
    }
}