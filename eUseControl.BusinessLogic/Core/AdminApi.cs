using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.Domain.Entities.Admin;
using eUseControl.BusinessLogic.DbModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace eUseControl.BusinessLogic.Core
{
    public class AdminApi
    {
        internal ProdResp InsertProduct(Product prod)
        {
            int result;
            using (var db = new UserContext())
            {
                db.Products.Add(prod);
                result = db.SaveChanges();
            }
            if (result == 0)
            {
                return new ProdResp
                {
                    Status = false,
                    StatusMsg = "Produsule nu s-a salvat."
                };
            }
            return new ProdResp { Status = true };
        }
        internal List<Product> GetProducts()
        {
            using (var db = new UserContext())
            {
                var result = db.Products.Select(x => x).ToList<Product>();
                return result;
            }
        }
    }
}
