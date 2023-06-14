using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Core;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Admin;

namespace eUseControl.BusinessLogic
{
    public class ProductBL : AdminApi, IProduct
    {
        public ProdResp Insert(Product prod)
        {
            return InsertProduct(prod);
        }
        public List<Product> Get()
        {
            return GetProducts();
        }
    }
}
