using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WP_ÖDEV
{
    public partial class Giriş : Form
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        string şifre = "123456";
        Form y;
        public Giriş(Yükleniyor y)
        {
            InitializeComponent();
            this.y = y;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            personelal();
            y.Visible = false;
        }
        private void personelal()
        {

            comboBox1.DataSource = from p in db.PERSONELs
                                   orderby p.PersonelAdı
                                   where p.Durum.Equals("Çalışıyor")
                                   select p.PersonelAdı;
            comboBox1.SelectedItem = null;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedItem = null;
            }
            else
                comboBox1.Enabled = true;
        }

        private void giris_Click(object sender, EventArgs e)
        {
            Form newf = new Yükleniyor("İşleniyor", 2);
            Form newf1 = new Yükleniyor("İşleniyor", 1);
            this.Visible = false;
            newf.ShowDialog();
            if(radioButton1.Checked==true)
            {
                if (textBox1.Text.Equals(şifre))
                {
                    textBox1.Text = null;
                    Form newform = new Yönetici(db);
                    this.Visible = false;
                    newform.ShowDialog();
                    newf1.ShowDialog();
                    this.Visible = true;
                    personelal();
                }
                else
                {
                    MessageBox.Show("PAROLA YANLIŞ...", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = null;
                    this.Visible = true;
                }
            }
            else
            {
                var v = from p in db.PERSONELs
                        select p;
                foreach(PERSONEL p in v)
                    if (p.PersonelAdı.Equals(comboBox1.SelectedItem))
                    {
                        if (p.Şifre.Equals(textBox1.Text))
                        {
                            comboBox1.SelectedItem = null;
                            textBox1.Text = null;
                            Form newform = new Personel(db,p);
                            this.Visible = false;
                            newform.ShowDialog();
                            newf1.ShowDialog();
                            radioButton1.Checked = true;
                            this.Visible = true;
                        }
                        else //if (textBox1.Text != "")
                        {
                            MessageBox.Show("PAROLA YANLIŞ...", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Text = null;
                            this.Visible = true;
                            break;
                        }
                    }
            }
        }

    }
}
