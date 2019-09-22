namespace Lab2
{
    public class Track
    {
        private string name;
        private long duration; //at sec

        public Track(string name, int min, int sec)
        {
            this.name = name;
            this.duration = min * 60 + sec;
        }

        public override string ToString()
        {
            return $"{name} {duration / 60}:{duration % 60}";
        }
    }
}