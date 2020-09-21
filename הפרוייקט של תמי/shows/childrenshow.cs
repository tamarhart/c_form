using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace הפרוייקט_של_תמי.shows
{
    [Serializable]
    class chidrenshow:oldshow
    {
        int maxage;

        public int Maxage { get => maxage; set => maxage = value; }
        public chidrenshow() : base()
        {
        }
        public chidrenshow(string name, int code, int minage, TimeSpan lengthshow, int price, int maxage)
            : base(minage, lengthshow, price, name, code)
        {
            this.Maxage = maxage;
        }

        
    }
}
