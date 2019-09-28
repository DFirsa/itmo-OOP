using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    public class Genre
    {
        public readonly string Name;
        private List<Genre> subgenres;

        public Genre(string name)
        {
            this.Name = name;
            subgenres = new List<Genre>();
        }

        public void AddSubgenre(Genre subgenre)
        {
            subgenres.Add(subgenre);
        }

        //subgenre == genre, but genre != subgenre
        public bool IsSubgenreOf(Genre genre)
        {
            //TODO try to fix this
//            return this.Equals(genre) || genre.subgenres.Any(x => x.IsSubgenreOf(genre));
                
            Genre finder;
            Queue<Genre> queue = new Queue<Genre>();
            foreach (var subgenre in genre.subgenres)
                queue.Enqueue(subgenre);

            while (queue.Count != 0)
            {
                finder = queue.Dequeue();
                if (this.Equals(finder)) return true;
                foreach (var subgenre in finder.subgenres)
                    queue.Enqueue(subgenre);
            }

            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}