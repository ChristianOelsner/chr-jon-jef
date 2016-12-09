using JJC_Music_Store_v_1_3.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJC_Music_Store_v_1_3.Models.Abstract
{
   public interface IOrder
    {
        List<OrderModel> GetAll();

        OrderModel Find(int? id);

        void InsertOrUpdate(OrderModel order);

        Boolean Delete(int? id);

        OrderModel Search(string search);
    }
}
