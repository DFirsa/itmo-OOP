
namespace Lab2
{
    public class Track
    {
        private int duration;
        private Album album;
        private string name;

        public Track(Album album, string name, int duration)
        {
            this.album = album;
            this.name = name;
            this.duration = duration;
            album.AddTrack(this);
        }
    }
}