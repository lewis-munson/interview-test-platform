using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkout
{
    public class Till
    {

        private Dictionary<char, int> _items = new Dictionary<char, int>{
            {'A', 0},
            {'B', 0},
            {'C', 0}
        };

        public double Total() 
        { 
            double total = 0;
            foreach(var item in _items)
            {
                if(item.Key.Equals('A'))
                {
                    total += 50 * item.Value;
                }
                else if(item.Key.Equals('B'))
                {
                    total += AddB(item.Value.ToString());
                } 
                else if(item.Key.Equals('C'))
                {
                    total = AddItemC(total, item);
                }
                else total = AddItemD(total, item);
            } 
           return total;
        }

        static double AddItemD(double total, KeyValuePair<char, int> item)
        {
            if (item.Key.Equals('D'))
            {
                total += 15 * item.Value;
            }

            return total;
        }


        private static double AddItemC(double total, KeyValuePair<char, int> item)
        {
            if (item.Key.Equals('C'))
            {
                total += 15 * item.Value;
            }

            return total;
        }

        public double AddB(string numberItems)
        {
            double items = Double.Parse(numberItems);

            if(items == 0) return 0;

            var cost = items * 30;
            var numberOfPairs =  items / 2;

            // discount is 15 on each pair
            var discount = numberOfPairs * 15;
            return cost - discount;
        }

        public void Scan(string items)
        {
            foreach(var item in items)
            {
                _items[item]++;  
            }
        }
    }
}