using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace הפרוייקט_של_תמי.shows
{
    public partial class addshow : Form
    {
        oldshow os;
        chidrenshow cs;
        List<shows.oldshow> alls= new List<shows.oldshow>();//יכיל את מופע ילדים ומבוגרים

        public addshow()
        {
            InitializeComponent();
            
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
               
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //גיל מקסימלי כן יופיע במופע ילדים
            if (radioButton1.Checked == true)
            {
                label5.Visible = true;
                numericUpDown2.Visible = true;
                numericUpDown1.Minimum = 0;
                numericUpDown1.Value = 0;
                numericUpDown1.Maximum = 16;
                numericUpDown2.Maximum = 17;
                numericUpDown2.Value = 1;
                numericUpDown2.Minimum = 1;
            }
            //else
            //{
            //    label5.Visible = false;
            //    numericUpDown2.Visible = false;
            //    numericUpDown1.Minimum = 18;
            //    numericUpDown1.Value = 18;
            //    numericUpDown1.Maximum = 120;
                
            //}

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numericUpDown4.Value) == 60)
            {
                numericUpDown4.Value = 0;
                numericUpDown3.Value += 1;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                numericUpDown2.Visible = false;
                label5.Visible = false; 
                numericUpDown1.Minimum = 18;
                numericUpDown1.Value = 18;
                numericUpDown1.Maximum = 120;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
                   
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == false && numericUpDown1.Value < 18)
                numericUpDown2.Value = numericUpDown1.Value + 1;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown3.Maximum = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                os = new oldshow();
                if (checkinput1())
                {
                    //הוספה לרשימה
                    lists.oldshow.Add(os);
                    this.Close();
                }
            }
            else
            //יצירת מופע ילדים 
            {
                cs = new chidrenshow();
                if (checkinput2())
                {
                    //הוספה לרשימה
                    lists.chidrenshow.Add(cs);
                    this.Close();
                }
            }

            

        }
        //תקינות מופע ילדים
        public bool checkinput2()
        {
            bool flag = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            errorProvider5.Clear();
            //בדיקת שם
            try
            {
                //בדיקת כפילות שם מופע
                for (int i = 0; i < lists.chidrenshow.Count; i++)
                    if (textBox1.Text == lists.chidrenshow[i].Name)
                        throw new Exception(" שם מופע קים במאגר שמות המופעים");

                for (int i = 0; i < lists.oldshow.Count; i++)
                    if (textBox1.Text == lists.oldshow[i].Name)
                        throw new Exception(" שם מופע קים במאגר שמות המופעים");

                if (legal.IsHebrew(textBox1.Text) || legal.IsEnglishBig(textBox1.Text) || legal.IsEnglishSmall(textBox1.Text))
                    cs.Name = textBox1.Text;
                else
                    throw new Exception("שם לא תקין");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
                flag = false;
            }
            //גיל מינמאלי
            try
            {
                if (Convert.ToInt32(numericUpDown1.Value) > 0)
                    cs.Minage = Convert.ToInt32(numericUpDown1.Value);
                else
                    throw new Exception("הכנס גיל מינמאלי");

            }
            catch (Exception ex)
            {
                errorProvider2.SetError(numericUpDown1, ex.Message);
                flag = false;
            }
            //גיל מקסימלי
            try
            {
                if (Convert.ToInt32(numericUpDown2.Value) >= numericUpDown1.Value && Convert.ToInt32(numericUpDown2.Value) != 0)
                    cs.Maxage = Convert.ToInt32(numericUpDown2.Value);
                else
                    throw new Exception("גיל מינימלי גדול מגיל מקסימלי");

            }
            catch (Exception ex)
            {
                errorProvider4.SetError(numericUpDown2, ex.Message);
                flag = false;
            }
            //מחיר 
            try
            {
                if (!(legal.IsNumber(textBox3.Text)))
                    throw new Exception("הכנס מחיר במספרים");
                else
                    cs.Price = Convert.ToInt32(textBox3.Text); //מכניס הודעה בלי קשר
            }
            catch (Exception ex)
            {
                errorProvider3.SetError(textBox3, ex.Message);
                flag = false;
            }
            //בדיקת אורך
            try
            {
                if ((Convert.ToInt32(numericUpDown4.Text) != 0 && Convert.ToInt32(numericUpDown3.Text) != 0) || (Convert.ToInt32(numericUpDown4.Text) == 0 && Convert.ToInt32(numericUpDown3.Text) != 0) || (Convert.ToInt32(numericUpDown4.Text) != 0 && Convert.ToInt32(numericUpDown3.Text) == 0))
                    cs.Lengthshow = new TimeSpan(Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value), 0);
                else
                    throw new Exception("הכנס אורך מופע");
            }
            catch (Exception ex)
            {
                errorProvider5.SetError(numericUpDown3, ex.Message);
                flag = false;
            }

            cs.Code = Convert.ToInt32(textBox2.Text);
            return flag;
        }
        public bool checkinput1()
        {
            bool flag = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();
            try
            {
                //בדיקת כפילות שם מופע
                for (int i = 0; i < lists.oldshow.Count; i++)
                    if (textBox1.Text == lists.oldshow[i].Name)
                        throw new Exception("שם מופע קים במאגר שמות המופעים");
                for (int i = 0; i < lists.chidrenshow.Count; i++)
                    if (textBox1.Text == lists.chidrenshow[i].Name)
                        throw new Exception("שם מופע קים במאגר שמות המופעים");

                if (legal.IsHebrew(textBox1.Text) || legal.IsEnglishBig(textBox1.Text) || legal.IsEnglishSmall(textBox1.Text))
                    os.Name = textBox1.Text;
                else
                    throw new Exception("שם לא תקין");

            }
            catch(Exception ex)
            {
                errorProvider1.SetError(button1, ex.Message);
                flag = false;
            }
            //גיל מינמאלי
            try
            {
                if (Convert.ToInt32(numericUpDown1.Value) > 0 )
                    os.Minage = Convert.ToInt32(numericUpDown1.Value);
                else
                    throw new Exception("הכנס גיל מינמאלי");

            }
            catch (Exception ex)
            {
                errorProvider2.SetError(numericUpDown1, ex.Message);
                flag = false;
            }
            //בדיקת מחיר
            try
            {
                if (!(legal.IsNumber(textBox3.Text)))
                    throw new Exception("הכנס מחיר במספרים");
                else
                    os.Price = Convert.ToInt32(textBox3.Text); //מכניס הודעה בלי קשר
            }
            catch (Exception ex)
            {
                errorProvider3.SetError(textBox3, ex.Message);
                flag = false;
            }
            //בדיקת אורך
            try
            {
                if (Convert.ToInt32(numericUpDown3.Text) == 0 && Convert.ToInt32(numericUpDown4.Text) == 0)
                    throw new Exception("הכנס אורך מופע");
                else
                    os.Lengthshow = new TimeSpan(Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown4.Value), 0);
            }
            catch (Exception ex)
            {
                errorProvider4.SetError(numericUpDown3, ex.Message);
                flag = false;
            }
            os.Code = Convert.ToInt32(textBox2.Text);
            return flag;
        }

        private void addshow_Load(object sender, EventArgs e)
        {
            alls.AddRange(lists.oldshow);
            alls.AddRange(lists.chidrenshow);
            if(alls.Count==0)
            textBox2.Text = "1";
            else
                textBox2.Text =Convert.ToString(alls.Count+1);
            

            //גיל מקסימלי לא יופיע במופע מבוגרים

            if (radioButton2.Checked==true)
            {
                label5.Visible = false;
                numericUpDown2.Visible = false;
            }
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
