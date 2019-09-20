using System.Collections.Generic;
using System.IO;

namespace Lab2
{
    public class Catalogue
    {
        private List<Artist> data;
        private static Dictionary<string,Genre> genres;

        public Catalogue()
        {
            data = new List<Artist>();
            genres = new Dictionary<string, Genre>();
        }

        private static void LoadGenres(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] lines = line.Split(' ');
                    if (lines[0].Trim().Equals("g"))
                    {
                        Genre genre = new Genre(lines[1]);
                        genres.Add(lines[1],genre);
                    }

                    if (lines[0].Trim().Equals("s"))
                    {
                        Genre genre = new Genre($"{lines[1]} {lines[2]}");
                        genres.Add(lines[2],genre);
//                        Genre gen = new Genre("");
//                        genres.TryGetValue(lines[1], gen);

                        //TODO add subgenre
                    }
                }
            }
        }

    }
}