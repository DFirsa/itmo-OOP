namespace Lab2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Catalogue catalogue = Catalogue.Load("..\\..\\Songs.txt", "..\\..\\Genres.txt");
            catalogue.ShowArtists();
        }
    }
}