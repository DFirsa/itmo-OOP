namespace Lab2
{
    public class Track
    {
        private string name;
        private long duration; //at sec
        private Album album;

        public Track(string name, int min, int sec, Album album)
        {
            this.name = name;
            this.duration = min * 60 + sec;
            this.album = album;
        }

        public override string ToString()
        {
            return $"{name} {duration / 60}:{duration % 60}";
        }
    }
}