using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace הפרוייקט_של_תמי
{
    [Serializable]
    abstract class Detailes
    {
        string name;
        int code;
        public Detailes()
        {

        }
        public Detailes(int code,string name)
        {
            this.code = code;
            this.name = name;
        }
        public int Code {
            get { return code; }
            set
            {
                if (value > 0)
                    code = value;
                else
                    throw new Exception("הקש קוד");
            }

        }

        public string Name
        {
            get => name;
            set
            {
                if (value != "")
                    name = value;
                else
                    throw new Exception("הקש שם");

            }
        }

    }
}
