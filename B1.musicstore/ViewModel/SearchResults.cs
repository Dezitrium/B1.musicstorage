using B1.musicstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B1.musicstore.ViewModel
{
    public class SearchResults
    {
        private List<Genre> _genres;
        private List<Album> _albums;
        private List<Artist> _artists;

        public Boolean forGenre { get; private set; }
        public Boolean forAlbum { get; private set; }
        public Boolean forArtist { get; private set; }

        public int CountAll
        {
            get {
                int count = 0;
                if (Genres != null)
                    count += Genres.Count();
                if (Albums != null)
                    count += Albums.Count();
                if (Artists != null)
                    count += Artists.Count();
                return count; }
        }
        


        public List<Genre> Genres
        {
            get { return _genres; }
            set { 
                _genres = value;
                forGenre = true;
            }
        }        

        public List<Album> Albums
        {
            get { return _albums; }
            set
            {
                _albums = value;
                forAlbum = true;
            }
        }       

        public List<Artist> Artists
        {
            get { return _artists; }
            set
            {
                _artists = value;
                forArtist = true;
            }
        }
    }
}