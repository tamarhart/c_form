using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace הפרוייקט_של_תמי.workers
{
    [Serializable]
    class worker : manager
    {
        int codehismaneger;
        public worker(int codehismaneger)
        {
            this.codehismaneger = codehismaneger;
        }
        public worker()
        {

        }
        public int Codehismaneger { get => codehismaneger; set => codehismaneger = value; }
        public override double Salary(int numHour)
        {
           double count = Pricetohour * numHour + Numtickets*2;
            return count;
        }
    }
}
