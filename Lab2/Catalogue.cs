using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab2
{
    public class Catalogue
    {
        public readonly List<Artist> Data;
        public readonly List<Genre> Genres;
        public readonly List<TrackCompilation> TrackCompilations;

        public Catalogue()
        {
            Data = new List<Artist>();
            Genres = new List<Genre>();
            TrackCompilations = new List<TrackCompilation>();
        }

        private TrackCompilation GetTrackCompilation(string name)
        {
            foreach (var compil in TrackCompilations)
                if (compil.Name.ToLower().Equals(name.ToLower()))
                    return compil;

            return null;
        }

        private Artist GetArtist(string name)
        {
            foreach (var artist in Data)
                if (artist.ToString().ToLower().Equals(name.ToLower()))
                    return artist;

            return null;
        }

        private Genre GetGenre(string name)
        {
            foreach (var genre in Genres)
                if (genre.Name.ToLower().Equals(name.ToLower()))
                    return genre;

            return null;
        }

        private void TrackAddition(string[] trackInfo, Album album)
        {
            string[] time = trackInfo[4].Trim().Split(':');
            int min, sec;
            Int32.TryParse(time[0].Trim(), out min);
            Int32.TryParse(time[1].Trim(), out sec);
            Track track = new Track(trackInfo[0].Trim(), min, sec, album);
            album.AddTrack(track);
            if (trackInfo.Length == 7)
            {
                TrackCompilation compil = GetTrackCompilation(trackInfo[6].Trim());
                if(compil != null)
                    compil.AddTrack(track);
                else
                {
                    TrackCompilation compilation = new TrackCompilation(trackInfo[6].Trim());
                    TrackCompilations.Add(compilation);
                    compilation.AddTrack(track);
                }
            }
        }

        private void AlbumAddition(string[] trackInfo, Artist artist, int linenum)
        {
            short year;
            short.TryParse(trackInfo[3].Trim(), out year);

            Genre genre = GetGenre(trackInfo[5].Trim());
            if (genre != null)
            {
                Album album = new Album(trackInfo[2].Trim(), year, genre, artist);
                artist.AddAlbum(album);
                TrackAddition(trackInfo, album);
            }
            else Console.WriteLine($"Invalid genre in the track: line {linenum}");
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
                    
                    string[] trackInfo = line.Split('/');
                    if (!(trackInfo.Length == 6 || trackInfo.Length == 7))
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
                        Data.Add(artist);
                        AlbumAddition(trackInfo, artist, linenum);
                    }
                }
            }
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
                    string[] lines = line.Split('/');

                    if (lines.Length == 2 && lines[0].Trim().ToLower().Equals("g") ||
                        lines.Length == 3 && lines[0].Trim().ToLower().Equals("s"))
                    {
                        if (lines.Length == 2)
                            Genres.Add(new Genre(lines[1].Trim()));
                        else
                        {
                            Genre genre = new Genre(lines[2].Trim());
                            Genres.Add(genre);
                            Genre baseG = GetGenre(lines[1].Trim());
                            if (baseG != null)
                                baseG.AddSubgenre(genre);
                            else Console.WriteLine($"Invalid genres info (base genre doesn't exist): line {linenum}");
                        }
                    }
                    else Console.WriteLine($"Invalid genres info: line {linenum}");
                }
            }
        }

        public static Catalogue Load(string songsPath, string genresPath)
        {
            Catalogue catalogue = new Catalogue();
            catalogue.LoadGenres(genresPath);
            catalogue.LoadTracks(songsPath);
            return catalogue;
        }

    }
}