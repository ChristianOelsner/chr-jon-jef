using JJC_Music_Store_v_1_3.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJC_Music_Store_v_1_3.Models.Entity
{
    public class SongModel : IProduct
    {
        public int SongModelID { get; set; }
        public String SongName { get; set; }

        public int ArtistModelID { get; set; }
        public int GenreModelID { get; set; }
        public int Price { get; set; }

        public virtual ArtistModel ArtistModels { get; set; }
        public virtual GenreModel GenreModels { get; set; }


        public override string GetName()
        {
            return SongName;
        }

        public override int GetID()
        {
            return SongModelID;
        }

        public override int GetPrice()
        {
            return Price;
        }

        public override int GetArtistID()
        {
            return ArtistModelID;
        }

        public override int GetGenreID()
        {
            return GenreModelID;
        }
    }
}