using System.Collections.Generic;

namespace Lab2
{
    public class Album
    {
        private readonly List<Track> trackList;
        private Genre genre;
        private short year;
        
        public readonly string name;

        public Album(string albumName, short year, Genre genre)
        {
            name = albumName;
            this.year = year;
            this.genre = genre;
            
            trackList = new List<Track>();
        }

        public void AddTrack(string trackName, int durationMin, int durationSec)
        {
            trackList.Add(new Track(trackName, durationMin, durationSec, this));
        }
    }
}