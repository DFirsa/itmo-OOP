using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2
{
    public class Catalogue
    {
        private List<Artist> data;

        public Catalogue()
        {
            data = new List<Artist>();
        }

        private Artist GetArtist(string name)
        {
            foreach (var artist in data)
                if (artist.name.ToLower().Equals(name.ToLower()))
                    return artist;

            return null;
        }

        private void TrackAddition(string duration, string name, Album album)
        {
            string[] time = duration.Trim().Split(':');
            int min, sec;
            Int32.TryParse(time[0].Trim(), out min);
            Int32.TryParse(time[0].Trim(), out sec);
            album.AddTrack(name.Trim(), min, sec);
        }

        public static Catalogue Load(string path)
        {
            Catalogue catalogue = new Catalogue();

            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] trackInfo = line.Split('/');
                    Artist artist;
                    if ((artist = catalogue.GetArtist(trackInfo[1].Trim())) != null)
                    {
                        Album album;
                        if ((album = artist.GetAlbum(trackInfo[2].Trim())) != null)
                            catalogue.TrackAddition(trackInfo[4], trackInfo[0], album);
                        else
                        {
                            short year;
                            short.TryParse(trackInfo[3].Trim(), out year);
                            album = new Album(trackInfo[2].Trim(), year);
                            artist.AddAlbum(album);
                            catalogue.TrackAddition(trackInfo[4], trackInfo[0], album);
                        }
                    }
                    else
                    {
                        artist = new Artist(trackInfo[1].Trim());
                        catalogue.data.Add(artist);
                        short year;
                        short.TryParse(trackInfo[3].Trim(), out year);
                        Album album = new Album(trackInfo[2].Trim(), year);
                        artist.AddAlbum(album);
                        catalogue.TrackAddition(trackInfo[4], trackInfo[0], album);
                    }
                }
            }

            return catalogue;
        }
    }
}