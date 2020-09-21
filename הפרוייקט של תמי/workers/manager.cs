using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace הפרוייקט_של_תמי.workers
{
    [Serializable]
    class manager : Detailes,Isalary
    {
        int pricetohour;
        int numtickets;
        public manager(int pricetohour, int numtickets)
        {
            this.pricetohour = pricetohour;
            this.numtickets = numtickets;
        }
        public manager()
        {
        }
        public int Pricetohour { get => pricetohour; set => pricetohour = value; }
        public int Numtickets { get => numtickets; set => numtickets = value; }
        //חישוב שכר
        public virtual double Salary(int numHour)
        {
         double count;
         count=pricetohour*numHour+numtickets;
            if (numtickets > 1000)
                count += 1000;
            return count;
        }

    }
}