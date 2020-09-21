using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace הפרוייקט_של_תמי.halls
{
    [Serializable]
    class Hall
    {
        int codehole;
        int numplace;

        public Hall(int codehole, int numplace)
        {
            this.Codehole = codehole;
            this.Numplace = numplace;
        }
        public Hall()
        {
        }
        public int Codehole { get => codehole; set => codehole = value; }
        public int Numplace { get => numplace; set => numplace = value; }
    }
}
