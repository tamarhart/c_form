using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace הפרוייקט_של_תמי.workers
{
    public partial class addwarker : Form
    {
        worker w;
        manager m;
        public addwarker()
        {
            InitializeComponent();
        }
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //אם זהו עובד מסוג עובד אז תוצג רשימת מנהלים
            try
            {
                if (lists.manager.Count > 0)
                {
                    label5.Visible = true;
                    comboBox1.Visible = true;
                    
                }
                else
                    throw new Exception("לא ניתן להכניס שם עובד לפני שיש לפחות מנהל אחד ברשימה");
            }
            catch(Exception ex)
            {
                errorProvider4.SetError(radioButton2, ex.Message);

            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            if (radioButton2.Checked == true)
            {
                //יצירת אוביקט עובד
                w = new worker();
                if (chekinput2())
                {
                    //הוספה לרשימה

                    lists.worker.Add(w);
                   this.Close();//או פס טעינה או ליסגור קובץ
                }
            }
            else
            {
                //יצירת אוביקט מנהל
                m = new manager();
                if (chekinput())
                {
                    //הוספה לרשימה
      
                    lists.manager.Add(m);
                     this.Close();//או פס טעינה או ליסגור קובץ

                }
            }
        
            
        }
        public bool chekinput()
        {
            bool flag = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            //שם
            try
            {
                if (legal.IsHebrew(textBox1.Text) || legal.IsEnglishBig(textBox1.Text) || legal.IsEnglishSmall(textBox1.Text))
                    m.Name = textBox1.Text;
                else
                    throw new Exception("השם שהוכנס אינו תקין");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
                flag = false;
            }
            //תעודת זהות
            try
            {
                //בדיקה שת"ז לא קימת במאגר
                for (int i = 0; i < lists.manager.Count; i++)
                    if (Convert.ToInt32(textBox2.Text) == lists.manager[i].Code)
                        throw new Exception("תעודת זהות כבר קימת במאגר עובדים");

                for (int i = 0; i < lists.worker.Count; i++)
                    if (Convert.ToInt32(textBox2.Text) == lists.worker[i].Code)
                       throw new Exception("תעודת זהות כבר קימת במאגר עובדים");
                if (legal.IsNumber(textBox2.Text))
                    m.Code = Convert.ToInt32(textBox2.Text);
                else
                   throw new Exception("תז לא תקינה");
            }
            catch (Exception ex)
            {
                errorProvider2.SetError(textBox2, ex.Message);
                flag = false;
            }
            //שכר
            try
            {
                if (legal.IsNumber(textBox3.Text))
                {
                    m.Pricetohour = Convert.ToInt32(textBox3.Text);
                }
                else
                {
                    throw new Exception("הכנס שכר במספרים");
                }
            }

            catch (Exception ex)
            {
                errorProvider3.SetError(textBox3, ex.Message);
                flag = false;
            }
            return flag;
        }

        public bool chekinput2()
        {
            bool flag = true;
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            try
            {
                if (legal.IsHebrew(textBox1.Text) || legal.IsEnglishSmall(textBox1.Text) || legal.IsEnglishBig(textBox1.Text))
                    w.Name = textBox1.Text;
                else
                    throw new Exception("השם  אינו תקין");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(textBox1, ex.Message);
                flag = false;
            }
            //תעודת זהות
            try
            {
                //בדיקה שת"ז לא קימת במאגר
                for (int i = 0; i < lists.worker.Count; i++)
                    if (Convert.ToInt32(textBox2.Text) == lists.worker[i].Code)
                        throw new Exception("תעודת זהות כבר קימת במאגר עובדים");
                for (int i = 0; i < lists.manager.Count; i++)
                   if (Convert.ToInt32(textBox2.Text) == lists.manager[i].Code)
                        throw new Exception("תעודת זהות כבר קימת במאגר עובדים");
                if (legal.IsNumber(textBox2.Text))
                    w.Code = Convert.ToInt32(textBox2.Text);
                else
                   throw new Exception("תז לא תקינה");
            }
            catch (Exception ex)
            {
                errorProvider2.SetError(textBox2, ex.Message);
                flag = false;
            }
            try
            {
                if (legal.IsNumber(textBox3.Text))
                {
                    w.Pricetohour = Convert.ToInt32(textBox3.Text);
                }
                else
                {
                    throw new Exception("הכנס שכר במספרים");
                }
            }
            catch(Exception ex)
            {
                errorProvider3.SetError(textBox3, ex.Message);
                flag = false;
            }
            //תקינות מנהל של עובד
            try
            {
                if (comboBox1.Text == "")
                    throw new Exception("בחר מנהל");
                else
                    w.Codehismaneger = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            }

            catch (Exception ex)
            {
                errorProvider3.SetError(comboBox1, ex.Message);
                flag = false;
            }
            //w.Pricetohour = Convert.ToInt32(textBox3.Text);
            return flag;


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider4.Clear();
            label5.Visible =false;
            comboBox1.Visible = false;

        }

        private void addwarker_Load(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            label5.Visible = false;
            //בהופעת פורום הוספת עובד הרשימה של המנהלים תופיע
            comboBox1.DataSource = lists.manager;
            comboBox1.ValueMember = "code";
            comboBox1.DisplayMember="name";
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
