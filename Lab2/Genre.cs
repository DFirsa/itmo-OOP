using System.Collections.Generic;

namespace Lab2
{
    public class Genre
    {
        private string name;
        private List<Genre> subgenre;
        private Genre parentGenre;
        
        public Genre(){}

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

    }
}