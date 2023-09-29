using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BethanysPieShop.InventoryManagement
{
    public class Product
    {
        private int _id;
        private string _name = string.Empty;
        private string? _description;

        private int _maxItemsInStock = 0;

    }
}
