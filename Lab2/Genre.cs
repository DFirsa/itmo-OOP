using System.Collections.Generic;

namespace Lab2
{
    public class Genre
    {
        private string name;
        private List<Genre> subgenre;
        private Genre parentGenre;

        public Genre(string name)
        {
            this.name = name;
        }

        public void AddSubgenre(Genre gen)
        {
            subgenre.Add(gen);
        }

//        public override bool Equals(string name)
//        {
//            Genre genre = this;
//            while (genre != null)
//            {
//                if (genre.name.Equals(name)) return true;
//                else genre = parentGenre;
//            }
//
//            return false;
//        }

        public override bool Equals(Genre genre)
        {
            Queue<Genre> genreQueue = new Queue<Genre>();
            foreach (var gen in subgenre) genreQueue.Enqueue(gen);
            
            
        }
    }
}