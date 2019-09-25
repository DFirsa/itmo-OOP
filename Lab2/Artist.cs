using System.Collections.Generic;

namespace Lab2
{
    public class Artist
    {
        public readonly string name;
        public readonly List<Album> albumList;

        public Artist(string name)
        {
            this.name = name;
            albumList = new List<Album>();
        }

        public void AddAlbum(Album album)
        {
            albumList.Add(album);
        }

        public Album GetAlbum(string name)
        {
            foreach (var album in albumList)
                if (album.name.ToLower().Trim().Equals(name.ToLower().Trim()))
                    return album;

            return null;
        }

        public override string ToString()
        {
            return name;
        }
    }
}