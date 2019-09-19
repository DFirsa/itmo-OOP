using System.Collections.Generic;

namespace Lab2
{
    //TODO delete tracklist mb
    public class Album
    {
        private List<Track> trackList;
        private string name;
        
        public readonly Artist artist;
        public readonly Genre genre;

        public Album(Artist artist, Genre genre, string name)
        {
            trackList = new List<Track>();
            this.artist = artist;
            this.genre = genre;
            this.name = name;
        }

        public void AddTrack(Track track)
        {
            trackList.Add(track);
        }

        public override string ToString()
        {
            return $"{artist.ToString()}, album : {name}";
        }
    }
}