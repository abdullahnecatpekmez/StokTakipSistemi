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
    public partial class Personel : Form
    {
        public DataClasses1DataContext db;
        public PERSONEL girilen = new PERSONEL();
        Form newform = new Yükleniyor("İşleniyor",1);
        int fno;
        public Personel(DataClasses1DataContext db,PERSONEL s)
        {
            this.db = db;
            InitializeComponent();
            girilen = s;
            this.Text=girilen.PersonelAdı+" Adlı Kullanıcı Girişi";
            müşgüncelle.Enabled = false;
            satışgüncelle.Enabled = false;
            ürüncomboBox.Enabled = false;
            satışgüncelle.Enabled = false;
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            viewsatış();
            viewmüşteri();
            markaal();
            müşterial();            
        }
        public void viewmüşteri()
        {
            müşterigöster.DataSource = from m in db.MÜŞTERİs
                                       orderby m.MüşteriAdı
                                       select new {m.MüşteriTC,m.MüşteriAdı,m.Telefon,m.Adres };
            müşterigöster.Columns[0].Width = 150;
            müşterigöster.Columns[1].Width = 250;
            müşterigöster.Columns[2].Width = 150;
            müşterigöster.Columns[3].Width = 350;
        }

        private void müşekle_Click(object sender, EventArgs e)
        {
            if(müşteriTCTextBox.Text==""||müşteriAdıTextBox.Text==""||telefonTextBox.Text==""||adresTextBox.Text=="")
                MessageBox.Show("Değerleri Giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MÜŞTERİ yeni = new MÜŞTERİ();
                if(tckontrol(müşteriTCTextBox.Text))
                    yeni.MüşteriTC=müşteriTCTextBox.Text;
                else
                {
                    MessageBox.Show("Uyumsuz TC", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                yeni.MüşteriAdı=müşteriAdıTextBox.Text;
                yeni.Adres=adresTextBox.Text;
                yeni.Telefon=telefonTextBox.Text;
                var v = from m in db.MÜŞTERİs
                        where m.MüşteriTC.Equals(yeni.MüşteriTC)
                        select m;
                foreach(MÜŞTERİ x in v)
                {
                    MessageBox.Show("Bu MÜŞTERİ Bulunmaktadır", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.MÜŞTERİs.InsertOnSubmit(yeni);
                db.SubmitChanges();
                newform.ShowDialog();
                viewmüşteri();
                müşterial();
                müşteriAdıTextBox.Text = "";
                müşteriTCTextBox.Text = "";
                adresTextBox.Text = "";
                telefonTextBox.Text = "";
            }
        }

        public bool tckontrol(string x)
        {
            if (x.Length == 11)
                return true;
            return false;
        }

        private void müşgüncelle_Click(object sender, EventArgs e)
        {
            if (müşteriAdıTextBox.Text == "" || telefonTextBox.Text == "" || adresTextBox.Text == "")
                MessageBox.Show("Değerleri Giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                var v = from m in db.MÜŞTERİs
                        select m;
                foreach(MÜŞTERİ x in v)
                    if(x.MüşteriTC.Equals(müşteriTCTextBox.Text))
                    {
                        x.MüşteriAdı = müşteriAdıTextBox.Text;
                        x.Telefon = telefonTextBox.Text;
                        x.Adres = adresTextBox.Text;
                        db.SubmitChanges();
                        newform.ShowDialog();
                    }
            }
            viewmüşteri();
            müşteriAdıTextBox.Text = "";
            müşteriTCTextBox.Text = "";
            adresTextBox.Text = "";
            telefonTextBox.Text = "";
            müşteriTCTextBox.Enabled = true;
            müşekle.Enabled = true;
            müşgüncelle.Enabled = false;
            müşterial();
        }

        private void müşterigöster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            müşgüncelle.Enabled = true;
            müşekle.Enabled = false;
            müşteriTCTextBox.Enabled = false;
            müşteriTCTextBox.Text = müşterigöster.CurrentRow.Cells["MüşteriTC"].Value.ToString();
            müşteriAdıTextBox.Text = müşterigöster.CurrentRow.Cells["MüşteriAdı"].Value.ToString();
            adresTextBox.Text = müşterigöster.CurrentRow.Cells["Adres"].Value.ToString();
            telefonTextBox.Text = müşterigöster.CurrentRow.Cells["Telefon"].Value.ToString();
        }
        private void markaal()
        {
            markacomboBox.DataSource = from marka in db.MARKAs
                                       orderby marka.MarkaAdı
                                       select marka.MarkaAdı;
            markacomboBox.SelectedItem = null;
        }
        private void ürünal()
        {
            if (markacomboBox.SelectedItem != null)
            {
                int mno = -1;
                var v = from marka in db.MARKAs
                        select marka;
                foreach (MARKA m in v)
                    if (m.MarkaAdı.Equals(markacomboBox.SelectedItem))
                        mno = m.MarkaNO;
                ürüncomboBox.DataSource = from ürün in db.ÜRÜNs
                                          orderby ürün.ÜrünAdı
                                          where ürün.MarkaNO.Equals(mno) && ürün.Stok != 0
                                          select ürün.ÜrünAdı;
                ürüncomboBox.SelectedItem = null;
            }
        }
        private void müşterial()
        {
            müştericomboBox.DataSource = from m in db.MÜŞTERİs
                                         orderby m.MüşteriAdı
                                         select m.MüşteriAdı;
            müştericomboBox.SelectedItem = null;
        }

        private void markacomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (markacomboBox.SelectedItem != null)
            {
                ürüncomboBox.Enabled = true;
                ürünal();
            }
            else
                ürüncomboBox.Enabled = false;
        }
        private void viewsatış()
        {
            satışgöster.DataSource = from m in db.MARKAs
                                     from ü in db.ÜRÜNs
                                     from mü in db.MÜŞTERİs
                                     from s in db.SATIŞs
                                     where s.PersonelTC.Equals(girilen.PersonelTC) && s.MüşteriTC.Equals(mü.MüşteriTC) && s.ÜrünNO.Equals(ü.ÜrünNO) && ü.MarkaNO.Equals(m.MarkaNO) && s.Durum == null
                                     select new { NO = s.FaturaNO, mü.MüşteriAdı, m.MarkaAdı, ü.ÜrünAdı, s.Tarih, s.Fiyat, s.Adet };
            satışgöster.Columns[0].Width = 40;
            satışgöster.Columns[1].Width = 180;
            satışgöster.Columns[2].Width = 125;
            satışgöster.Columns[3].Width = 165;
            satışgöster.Columns[4].Width = 130;
            satışgöster.Columns[5].Width = 95;
            satışgöster.Columns[6].Width = 60;
        }

        private void satışekle_Click(object sender, EventArgs e)
        {
            if (adetTextBox.Text == "" || müştericomboBox.SelectedItem == null || markacomboBox.SelectedItem == null || ürüncomboBox.SelectedItem == null)
                MessageBox.Show("Değerleri Giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SATIŞ yeni = new SATIŞ();
                MÜŞTERİ mü = db.MÜŞTERİs.First(k => k.MüşteriAdı.Equals(müştericomboBox.SelectedItem));
                MARKA m = db.MARKAs.First(k => k.MarkaAdı.Equals(markacomboBox.SelectedItem));
                ÜRÜN ü = db.ÜRÜNs.First(k => k.MarkaNO == m.MarkaNO && k.ÜrünAdı.Equals(ürüncomboBox.SelectedItem));
                yeni.FaturaNO = db.SATIŞs.Count() + 1;
                if (ü.Stok < Convert.ToInt32(adetTextBox.Text))
                {
                    DialogResult sonuç;
                    string s="Stok miktarı yetersiz!!!\nStok miktarı:"+ü.Stok+"\n"+ü.Stok+" adet almak ister misiniz?";
                    sonuç = MessageBox.Show(s, "DİKKAT!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (sonuç == DialogResult.OK)
                        adetTextBox.Text = ü.Stok.ToString();
                    else
                        return;
                }
                yeni.Adet = Convert.ToInt32(adetTextBox.Text);
                ü.Stok -= yeni.Adet;
                yeni.Fiyat = ü.SatışFiyat * yeni.Adet;
                yeni.Tarih = tarih.Value;
                yeni.PersonelTC = girilen.PersonelTC;
                yeni.MüşteriTC = mü.MüşteriTC;
                yeni.ÜrünNO = ü.ÜrünNO;
                girilen.YaptığıSatışSayısı++;
                girilen.SatışlardanEldeEttiğiMiktar += yeni.Fiyat;
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues);
                db.SATIŞs.InsertOnSubmit(yeni);
                db.SubmitChanges();
                newform.ShowDialog();
                adetTextBox.Text = "";
                müştericomboBox.SelectedItem = null;
                markacomboBox.SelectedItem = null;
                ürüncomboBox.SelectedItem = null;
                viewsatış();
            }
        }

        private void satışgüncelle_Click(object sender, EventArgs e)
        {
            if (adetTextBox.Text == "" || müştericomboBox.SelectedItem == null || markacomboBox.SelectedItem == null || ürüncomboBox.SelectedItem == null)
                MessageBox.Show("Değerleri Giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                SATIŞ x = db.SATIŞs.First(k => k.FaturaNO == fno);
                ÜRÜN eski = db.ÜRÜNs.First(k => k.ÜrünNO == x.ÜrünNO);
                MÜŞTERİ mü = db.MÜŞTERİs.First(k => k.MüşteriAdı.Equals(müştericomboBox.SelectedItem));
                MARKA m = db.MARKAs.First(k => k.MarkaAdı.Equals(markacomboBox.SelectedItem));
                ÜRÜN ü = db.ÜRÜNs.First(k => k.MarkaNO == m.MarkaNO && k.ÜrünAdı.Equals(ürüncomboBox.SelectedItem));
                eski.Stok += x.Adet;
                x.Tarih = tarih.Value;
                if (ü.Stok < Convert.ToInt32(adetTextBox.Text))
                {
                    DialogResult sonuç;
                    string s = "Stok miktarı yetersiz!!!\nStok miktarı:" + ü.Stok + "\n" + ü.Stok + " adet almak ister misiniz?";
                    sonuç = MessageBox.Show(s, "DİKKAT!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (sonuç == DialogResult.OK)
                        adetTextBox.Text = ü.Stok.ToString();
                    else
                        return;
                }
                x.Adet = Convert.ToInt32(adetTextBox.Text);
                ü.Stok -= x.Adet;
                girilen.SatışlardanEldeEttiğiMiktar -= x.Fiyat;
                x.Fiyat = ü.SatışFiyat * x.Adet;
                girilen.SatışlardanEldeEttiğiMiktar += x.Fiyat;
                x.MüşteriTC = mü.MüşteriTC;
                x.ÜrünNO = ü.ÜrünNO;
                db.SubmitChanges();
                newform.ShowDialog();
            }
            adetTextBox.Text = "";
            tarih.Value = DateTime.Now;
            müştericomboBox.SelectedItem = null;
            markacomboBox.SelectedItem = null;
            ürüncomboBox.SelectedItem = null;
            viewsatış();
            satışekle.Enabled = true;
            satışgüncelle.Enabled = false;
            adetTextBox.Enabled = true;
            satışiptal.Enabled = false;
        }

        private void satışgöster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            satışgüncelle.Enabled = true;
            satışekle.Enabled = false;
            satışiptal.Enabled = true;
            müştericomboBox.SelectedItem = satışgöster.CurrentRow.Cells["MüşteriAdı"].Value.ToString();
            markacomboBox.SelectedItem = satışgöster.CurrentRow.Cells["MarkaAdı"].Value.ToString();
            ürüncomboBox.SelectedItem = satışgöster.CurrentRow.Cells["ÜrünAdı"].Value.ToString();
            tarih.Value = (DateTime)satışgöster.CurrentRow.Cells["Tarih"].Value;
            adetTextBox.Text = satışgöster.CurrentRow.Cells["Adet"].Value.ToString();
            fno = (int)satışgöster.CurrentRow.Cells["NO"].Value;
        }

        private void satışiptal_Click(object sender, EventArgs e)
        {
            SATIŞ x = db.SATIŞs.First(k => k.FaturaNO == fno);
            ÜRÜN ü = db.ÜRÜNs.First(k => k.ÜrünNO == x.ÜrünNO);
            x.Durum = "i";
            girilen.YaptığıSatışSayısı--;
            girilen.SatışlardanEldeEttiğiMiktar -= x.Fiyat;
            ü.Stok+=x.Adet;
            db.SubmitChanges();
            newform.ShowDialog();
            adetTextBox.Text = "";
            tarih.Value = DateTime.Now;
            müştericomboBox.SelectedItem = null;
            markacomboBox.SelectedItem = null;
            ürüncomboBox.SelectedItem = null;
            viewsatış();
            satışekle.Enabled = true;
            satışgüncelle.Enabled = false;
            adetTextBox.Enabled = true;
            satışiptal.Enabled = false;
        }

    }
}
