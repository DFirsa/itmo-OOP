using System;
using System.Collections.Generic;

namespace Lab2
{
    
    //TODO write main and compilation
    internal class Program
    {
        public static void Main(string[] args)
        {
            Catalogue catalogue = Catalogue.Load("..\\..\\Songs.txt", "..\\..\\Genres.txt");

            string gNotFound = "";
            
            try
            {
                gNotFound = "Rock";
                    
                List<Track> rockTrack = SearchEngine.SearchTrackByGenre(gNotFound, catalogue);
                Console.WriteLine($" === {gNotFound} tracks === ");
                foreach (var track in rockTrack)
                    Console.WriteLine(track.ToString());
                
                List<Artist> artists = SearchEngine.SearchArtistsByGenre(gNotFound, catalogue);
                Console.WriteLine($" === {gNotFound} artists === ");
                foreach (var artist in artists)
                    Console.WriteLine(artist.ToString());

                gNotFound = "Indie";
                
                List<Track> indieTrack = SearchEngine.SearchTrackByGenre(gNotFound, catalogue);
                Console.WriteLine($" === {gNotFound} tracks === ");
                foreach (var track in indieTrack)
                    Console.WriteLine(track.ToString());
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"\nGenre {gNotFound} not found\n");
            }

            Console.WriteLine(" === Oasis === ");
            List<Artist> oasis = SearchEngine.SearchArtistsByName("Oasis", catalogue);
            foreach (var artist in oasis)
            {
                Console.WriteLine(artist.ToString());
            }
            
            Console.WriteLine(" === Track compilation contanied pop === ");
            foreach (var tc in SearchEngine.SearchTrackCompilationByGenre("Pop", catalogue))
                Console.WriteLine(tc.ToString());
        }
    }
}