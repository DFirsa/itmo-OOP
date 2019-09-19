using System.Collections.Generic;

namespace Lab2
{
    //TODO delete tracklist mb
    public class Album
    {
        private List<Track> trackList;
        private Artist artist;
        private Genre genre;

        public Album(Artist artist, Genre genre)
        {
            trackList = new List<Track>();
            this.artist = artist;
            this.genre = genre;
        }

        public void AddTrack(Track track)
        {
            trackList.Add(track);
        }
    }
}