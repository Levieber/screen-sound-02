using System.Text.Json;

namespace ScreenSound.Models;

internal class Favorite
{
    public string? Name { get; set; }
    public List<Music> Musics { get; }

    public Favorite(string name)
    {
        Name = name;
        Musics = new();
    }

    public void AddFavorite(Music music) {
        Musics.Add(music);
    }

    public void ShowFavorites() {
        Console.WriteLine($"Músicas favoritas de {Name}:");
        foreach (var favorite in Musics)
        {
            Console.WriteLine($"- {favorite.Name} de {favorite.Artist}");
        }
    }

    public void ExportToJsonFile() {
        string json = JsonSerializer.Serialize(new {
            name = Name,
            musics = Musics
        });

        string fileName = $"favorite-musics-{Name}.json".ToLower().Replace(" ", "-");

        File.WriteAllText(fileName, json);
        Console.WriteLine($"Json criado com sucesso em {Path.GetFullPath(fileName)}!");
    }
}