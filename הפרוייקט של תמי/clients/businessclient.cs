using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace הפרוייקט_של_תמי.clients
{
    [Serializable]
    class businessclient : privateclient
    {
        public businessclient()
        {
        }

        public businessclient(int numofcards, int code, string name) : base(numofcards, code, name)
        {
        }
        //חישוב לתשלום
        public override double paymentcards(int numofcards, int codeshow)
        {
            int flag = 0;
            double price = 0, discount, finallyprice, half;
            List<shows.oldshow> allshows = new List<shows.oldshow>();
            allshows.AddRange(lists.oldshow);
            allshows.AddRange(lists.chidrenshow);
            for (int i = 0; i < allshows.Count; i++)
            {
                if (allshows[i].Code == codeshow)
                    price = allshows[i].Price;

            }
            price *= numofcards;
            half = price / 2;
            discount = ((numofcards / 100) * 5) / 100.0;
            finallyprice = price - discount;
            if (finallyprice < half)
            {
                finallyprice = half;
            }
            return finallyprice;

        }

    }
}
