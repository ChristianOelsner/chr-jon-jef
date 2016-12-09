using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJC_Music_Store_v_1_3.Models.Entity
{
    public class AlbumModel
    {
        public int AlbumModelID { get; set; }
        public String AlbumName { get; set; }

        public int ArtistModelID { get; set; }
        public int GenreModelID { get; set; }
        public int Price { get; set; }

        public virtual ArtistModel ArtistModels { get; set; }
        public virtual GenreModel GenreModels { get; set; }



    }
}