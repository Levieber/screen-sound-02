using ScreenSound.Models;

namespace ScreenSound.Utils;

internal class Filter
{
    public static List<string> FilterAllMusicGenres(List<Music> musics)
    {
        var musicGenres = musics.Select(m =>
        {
            if (m.Genre is null) throw new Exception("A música não possui gênero");
            return m.Genre;
        }).Distinct().ToList() ?? throw new Exception("Não tem itens para filtrar.");
        return musicGenres;
    }

    public static List<string> FilterArtistByGenre(List<Music> musics, string genre)
    {
        var artists = musics.Where(m =>
        {
            if (m.Genre is null) throw new Exception("A música não possui gênero");
            return m.Genre.Contains(genre);
        }).Select(m =>
        {
            if (m.Artist is null) throw new Exception("A música não possui artista");
            return m.Artist;
        }).Distinct().ToList() ?? throw new Exception("Não tem itens para filtrar.");

        return artists;
    }

    public static List<Music> FilterMusicsByAnArtist(List<Music> musics, string artist)
    {
        var artistMusics = musics.Where(m =>
        {
            if (m.Artist is null) throw new Exception("A música não possui gênero");
            return m.Artist.Equals(artist);
        }).ToList();

        return artistMusics;
    }

    public static List<Music> FilterMusicsByAnYear(List<Music> musics, int year)
    {
        var artistMusics = musics.Where(m => m.Year == year).Distinct().ToList();

        return artistMusics;
    }

    public static List<Music> FilterMusicsByAnTonality(List<Music> musics, string tonality) {
        var filteredMusics = musics.Where(m => {
            if (m.Tonality is null) throw new Exception("A música não possui tonalidade");
            return m.Tonality.Equals(tonality);
        }).ToList();

        return filteredMusics;
    }
}