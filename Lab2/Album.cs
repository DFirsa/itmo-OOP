using System.Collections.Generic;

namespace Lab2
{
    public class Album
    {
        public readonly List<Track> trackList;
        public readonly Genre genre;
        public readonly short year;
        
        public readonly string name;
        public readonly Artist artist;

        public Album(string albumName, short year, Genre genre, Artist artist)
        {
            name = albumName;
            this.year = year;
            this.genre = genre;
            this.artist = artist;
            
            trackList = new List<Track>();
        }

        public void AddTrack(Track track)
        {
            trackList.Add(track);
        }
    }
}