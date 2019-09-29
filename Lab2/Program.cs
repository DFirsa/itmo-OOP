﻿using System;
using System.Collections.Generic;

namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Catalogue catalogue = Catalogue.Load("Songs.txt", "Genres.txt");

            string gNotFound = "";
            
            try
            {
                gNotFound = "Indie";
                
                Console.WriteLine($" === {gNotFound} tracks === ");
                foreach (var track in catalogue.SearchTracksByGenre(gNotFound))
                    Console.WriteLine(track.ToString());
                
                gNotFound = "Rock";
                
                Console.WriteLine($" === {gNotFound} artists === ");
                foreach (var artist in catalogue.SearchArtistsByGenre(gNotFound))
                    Console.WriteLine(artist.ToString());

                int year = 2004;
                Console.WriteLine($" === {gNotFound} tracks of {year} === ");
                foreach (var track in catalogue.SearchTracks(year, gNotFound))
                    Console.WriteLine(track.ToString());
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine($"\nGenre {gNotFound} not found\n");
            }

            Console.WriteLine(" === Oasis === ");
            List<Artist> oasis = catalogue.SearchArtists("Oasis");
            foreach (var artist in oasis)
            {
                Console.WriteLine(artist.ToString());
            }
            
            Console.WriteLine(" === Track compilation contanied pop === ");
            foreach (var tc in catalogue.SearchTrackCompilationsByGenre("Pop"))
                Console.WriteLine(tc.ToString());
        }
    }
}
