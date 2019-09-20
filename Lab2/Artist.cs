using System.Collections.Generic;

namespace Lab2
{
    public class Artist
    {
        private string name;
        private List<Album> albumList;

        public Artist(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}