using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
namespace הפרוייקט_של_תמי
{
    [Serializable]
    abstract class lists
    {
        static BinaryFormatter bf = new BinaryFormatter();
        public static string path = @"filessssss\";
        public static List<clients.privateclient> privateclient = new List<clients.privateclient>();

        public static List<clients.businessclient> businessclient = new List<clients.businessclient>();

        public static List<halls.Hall> hall = new List<halls.Hall>();

        public static List<halls.show> show = new List<halls.show>();

        public static List<workers.manager> manager = new List<workers.manager>();

        public static List<workers.worker> worker = new List<workers.worker>();

        public static List<shows.chidrenshow> chidrenshow = new List<shows.chidrenshow>();

        public static List<shows.oldshow> oldshow = new List<shows.oldshow>();

        public static void SaveData()
        {//שמירת הנתונים מהרשימה לקובץ
            //saveEach(privateCustomer,"privateCustomer");
            FileStream outstream = new FileStream(path + "privateclient", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(outstream, privateclient);
            outstream.Close();
            outstream = new FileStream(path + "businessclient", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(outstream, businessclient);
            outstream.Close();
            outstream = new FileStream(path + "hall", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(outstream, hall);
            outstream.Close();
            outstream = new FileStream(path + "worker", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(outstream, worker);
            outstream.Close();
            outstream = new FileStream(path + "manager", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(outstream, manager);
            outstream.Close();
            outstream = new FileStream(path + "show", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(outstream, show);
            outstream.Close();
            outstream = new FileStream(path + "childrenShow", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(outstream, chidrenshow);
            outstream.Close();
            outstream = new FileStream(path + "oldShow", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(outstream, oldshow);
            outstream.Close();
        }
        public static void OpenData()
        {
            DirectoryInfo di = new DirectoryInfo(@"filessssss");  //אם קים כבר קובץ -פותח אותו ואם לא אז יוצר חדש
            if (di.Exists)
                DoOpen();
            else
                di.Create();
        }
        public static void DoOpen()
        {
            FileStream instream = new FileStream(path + "privateclient", FileMode.Open);
            privateclient = (List<clients.privateclient>)bf.Deserialize(instream);
            instream.Close();

            instream = new FileStream(path + "businessclient", FileMode.Open);
            businessclient = (List<clients.businessclient>)bf.Deserialize(instream);
            instream.Close();

            instream = new FileStream(path + "hall", FileMode.Open);
            hall = (List<halls.Hall>)bf.Deserialize(instream);
            instream.Close();

            instream = new FileStream(path + "worker", FileMode.Open);
            worker = (List<workers.worker>)bf.Deserialize(instream);
            instream.Close();

            instream = new FileStream(path + "manager", FileMode.Open);
            manager = (List<workers.manager>)bf.Deserialize(instream);
            instream.Close();

            instream = new FileStream(path + "show", FileMode.Open);
            show = (List<halls.show>)bf.Deserialize(instream);
            instream.Close();

            instream = new FileStream(path + "childrenShow", FileMode.Open);
            chidrenshow = (List<shows.chidrenshow>)bf.Deserialize(instream);
            instream.Close();

            instream = new FileStream(path + "oldShow", FileMode.Open);
            oldshow = (List<shows.oldshow>)bf.Deserialize(instream);
            instream.Close();
        }
    }
}


