using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace הפרוייקט_של_תמי.shows
{
    [Serializable]
    class oldshow:Detailes
    {
        int minage;
        TimeSpan lengthshow;
        int price;

        public oldshow() : base()
        {
        }
        public oldshow( int minage, TimeSpan lengthshow, int price, string name, int code) :
            base(code, name)
        {
            this.minage = minage;
            this.lengthshow = lengthshow;
            this.price = price;
        }
        public int Minage
        {
            get { return minage; }
            set { minage = value; }
        }
        public TimeSpan Lengthshow
        {
            get { return lengthshow; }
            set { lengthshow = value; }
        }
        public int Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new Exception(" הקש מחיר");
            }

        }
    }
}
