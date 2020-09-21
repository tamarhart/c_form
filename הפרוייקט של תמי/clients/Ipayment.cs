using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace הפרוייקט_של_תמי.clients
{
    interface Ipayment
    {
        //חישוב לתשלום-זה מחייב שזה יקרה!!!
        double paymentcards(int numofcards, int codeshow);
    }
}
