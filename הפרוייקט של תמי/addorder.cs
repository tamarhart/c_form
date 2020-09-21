using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace הפרוייקט_של_תמי
{
    public partial class addorder : Form
    {
        DateTime time;
        List<clients.privateclient> allclients = new List<clients.privateclient>();
        List<shows.oldshow> all = new List<shows.oldshow>();
        public addorder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //תקינות נתונים
            if (comboBox1.Text != " " && comboBox2.Text != " " && comboBox3.Text != " " && comboBox4.Text != " " && numericUpDown1.Value > 0 && numericUpDown2.Value > 0)
            {
                //הוספת מס' כרטיסים ללקוח
                for (int i = 0; i < allclients.Count; i++)
                {
                    if (Convert.ToInt32(comboBox4.Text) == allclients[i].Code)
                        allclients[i].Numofcards += (Convert.ToInt32(numericUpDown2.Value));
                }
                for (int i = 0; i < all.Count; i++)
                {
                    for (int j = 0; j < lists.show.Count; j++)
                    {
                        if (all[i].Code == Convert.ToInt32(lists.show[j].Codeshow))
                            if (lists.show[j].Codehall == Convert.ToInt32(comboBox3.Text))
                                lists.show[j].Moneplace += Convert.ToInt32(numericUpDown1.Value);
                    }
                }
                //   והוספת מספר כרטיסים שמכר עובד -לעובד ולמנהל
                for (int i = 0; i < lists.worker.Count; i++)
                {
                    if (Convert.ToInt32(comboBox3.Text) == lists.worker[i].Code)
                    {
                        lists.worker[i].Numtickets += Convert.ToInt32(numericUpDown2.Value);
                        for (int j = 0; j < lists.manager.Count; j++)
                        {
                            if (lists.worker[i].Codehismaneger == lists.manager[j].Code)
                                lists.manager[j].Numtickets += Convert.ToInt32(numericUpDown2.Value);
                        }
                    }
                }
                this.Close();
            }
            else
                MessageBox.Show("נתונים חסרים");


        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        { ////שם לקוח
            if (comboBox4.Text != " ")
            {
                for (int i = 0; i < allclients.Count; i++)
                {
                    if (Convert.ToInt32(comboBox4.Text) == allclients[i].Code)
                    {
                        label9.Text = allclients[i].Name;
                        label9.Visible = true;
                    }
                }
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                comboBox1.Enabled = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            if (numericUpDown1.Value > 0)
            {
                comboBox1.Items.Clear();
                if (numericUpDown1.Value < 18)
                {
                    for (int i = 0; i < lists.chidrenshow.Count; i++)
                    {
                        for (int j = 0; j < lists.show.Count; j++)
                        {
                            if (lists.chidrenshow[i].Code == lists.show[j].Codeshow)
                            {
                                comboBox1.Items.Add(lists.chidrenshow[i].Name);
                                break;
                            }

                        }
                    }
                }
                else
                {
                    comboBox1.Items.Clear();
                    for (int i = 0; i < lists.oldshow.Count; i++)
                    {
                        for (int j = 0; j < lists.show.Count; j++)
                        {
                            if (lists.oldshow[i].Code == lists.show[j].Codeshow)
                            {
                                comboBox1.Items.Add(lists.oldshow[i].Name);
                                break;
                            }
                        }
                    }
                }
            }
            



        }

        private void addorder_Load(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 1;
            numericUpDown1.Value = 1;
            numericUpDown2.Minimum = 1;
            numericUpDown2.Value = 1;
            numericUpDown1.Enabled= false;
            numericUpDown2.Enabled = false;
            allclients.AddRange(lists.privateclient);
            allclients.AddRange(lists.businessclient);
            for(int i=0; i<allclients.Count;i++)
            {
                comboBox4.Items.Add(allclients[i].Code);
            }
            comboBox4.Text = " ";
            comboBox1.Items.Clear();
            comboBox1.Enabled = false;
            comboBox2.Enabled = true;
            comboBox3.Enabled = false;
            all.Clear();
            all.AddRange(lists.oldshow);
            all.AddRange(lists.chidrenshow);
            for (int i = 0; i < lists.chidrenshow.Count; i++)
            {
                for (int j = 0; j < lists.show.Count; j++)
                {
                    if (lists.chidrenshow[i].Code == lists.show[j].Codeshow)
                    {
                        comboBox1.Items.Add(lists.chidrenshow[i].Name);
                        break;
                    }

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            int cd=0;
         
            if(comboBox1.Text!=" ")
            {
                comboBox2.Items.Clear();
                for (int i=0; i<all.Count; i++)
                {
                    if (all[i].Name == comboBox1.Text)
                        cd=all[i].Code;
                }
                for (int i = 0; i < lists.show.Count; i++)
                {
                    if (lists.show[i].Codeshow == cd)
                    {
                        time = new DateTime(lists.show[i].Date.Year, lists.show[i].Date.Month, lists.show[i].Date.Day, lists.show[i].Hour.Hour, lists.show[i].Hour.Minute, lists.show[i].Hour.Second);
                        comboBox2.Items.Add(time);

                    }

                }
              comboBox2.Enabled = true;
            }
           

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = 0;
            int h = 0;
            if (comboBox2.Text != " ")
            {
                errorProvider1.Clear();
                comboBox3.Items.Clear();
                comboBox3.Enabled=true;
                int c=0;//שומר את קוד המופע לפי שם המופע שבחרתי
                for(int j=0; j<all.Count; j++)
                {
                    if (comboBox1.Text == all[j].Name)
                        c=all[j].Code;
                }
                for (int i = 0; i < lists.show.Count; i++)
                {

                    time = new DateTime(lists.show[i].Date.Year, lists.show[i].Date.Month, lists.show[i].Date.Day, lists.show[i].Hour.Hour, lists.show[i].Hour.Minute, lists.show[i].Hour.Second);//שומר את זמן ההצגה
                    if (time == Convert.ToDateTime(comboBox2.Text) && lists.show[i].Codeshow==c)//בודק האם הזמן שבחרתי זהה לזמן של ההצגה(או לאחד הזמנים) וכן בודק האם הקוד שבחרתי זהה לקוד ההצגה הזו(שזו בעצם הבדיקה החשובה)
                    {
                        for (int t = 0; t < lists.hall.Count; t++)
                        {
                            if (lists.hall[t].Codehole == lists.show[i].Codehall)
                            {
                                num = lists.hall[t].Numplace;//שומר את מס המקומות שיש באולם זה
                                if (lists.show[i].Moneplace + numericUpDown2.Value < num)
                                {
                                    comboBox3.Items.Add(lists.show[i].Codehall);
                                    ////עידכון מקומות שהתמלאו בהצגה הזו
                                    //lists.show[i].Moneplace += Convert.ToInt32(numericUpDown2.Value);
                                    h += 1;//מונה כמה אולמות הוספתי כדי שאחכ אוכל לישאול האם מס האולמות שהוספתי גדול מ-0
                                }
                            }
                        }
                    }
                }
                if (h == 0)
                    errorProvider1.SetError(comboBox3, "מס הכרטיסים גדול ממס המקומות");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numofcards = Convert.ToInt32(numericUpDown2.Value);
            int codeshows=0;
            double price=0;
            for (int i = 0; i < all.Count; i++)
            {
                if (comboBox1.Text == all[i].Name)
                {
                    for (int j = 0; j < lists.show.Count; j++)
                    {
                        if (all[i].Code == lists.show[j].Codeshow)
                            codeshows = lists.show[j].Codeshow;
                     }
                }

            }
           
            for (int i = 0; i < allclients.Count; i++)
            {
                if (Convert.ToInt32(comboBox4.Text) == allclients[i].Code)
                {
                    price = allclients[i].paymentcards(numofcards, codeshows);
                    break;
                }


            }
            MessageBox.Show("הסכום לתשלום: " + price);

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

            comboBox1.Text = " ";
            comboBox2.Text = " ";
            comboBox3.Text = " ";
            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            errorProvider1.Clear();
                comboBox1.Enabled = true;
            
        }
    }
}
