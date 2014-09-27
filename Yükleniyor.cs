using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WP_ÖDEV
{
    public partial class Yükleniyor : Form
    {
        string s;
        int i = 0, j = 0;
        Form newform;
        public Yükleniyor(string s,int i)
        {
            this.s = s;
            j = i;
            InitializeComponent();
        }

        private void Yükleniyor_Load(object sender, EventArgs e)
        {
            newform = new Giriş(this);
            if (s.Equals("Yükleniyor"))
            {
                label1.Visible = true;
                timer1.Enabled = true;
            }
            else
            {
                label2.Visible = true;
                timer1.Enabled = true;
            }
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i % j == 0 && s.Equals("Yükleniyor"))
            {
                timer1.Enabled = false;
                newform.ShowDialog();
                Form newf = new Yükleniyor("İşleniyor", 2);
                newf.ShowDialog();
                this.Close();
            }
            if (i % j == 0 && s.Equals("İşleniyor"))
            {
                timer1.Enabled = false;
                this.Close();
            }
        }
    }
}
