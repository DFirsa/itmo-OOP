using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

//TODO fix genres exist check
//Load = ok
//genre to album isn't ok

namespace Lab2
{
    public class Catalogue
    {
        private List<Artist> data;
        private Dictionary<string, Genre> genres;

        public Catalogue()
        {
            data = new List<Artist>();
            genres = new Dictionary<string, Genre>();
        }

        private Artist GetArtist(string name)
        {
            foreach (var artist in data)
                if (artist.name.ToLower().Equals(name.ToLower()))
                    return artist;

            return null;
        }

        private void TrackAddition(string[] trackInfo, Album album)
        {
            string[] time = trackInfo[4].Trim().Split(':');
            int min, sec;
            Int32.TryParse(time[0].Trim(), out min);
            Int32.TryParse(time[0].Trim(), out sec);
            album.AddTrack(trackInfo[0].Trim(), min, sec);
        }

        private void AlbumAddition(string[] trackInfo, Artist artist, int linenum)
        {
            short year;
            short.TryParse(trackInfo[3].Trim(), out year);
            if (!genres.ContainsKey(trackInfo[5].Trim()))
            {
                Console.WriteLine($"Undefined genre: line {linenum}");
                return;
            }

            Album album = new Album(trackInfo[2].Trim(), year, genres[trackInfo[5].Trim()]);
            artist.AddAlbum(album);
            TrackAddition(trackInfo, album);
        }

        private void LoadGenres(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                int linenum = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    linenum++;

                    string[] genreInfo = line.Split('/');
                    if (genreInfo.Length > 3 && genreInfo.Length < 2)
                    {
                        Console.WriteLine($"Invalid input genres data: line {linenum}");
                        continue;
                    }

                    if (genreInfo[0].Trim().Equals("g"))
                        genres.Add(genreInfo[1].Trim().ToLower(), new Genre(genreInfo[1].Trim()));
                    else
                    {
                        if (genreInfo[0].Trim().Equals("s"))
                        {
                            if (genres.ContainsKey(genreInfo[1].Trim().ToLower()) && genreInfo.Length == 3)
                            {
                                Genre subgenre = new Genre(genreInfo[2].Trim());
                                genres[genreInfo[1].Trim().ToLower()].AddSubgenre(subgenre);
                                genres.Add(genreInfo[2].Trim().ToLower(), subgenre);
                            }
                            else Console.WriteLine($"Invalid input data: line {linenum}");
                        }
                        else Console.WriteLine($"Unknown flag {genreInfo[0].Trim()}");
                    }
                }
            }
        }

        private void LoadTracks(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int linenum = 0;
                
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    linenum++;
                    
                    // 6 for genres without compilations
                    string[] trackInfo = line.Split('/');
                    if (trackInfo.Length != 6)
                    {
                        Console.WriteLine($"Invalid input tracks data: line {linenum}");
                        continue;
                    }
                    
                    Artist artist;
                    if ((artist = GetArtist(trackInfo[1].Trim())) != null)
                    {
                        Album album;
                        if ((album = artist.GetAlbum(trackInfo[2].Trim())) != null)
                            TrackAddition(trackInfo, album);
                        else AlbumAddition(trackInfo, artist, linenum);
                    }
                    else
                    {
                        artist = new Artist(trackInfo[1].Trim());
                        data.Add(artist);
                        AlbumAddition(trackInfo, artist, linenum);
                    }
                }
            }
        }

        public static Catalogue Load(string SongsPath, string GenresPath)
        {
            Catalogue catalogue = new Catalogue();

            catalogue.LoadGenres(GenresPath);
            catalogue.LoadTracks(SongsPath);

            return catalogue;
        }

        public void ShowArtists()
        {
            foreach (var artist in data)
            {
                Console.WriteLine(artist.ToString());
            }
        }
    }
}