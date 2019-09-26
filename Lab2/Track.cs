namespace Lab2
{
    public class Track
    {
        private string name;
        private int durationMin;
        private int durationSec;
        private Album album;

        public Track(string name, int min, int sec, Album album)
        {
            this.name = name;
            this.durationMin = min;
            this.durationSec = sec;
            this.album = album;
        }

        public override string ToString()
        {
            return $"{name} {durationMin}:{durationSec}";
        }
    }
}