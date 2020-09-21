using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace הפרוייקט_של_תמי.halls
{
    public partial class addplay : Form
    {
        DateTime time;
        TimeSpan Length, Length1;
        show play;
        List<shows.oldshow> alls = new List<shows.oldshow>();//רשימה של כל המופעים גם של ילדים וגם של מבוגרים
        List<int> lo = new List<int>();
        public addplay()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //  בקומבובוקס רשימת מופעי מבוגרים
            if (radioButton1.Checked == true)
            {
                comboBox2.Enabled = true;
                comboBox2.DataSource = lists.oldshow;
                comboBox2.ValueMember = "code";
                comboBox2.DisplayMember = "name"; 
                comboBox2.Text = " ";
            }

            //  בקומבובוקס רשימת מופעי ילדים
            //else
            //{
            //    comboBox2.DataSource = lists.chidrenshow;
            //    comboBox2.ValueMember = "code";
            //    comboBox2.DisplayMember = "name";
            //}
           // comboBox1.Text = " ";
            //comboBox3.Text = " ";
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                comboBox2.Enabled = true;
                comboBox2.DataSource = lists.chidrenshow;
                comboBox2.ValueMember = "code";
                comboBox2.DisplayMember = "name"; 
                comboBox2.Text = " ";
              
            }
        }

        private void addplay_Load(object sender, EventArgs e)
        {
            label8.Text = " ";
            comboBox3.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            // קוד
            //alls.AddRange(lists.oldshow);
            //alls.AddRange(lists.chidrenshow);
            if (lists.show.Count == 0)
                textBox1.Text = "1";
            else
                textBox1.Text = Convert.ToString(lists.show.Count + 1);
            //תאריך מינימלי
            dateTimePicker1.MinDate = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            //comboBox2.DataSource = lists.oldshow;
            //comboBox2.ValueMember = "code";
            //comboBox2.DisplayMember = "name";
            //time = new DateTime(2018, 1, 1, 0,0, 0);
            //comboBox3.Items.Add(time.ToShortTimeString());


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //הצגת מספר  מקומות ליד שם אולם
            for (int k = 0; k < lists.hall.Count; k++)
            {
                if (lists.hall[k].Codehole == Convert.ToInt32(comboBox1.Text))
                {
                    label8.Text = lists.hall[k].Numplace.ToString();
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            errorProvider1.Clear();
            // הכנסת השעה שנבחרה לתוך אוביקט
            //    DateTime dt = Convert.ToDateTime(comboBox3.SelectedItem.ToString());
            comboBox1.Items.Clear();
            comboBox1.Text = " ";
            lo.Clear(); 
            //בדיקת השעה
            tocheck();
            int b = 0;
            int flag = 0;
            for(int i=0; i<lists.hall.Count; i++)
            {
                for(int j=0; j<lo.Count; j++)
                {
                    if (lo[j].Equals(lists.hall[i].Codehole))
                    {
                        flag = 1;
                        break;
                    }
                }
                if(flag==0)
                {
                    comboBox1.Items.Add(lists.hall[i].Codehole);
                    b += 1;
                }
                else
                    flag = 0;
            }
            if(b==0)
            {
                if (lists.hall.Count > 0)
                    errorProvider1.SetError(label6, "כל האולמות תפוסים בשעה זו יש לנסות שעה אחרת!!!");
                else
                    errorProvider1.SetError(label6, "יש להוסיף אולם לפני הוספת מופע");
            }
            comboBox1.Enabled = true;
            

            
           

        }
        public void tocheck()
        {
            
            alls.AddRange(lists.oldshow);
            alls.AddRange(lists.chidrenshow);
            for (int i = 0; i < alls.Count; i++)
            {
                if (comboBox2.Text == alls[i].Name)
                {
                   Length = alls[i].Lengthshow;
                }
                // comboBox1.Items.Add(lists.hall[i].Codehole);
            }
          
            foreach (show item in lists.show)
            {
                if (item.Hour == Convert.ToDateTime(comboBox3.Text))
                {
                    lo.Add(item.Codehall);
                }
                else
                {
                    if ((item.Hour) < Convert.ToDateTime(comboBox3.Text) + Length)
                    {
                        for (int i = 0; i < alls.Count; i++)
                        {
                            if (item.Codeshow== alls[i].Code)
                            {
                               Length1 = alls[i].Lengthshow;
                            }
                        }
                        if (item.Hour + Length1 > Convert.ToDateTime(comboBox3.Text))
                            lo.Add(item.Codehall);
                    } 

                }
                
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != " " && comboBox2.Text != " " && comboBox3.Text != " ")
            {
                //יצירת אוביקט מסוג הצגה והוספה לרשימה
                play = new show();
                play.Codeapper = Convert.ToInt32(textBox1.Text);
                play.Date = dateTimePicker1.Value;
                play.Codeshow = Convert.ToInt32(comboBox2.SelectedValue);
                play.Codehall = Convert.ToInt32(comboBox1.Text);
                play.Hour = Convert.ToDateTime(comboBox3.Text);
                lists.show.Add(play);
                this.Close();
            }
            else
                MessageBox.Show("נתונים חסרים");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            for (int i = 8; i<21; i+=1)
            {
                for (int j = 0; j<60; j+=15)
                {
                    time = new DateTime(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month, dateTimePicker1.Value.Day, i, j, 0);
                    comboBox3.Items.Add(time.ToShortTimeString());
                }
            }
            comboBox3.Enabled = true;
            comboBox3.Text = " ";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
