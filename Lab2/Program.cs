using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Catalogue catalogue = Catalogue.Load("..\\..\\Songs.txt", "..\\..\\Genres.txt");

            string gNotFound = "";
            
            try
            {
                gNotFound = "Rock";
                
                Console.WriteLine($" === {gNotFound} tracks === ");
                foreach (var track in SearchEngine.SearchTrackByGenre(gNotFound, catalogue))
                    Console.WriteLine(track.ToString());
                
                Console.WriteLine($" === {gNotFound} artists === ");
                foreach (var artist in SearchEngine.SearchArtistsByGenre(gNotFound, catalogue))
                    Console.WriteLine(artist.ToString());

                gNotFound = "Indie";
                
                Console.WriteLine($" === {gNotFound} tracks === ");
                foreach (var track in SearchEngine.SearchTrackByGenre(gNotFound, catalogue))
                    Console.WriteLine(track.ToString());
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"\nGenre {gNotFound} not found\n");
            }

            Console.WriteLine(" === Oasis === ");
            foreach (var artist in SearchEngine.SearchArtistsByName("Oasis", catalogue))
            {
                Console.WriteLine(artist.ToString());
            }
            
            Console.WriteLine(" === Track compilation contanied pop === ");
            foreach (var tc in SearchEngine.SearchTrackCompilationByGenre("Pop", catalogue))
                Console.WriteLine(tc.ToString());
        }
    }
}