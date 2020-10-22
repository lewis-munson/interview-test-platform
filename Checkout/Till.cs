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
            {'C', 0},
            {'D', 0}
        };

        public double Total() 
        { 
            double total = 0;
            foreach(var item in _items)
            {
                char product = item.Key;
                int amount = item.Value;
                switch (product)
                {
                    case 'A':
                        total += CostForA(amount);
                        break;
                    case 'B':
                        total += CostForB(amount);
                        break;
                    case 'C':
                        total += CostForC(amount);
                        break;
                    case 'D':
                        total += CostForD(amount);
                        break;
                }
            } 
           return total;
        }

        public double CostForA(int items)
        {
            double cost = 50 * items;
            int numberOfTriplets = items / 3;
            double discount = 20 * numberOfTriplets;
            return cost - discount;
        }

        public double CostForB(int items)
        {
            double cost = items * 30;
            int numberOfPairs = items / 2;
            double discount = numberOfPairs * 15;
            return cost - discount;
        }

        public double CostForC(int items)
        {
            return 20 * items;
        }

        public double CostForD(int items)
        {
            return 15 * items;
        }

        public void Scan(string items)
        {
            // TODO: don't allow 7+ of C
            foreach(var item in items)
            {
                _items[item]++;  
            }
        }
    }
}