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

        private UnitType _unitType;
        private int _amountInStock = 0;
        private bool _isBelowStockTreshold = false;

        public void UseProduct(int items)
        {
            if (items <= _amountInStock)
            {
                //use the items
                _amountInStock -= items;

                UpdateLowStock();

                Log($"Amount in stock updated. Now {_amountInStock} items in stock.");
            }
            else
            {
                Log($"Not enough items on stock for {CreateSimpleProductRepresentation()}. {_amountInStock} available but {items} requested.");
            }
        }

        public string DisplayDetailsShort()
        {
            return $"{_id}. {_name} \n{_amountInStock} items in stock";
        }

        public string DisplayDetailsFull()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{_id} {_name} \n{_description}\n{Price}\n{_amountInStock} item(s) in stock");

            if (_isBelowStockTreshold)
            {
                sb.Append("\n!!STOCK LOW!!");
            }

            return sb.ToString();

            //return DisplayDetailsFull("");
        }

        public void IncreaseStock()
        {
            _amountInStock++;
        }

        private void UpdateLowStock()
        {
            if (_amountInStock < 10)
            {
                _isBelowStockTreshold = true;
            }
        }

        public void Log(string message)
        {
            // this could be written to a file
            Console.WriteLine(message);
        }

        private string CreateSimpleProductRepresentation()
        {
            return $"Product {_id} ({_name})";

        }
    }
}
