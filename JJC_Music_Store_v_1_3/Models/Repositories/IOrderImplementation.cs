using JJC_Music_Store_v_1_3.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JJC_Music_Store_v_1_3.Models.Entity;

namespace JJC_Music_Store_v_1_3.Models.Repositories
{
    public class IOrderImplementation : IOrder
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public bool Delete(int? id)
        {
            if (id > 0) // if a student is a new student its key will be 0
            {
                OrderModel order = db.OrderModels.Find(id);
                db.OrderModels.Remove(order);
                db.SaveChanges();
                return true;

            }

            return false;
        }

        public OrderModel Find(int? id)
        {
           return db.OrderModels.Find(id);
            
        }

        public List<OrderModel> GetAll()
        {
            return db.OrderModels.ToList();
        }

        public void InsertOrUpdate(OrderModel order)
        {
            if (order.OrderModelID <= 0) // if a student is a new student its key will be 0
            {
                db.OrderModels.Add(order);

            }
            else
            {
                db.Entry(order).State = System.Data.Entity.EntityState.Modified;

            }

            db.SaveChanges();
        }

        public OrderModel Search(string search)
        {
            throw new NotImplementedException();
        }
    }
}