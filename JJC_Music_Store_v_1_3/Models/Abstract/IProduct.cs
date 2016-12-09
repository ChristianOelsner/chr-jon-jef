using JJC_Music_Store_v_1_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJC_Music_Store_v_1_3.Models.Abstract
{
    public abstract class IProduct
    {

        public string Name { get; set; }
        public int artistID { get; set; }
        public int genreID { get; set; }
        public int Price { get; set; }
        public int ProductID { get; set; }

        public abstract string GetName() ;
        public abstract  int GetID();
        public abstract int GetPrice();
        public abstract int GetArtistID();
        public abstract int GetGenreID();
        




    }
}