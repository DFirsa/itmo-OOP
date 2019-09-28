using System;
using System.Collections.Generic;
using System.Management.Instrumentation;

namespace Lab2
{
    public static class SearchEngine
    {
        //TODO нерегистрозваисимый поиск
        //TODO multisearch
        public static Artist SearchArtistByName(string name, Catalogue catalogue)
        {
            foreach (var artist in catalogue.Data)
                if (artist.ToString().ToLower().Contains(name.ToLower()))
                    return artist;
            
            return null;
        }

        public static List<Artist> SearchArtistsByGenre(string genre, Catalogue catalogue)
        {
            List<Artist> artists = new List<Artist>();

            Genre foundGenre = null;
            foreach (var gen in catalogue.Genres)
                if (gen.ToString().ToLower().Equals(genre.ToLower()))
                    foundGenre = gen;

            if (foundGenre == null) throw new KeyNotFoundException();

            foreach (var artist in catalogue.Data)
            {
                foreach (var album in artist.AlbumList)
                    if (album.Genre.IsSubgenreOf(foundGenre))
                    {
                        artists.Add(artist);
                        break;
                    }
            }

            return artists;
        }

        public static List<Album> SearchAlbumByGenre(string genre, Catalogue catalogue)
        {
            List<Album> albums = new List<Album>();

            Genre foundGenre = null;
            foreach (var gen in catalogue.Genres)
                if (gen.ToString().ToLower().Equals(genre.ToLower()))
                    foundGenre = gen;

            if (foundGenre == null) throw new KeyNotFoundException();

            foreach (var artist in catalogue.Data)
            {
                foreach (var album in artist.AlbumList)
                    if (album.Genre.IsSubgenreOf(foundGenre))
                        albums.Add(album);
            }

            return albums;
        }

        public static List<Album> SearchAlbumByYear(int year, Catalogue catalogue)
        {
            List<Album> albums = new List<Album>();

            foreach (var artist in catalogue.Data)
            {
                foreach (var album in artist.AlbumList)
                    if (album.Year == year)
                        albums.Add(album);
            }
            
            return albums;
        }

        public static List<Album> SearchAlbumByName(string name, Catalogue catalogue)
        {
            List<Album> albums = new List<Album>();
            
            foreach (var artist in catalogue.Data)
            {
                foreach (var album in artist.AlbumList)
                    if (album.Name.ToLower().Equals(name.ToLower()))
                        albums.Add(album);
            }

            return albums;
        }

        public static List<Track> SearchTrackByName(string name, Catalogue catalogue)
        {
            List<Track> tracks = new List<Track>();
            
            foreach (var artist in catalogue.Data)
            {
                foreach (var album in artist.AlbumList)
                {
                    foreach (var track in album.TrackList)
                        if (track.ToString().ToLower().Equals(name.ToLower()))
                            tracks.Add(track);
                }
            }

            return tracks;
        }

        public static List<Track> SearchTrackByYear(int year, Catalogue catalogue)
        {
            List<Track> tracks = new List<Track>();

            List<Album> albums = SearchEngine.SearchAlbumByYear(year, catalogue);
            foreach (var album in albums)
            {
                foreach (var track in album.TrackList)
                    tracks.Add(track);
            }

            return tracks;
        }

        public static List<Track> SearchTrackByGenre(string genre, Catalogue catalogue)
        {
            List<Track> tracks = new List<Track>();

            try
            {
                List<Album> albums = SearchAlbumByGenre(genre, catalogue);
                foreach (var album in albums)
                {
                    foreach (var track in album.TrackList)
                        tracks.Add(track);
                }
            }
            catch (Exception)
            {
                throw new KeyNotFoundException();
            }

            return tracks;
        }

        public static List<TrackCompilation> SearchTrackCompilationByGenre(string genre, Catalogue catalogue)
        {
            List<TrackCompilation> tc = new List<TrackCompilation>();

            foreach (var compil in catalogue.TrackCompilations)
            {
                foreach (var gen in compil.Genres)
                    if (gen.Name.ToLower().Equals(genre.ToLower()))
                        tc.Add(compil);
            }

            return tc;
        }

        public static List<TrackCompilation> SearchTrackCompilationByArtist(string artist, Catalogue catalogue)
        {
            List<TrackCompilation> tc = new List<TrackCompilation>();
            
            foreach (var compil in catalogue.TrackCompilations)
            {
                foreach (var art in compil.Artists)
                    if (art.ToString().ToLower().Equals(artist.ToLower()))
                        tc.Add(compil);
            }

            return tc;
        }
    }
}