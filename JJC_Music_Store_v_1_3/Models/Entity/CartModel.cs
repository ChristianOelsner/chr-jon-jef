using JJC_Music_Store_v_1_3.Models.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJC_Music_Store_v_1_3.Models.Entity
{
    public class CartModel
    {
        public int Price { get; set; }

       

        public List<IProduct> Products { get; set; } = new List<IProduct>() ;

        
    }

  
}