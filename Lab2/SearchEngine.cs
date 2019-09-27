using System;
using System.Collections.Generic;
using System.Management.Instrumentation;

namespace Lab2
{
    public static class SearchEngine
    {
        //search artists by name
        //search artists by genre

        //search albums and trackLists by year
        //search albums and tracklist by name
        //search albums and tracklists by genre

        //search songs by year
        //search songs by genre
        //search songs by name

        public static List<Artist> SearchArtistsByName(string name, Catalogue catalogue)
        {
            List<Artist> artists = new List<Artist>();

            foreach (var artist in catalogue.data)
                if (artist.ToString().ToLower().Equals(name.ToLower()))
                    artists.Add(artist);

            return artists;
        }

        public static List<Artist> SearchArtistsByGenre(string genre, Catalogue catalogue)
        {
            List<Artist> artists = new List<Artist>();

            Genre foundGenre = null;
            foreach (var gen in catalogue.genres)
                if (gen.ToString().ToLower().Equals(genre.ToLower()))
                    foundGenre = gen;

            if (foundGenre == null) throw new KeyNotFoundException();

            foreach (var artist in catalogue.data)
            {
                foreach (var album in artist.albumList)
                    if (album.genre.IsSubgenreOf(foundGenre))
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
            foreach (var gen in catalogue.genres)
                if (gen.ToString().ToLower().Equals(genre.ToLower()))
                    foundGenre = gen;

            if (foundGenre == null) throw new KeyNotFoundException();

            foreach (var artist in catalogue.data)
            {
                foreach (var album in artist.albumList)
                    if (album.genre.IsSubgenreOf(foundGenre))
                        albums.Add(album);
            }

            return albums;
        }

        public static List<Album> SearchAlbumByYear(int year, Catalogue catalogue)
        {
            List<Album> albums = new List<Album>();

            foreach (var artist in catalogue.data)
            {
                foreach (var album in artist.albumList)
                    if (album.year == year)
                        albums.Add(album);
            }
            
            return albums;
        }

        public static List<Album> SearchAlbumByName(string name, Catalogue catalogue)
        {
            List<Album> albums = new List<Album>();
            
            foreach (var artist in catalogue.data)
            {
                foreach (var album in artist.albumList)
                    if (album.name.ToLower().Equals(name.ToLower()))
                        albums.Add(album);
            }

            return albums;
        }

        public static List<Track> SearchTrackByName(string name, Catalogue catalogue)
        {
            List<Track> tracks = new List<Track>();
            
            foreach (var artist in catalogue.data)
            {
                foreach (var album in artist.albumList)
                {
                    foreach (var track in album.trackList)
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
                foreach (var track in album.trackList)
                    tracks.Add(track);
            }

            return tracks;
        }

        public static List<Track> SearchTrackByGenre(string genre, Catalogue catalogue)
        {
            List<Track> tracks = new List<Track>();
            bool cathedEx = false;

            try
            {
                List<Album> albums = SearchAlbumByGenre(genre, catalogue);
                foreach (var album in albums)
                {
                    foreach (var track in album.trackList)
                        tracks.Add(track);
                }
            }
            catch (Exception)
            {
                cathedEx = true;
            }

            if (cathedEx)
                throw new KeyNotFoundException();
            else 
                return tracks;
        }

        public static List<TrackCompilation> SearchTrackCompilationByGenre(string genre, Catalogue catalogue)
        {
            List<TrackCompilation> tc = new List<TrackCompilation>();

            foreach (var compil in catalogue.trackCompilations)
            {
                foreach (var gen in compil.genres)
                    if (gen.name.ToLower().Equals(genre.ToLower()))
                        tc.Add(compil);
            }

            return tc;
        }

        public static List<TrackCompilation> SearchTrackCompilationByArtist(string artist, Catalogue catalogue)
        {
            List<TrackCompilation> tc = new List<TrackCompilation>();
            
            foreach (var compil in catalogue.trackCompilations)
            {
                foreach (var art in compil.Artists)
                    if (art.name.ToLower().Equals(artist.ToLower()))
                        tc.Add(compil);
            }

            return tc;
        }
    }
}