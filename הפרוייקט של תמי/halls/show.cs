using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace הפרוייקט_של_תמי.halls
{
    [Serializable]
    class show
    {
        int codeshow;
        int codeapper;
        int codehall;
        int moneplace;
        DateTime date;
        DateTime hour;

        public show(int codeshow, int codeapper, int codehall, DateTime date, DateTime hour,int moneplace)
        {
            this.codeshow = codeshow;
            this.codeapper = codeapper;
            this.codehall = codehall;
            this.date = date;
            this.hour = hour;
            this.moneplace = moneplace;
        }

        public show()
        {
        }

        public int Codeshow { get => codeshow; set => codeshow = value; }
        public int Codeapper { get => codeapper; set => codeapper = value; }
        public int Codehall { get => codehall; set => codehall = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Hour { get => hour; set => hour = value; }
        public int Moneplace { get => moneplace; set => moneplace = value; }
    }
}
