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

            if (artists.Count != 0)
                return artists;
            else
                throw new InstanceNotFoundException();
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
                        artists.Add(artist);
            }

            if (artists.Count != 0)
                return artists;
            else
                throw new InstanceNotFoundException();
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

            if (albums.Count != 0)
                return albums;
            else
                throw new InstanceNotFoundException();
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
            
            if (albums.Count != 0)
                return albums;
            else
                throw new InstanceNotFoundException();
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

            if (albums.Count != 0)
                return albums;
            else throw new InstanceNotFoundException();
        }
    }
}