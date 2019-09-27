using System.Collections.Generic;
using System.Xml;

namespace Lab2
{
    public class TrackCompilation
    {
        private List<Track> tracks;
        public readonly string name;
        public readonly List<Genre> genres;
        public readonly List<Artist> Artists;

        public TrackCompilation(string name)
        {
            this.name = name;
            tracks = new List<Track>();
        }

        public void AddTrack(Track track)
        {
            tracks.Add(track);
            AddArtist(track);
            AddGenre(track);
        }

        private bool hasGenre(Genre genre)
        {
            foreach (var gen in genres)
                if (genre.name.ToLower().Equals(gen.name.ToLower()))
                    return true;

            return false;
        }
        
        private bool hasArtist(Artist artist)
        {
            foreach (var art in Artists)
                if (art.name.ToLower().Equals(artist.name.ToLower()))
                    return true;

            return false;
        }
        
        private void AddGenre(Track track)
        {
            if (!hasGenre(track.album.genre))
                genres.Add(track.album.genre);
        }

        private void AddArtist(Track track)
        {
            if (!hasArtist(track.album.artist))
                Artists.Add(track.album.artist);
        }

        public override string ToString()
        {
            return name;
        }
    }
}