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
                    
                List<Track> rockTrack = SearchEngine.SearchTrackByGenre("Rock", catalogue);
                Console.WriteLine(" === Rock tracks === ");
                foreach (var track in rockTrack)
                    Console.WriteLine(track.ToString());

                gNotFound = "Indi";
                
                List<Track> indieTrack = SearchEngine.SearchTrackByGenre("Indie", catalogue);
                Console.WriteLine(" === Indie tracks === ");
                foreach (var track in indieTrack)
                    Console.WriteLine(track.ToString());
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"Genre {gNotFound} not found");
            }
        }
    }
}