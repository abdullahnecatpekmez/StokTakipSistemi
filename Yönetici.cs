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
    public partial class Yönetici : Form
    {
        DataClasses1DataContext db;
        int mno, üno;
        Form newform = new Yükleniyor("İşleniyor",1);

        public Yönetici(DataClasses1DataContext db)
        {
            this.db = db;
            InitializeComponent();
            markagüncelle.Enabled = false;
            ürüngüncelle.Enabled = false;
        }

        private void Yönetici_Load(object sender, EventArgs e)
        {
            viewmarka();
            viewürün();
            markaiçerikal();
            viewpersonel();
            gelirgider();
        }
        private void gelirgider()
        {
            double gelir = 0, gider = 0;
            var ürün = from ü in db.ÜRÜNs
                       select ü;
            var satış = from s in db.SATIŞs
                        where s.Durum == null
                        select s;
            foreach (ÜRÜN x in ürün)
            {
                gider += x.AlışFiyat * x.Stok;
            }
            foreach (SATIŞ x in satış)
            {
                gelir += (double)x.Fiyat;
            }
            label3.Text = gelir + "  ₺";
            label4.Text = gider + "  ₺";
        }
        private void viewpersonel()
        {
            personelgöster.DataSource = from m in db.PERSONELs
                                        orderby m.Durum
                                        select new { m.PersonelAdı, m.PersonelTC, m.Telefon, m.Adres, m.Şifre, m.Durum };
            personelgöster.Columns[0].Width = 180;
            personelgöster.Columns[1].Width = 130;
            personelgöster.Columns[2].Width = 130;
            personelgöster.Columns[3].Width = 175;
            personelgöster.Columns[4].Width = 80;
            personelgöster.Columns[5].Width = 100;
        }

        private void viewmarka()
        {
            markagöster.DataSource = from marka in db.MARKAs
                                     select new { NO=marka.MarkaNO ,marka.MarkaAdı };
            markagöster.Columns[0].Width = 65;
            markagöster.Columns[1].Width = 220;
        }
        private void viewürün()
        {
            ürüngöster.DataSource = from ürün in db.ÜRÜNs
                                    from marka in db.MARKAs
                                    where ürün.MarkaNO.Equals(marka.MarkaNO)
                                    select new { NO=ürün.ÜrünNO,marka.MarkaAdı, ÜrünAdıVeCinsi=ürün.ÜrünAdı, ürün.AlışFiyat, ürün.SatışFiyat, ürün.Stok };
            ürüngöster.Columns[0].Width = 70;
            ürüngöster.Columns[1].Width = 180;
            ürüngöster.Columns[2].Width = 280;
            ürüngöster.Columns[3].Width = 90;
            ürüngöster.Columns[4].Width = 90;
            ürüngöster.Columns[5].Width = 90;
        }

        private void markaiçerikal()
        {
            markaalcomboBox.DataSource = from marka in db.MARKAs
                                       orderby marka.MarkaAdı
                                       select marka.MarkaAdı;

            markaalcomboBox.SelectedItem = null;
        }

        private void markaekle_Click(object sender, EventArgs e)
        {
            if (markaAdıTextBox.Text == "")
                MessageBox.Show("'Marka Adı' giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                bool var = false;
                MARKA m = new MARKA();
                m.MarkaAdı = markaAdıTextBox.Text;
                m.MarkaNO = db.MARKAs.Count() + 1;
                var v = from marka in db.MARKAs
                        where marka.MarkaAdı.Equals(m.MarkaAdı)
                        select marka;
                foreach (MARKA a in v)
                    var = true;
                if (var)
                {
                    newform.ShowDialog();
                    MessageBox.Show("MARKA BULUNMAKTADIR", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    db.MARKAs.InsertOnSubmit(m);
                    db.SubmitChanges();
                    newform.ShowDialog();
                }
                markaAdıTextBox.Text = "";
                viewmarka();
                markaiçerikal();
            }
        }

        private void markagöster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            markaekle.Enabled=false;
            markagüncelle.Enabled=true;
            mno = (int)markagöster.CurrentRow.Cells["NO"].Value;
            markaAdıTextBox.Text = markagöster.CurrentRow.Cells["MarkaAdı"].Value.ToString();
        }

        private void markagüncelle_Click(object sender, EventArgs e)
        {
            MARKA x = db.MARKAs.First(k => k.MarkaNO == mno);
            x.MarkaAdı = markaAdıTextBox.Text;
            db.SubmitChanges();
            newform.ShowDialog();
            markaAdıTextBox.Text = null;
            markaekle.Enabled = true;
            markagüncelle.Enabled = false;
            viewmarka();
            viewürün();
        }

        private void ürünekle_Click(object sender, EventArgs e)
        {
            if (ürünAdıTextBox.Text == "" || markaalcomboBox.SelectedItem == null || alışFiyatTextBox.Text == "" || stokTextBox.Text == "")
                MessageBox.Show("Değerleri Giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ÜRÜN yeni = new ÜRÜN();
                MARKA m = db.MARKAs.First(k => k.MarkaAdı.Equals(markaalcomboBox.SelectedItem));
                yeni.ÜrünNO = db.ÜRÜNs.Count() + 1;
                yeni.ÜrünAdı = ürünAdıTextBox.Text;
                yeni.MarkaNO = m.MarkaNO;
                if (Convert.ToInt32(stokTextBox.Text) > 0)
                    yeni.Stok = Convert.ToInt32(stokTextBox.Text);
                else
                {
                    MessageBox.Show("\rGeçersiz Stok Miktarı\n\rPozitif bir değer giriniz...", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(Convert.ToInt32(alışFiyatTextBox.Text)>0)
                {
                    yeni.AlışFiyat = Convert.ToInt32(alışFiyatTextBox.Text);
                    yeni.SatışFiyat = yeni.AlışFiyat * 1.18;
                }
                var v = from ü in db.ÜRÜNs
                        where (ü.ÜrünAdı.Equals(yeni.ÜrünAdı) && ü.MarkaNO == yeni.MarkaNO)
                        select ü;
                //ÜRÜN x = db.ÜRÜNs.First(k => k.ÜrünAdı == yeni.ÜrünAdı && k.MarkaNO == yeni.MarkaNO);
                foreach(ÜRÜN x in v)
                {
                    MessageBox.Show("\rBu Ürün Bulunmaktadır...", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.ÜRÜNs.InsertOnSubmit(yeni);
                db.SubmitChanges();
                newform.ShowDialog();
                viewürün();
                ürünAdıTextBox.Text = null;
                markaalcomboBox.SelectedItem = null;
                stokTextBox.Text = null;
                alışFiyatTextBox.Text = null;
                gelirgider();
            }
        }

        private void ürüngüncelle_Click(object sender, EventArgs e)
        {
            if (ürünAdıTextBox.Text == "" || markaalcomboBox.SelectedItem == null || alışFiyatTextBox.Text == "" || stokTextBox.Text == "")
                MessageBox.Show("Değerleri Giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                ÜRÜN x = db.ÜRÜNs.First(k => k.ÜrünNO == üno);
                MARKA m = db.MARKAs.First(k => k.MarkaAdı.Equals(markaalcomboBox.SelectedItem));
                x.ÜrünAdı = ürünAdıTextBox.Text;
                x.MarkaNO = m.MarkaNO;
                if (Convert.ToInt32(stokTextBox.Text) > 0)
                    x.Stok = Convert.ToInt32(stokTextBox.Text);
                else
                {
                    MessageBox.Show("\rGeçersiz Stok Miktarı\n\rPozitif bir değer giriniz...", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToInt32(alışFiyatTextBox.Text) > 0)
                {
                    x.AlışFiyat = Convert.ToInt32(alışFiyatTextBox.Text);
                    x.SatışFiyat = x.AlışFiyat * 1.18;
                }
                var v = from ü in db.ÜRÜNs
                        where (ü.ÜrünAdı.Equals(x.ÜrünAdı) && ü.MarkaNO == x.MarkaNO && ü.ÜrünNO!=x.ÜrünNO)
                        select ü;
                //ÜRÜN x = db.ÜRÜNs.First(k => k.ÜrünAdı == yeni.ÜrünAdı && k.MarkaNO == yeni.MarkaNO);
                foreach (ÜRÜN y in v)
                {
                    MessageBox.Show("\rBu Ürün Bulunmaktadır...", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.SubmitChanges();
                newform.ShowDialog();
                viewürün();
                ürünAdıTextBox.Text = null;
                markaalcomboBox.SelectedItem = null;
                stokTextBox.Text = null;
                alışFiyatTextBox.Text = null;
                ürüngüncelle.Enabled = false;
                ürünekle.Enabled = true;
                gelirgider();
            }
        }

        private void ürüngöster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ürüngüncelle.Enabled = true;
            ürünekle.Enabled = false;
            üno = (int)ürüngöster.CurrentRow.Cells["NO"].Value;
            ürünAdıTextBox.Text = ürüngöster.CurrentRow.Cells["ÜrünAdıVeCinsi"].Value.ToString();
            markaalcomboBox.SelectedItem = ürüngöster.CurrentRow.Cells["MarkaAdı"].Value.ToString();
            stokTextBox.Text = ürüngöster.CurrentRow.Cells["Stok"].Value.ToString();
            alışFiyatTextBox.Text = ürüngöster.CurrentRow.Cells["AlışFiyat"].Value.ToString();
        }

        public bool tckontrol(string x)
        {
            if (x.Length == 11)
                return true;
            return false;
        }

        private void personelekle_Click(object sender, EventArgs e)
        {
            if (personelAdıTextBox.Text == "" || personelTCTextBox.Text == "" || adresTextBox.Text == "" || telefonTextBox.Text == "" || şifreTextBox.Text == "")
                MessageBox.Show("Değerleri Giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PERSONEL yeni = new PERSONEL();
                yeni.Durum = "ÇALIŞIYOR";
                yeni.YaptığıSatışSayısı = 0;
                yeni.SatışlardanEldeEttiğiMiktar = 0;
                if (tckontrol(personelTCTextBox.Text))
                    yeni.PersonelTC = personelTCTextBox.Text;
                else
                {
                    MessageBox.Show("Uyumsuz TC", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                yeni.PersonelAdı = personelAdıTextBox.Text;
                yeni.Adres = adresTextBox.Text;
                yeni.Telefon = telefonTextBox.Text;
                yeni.Şifre = şifreTextBox.Text;
                var v = from p in db.PERSONELs
                        where p.PersonelTC.Equals(personelTCTextBox.Text)
                        select p;
                foreach (PERSONEL x in v)
                {
                    MessageBox.Show("Bu PERSONEL Bulunmaktadır", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                db.PERSONELs.InsertOnSubmit(yeni);
                db.SubmitChanges();
                newform.ShowDialog();
                personelAdıTextBox.Text = null;
                personelTCTextBox.Text = null;
                adresTextBox.Text = null;
                telefonTextBox.Text = null;
                şifreTextBox.Text = null;
                viewpersonel();
            }
        }

        private void personelgöster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            personelekle.Enabled = false;
            personelgüncelle.Enabled = true;
            personelTCTextBox.Enabled = false;
            personelTCTextBox.Text = personelgöster.CurrentRow.Cells["PersonelTC"].Value.ToString();
            personelAdıTextBox.Text = personelgöster.CurrentRow.Cells["PersonelAdı"].Value.ToString();
            şifreTextBox.Text = personelgöster.CurrentRow.Cells["Şifre"].Value.ToString();
            comboBox1.SelectedItem = personelgöster.CurrentRow.Cells["Durum"].Value.ToString();
            if (comboBox1.SelectedIndex == 1)
            {
                comboBox1.Enabled = true;
                iştençıkar.Enabled = false;
            }
            else iştençıkar.Enabled = true;
            adresTextBox.Text = personelgöster.CurrentRow.Cells["Adres"].Value.ToString();
            telefonTextBox.Text = personelgöster.CurrentRow.Cells["Telefon"].Value.ToString();            
        }

        private void personelgüncelle_Click(object sender, EventArgs e)
        {
            if (personelAdıTextBox.Text == "" || personelTCTextBox.Text == "" || adresTextBox.Text == "" || telefonTextBox.Text == "" || şifreTextBox.Text == "")
                MessageBox.Show("Değerleri Giriniz", "DİKKAT!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                PERSONEL x=db.PERSONELs.First(k=>k.PersonelTC.Equals(personelTCTextBox.Text));
                x.PersonelAdı = personelAdıTextBox.Text;
                x.Adres = adresTextBox.Text;
                x.Durum = comboBox1.SelectedItem.ToString();
                x.Şifre = şifreTextBox.Text;
                x.Telefon = telefonTextBox.Text;
                db.SubmitChanges();
                newform.ShowDialog();
                personelAdıTextBox.Text = null;
                personelTCTextBox.Text = null;
                adresTextBox.Text = null;
                telefonTextBox.Text = null;
                şifreTextBox.Text = null;
                viewpersonel();
                comboBox1.SelectedIndex = 0;
                comboBox1.Enabled = false;
                personelekle.Enabled = true;
                personelgüncelle.Enabled = false;
                iştençıkar.Enabled = false;
                personelTCTextBox.Enabled = true;
            }
        }

        private void iştençıkar_Click(object sender, EventArgs e)
        {
            PERSONEL x = db.PERSONELs.First(k => k.PersonelTC.Equals(personelTCTextBox.Text));
            x.Durum = "ÇALIŞMIYOR";
            x.YaptığıSatışSayısı = 0;
            x.SatışlardanEldeEttiğiMiktar = 0;
            db.SubmitChanges();
            newform.ShowDialog();
            personelAdıTextBox.Text = null;
            personelTCTextBox.Text = null;
            adresTextBox.Text = null;
            telefonTextBox.Text = null;
            şifreTextBox.Text = null;
            viewpersonel();
            comboBox1.SelectedIndex = 0;
            personelekle.Enabled = true;
            personelgüncelle.Enabled = false;
            iştençıkar.Enabled = false;
            personelTCTextBox.Enabled = true;
        }

        private void sorgucomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sorgucomboBox.SelectedIndex)
            {
                case 0:
                    newform.ShowDialog();
                    sorgugörüntüle.DataSource = from m in db.MÜŞTERİs
                                                orderby m.MüşteriAdı
                                                select new { m.MüşteriAdı, m.MüşteriTC, m.Telefon, m.Adres };
                    sorgugörüntüle.Columns[0].Width = 210;
                    sorgugörüntüle.Columns[1].Width = 130;
                    sorgugörüntüle.Columns[2].Width = 130;
                    sorgugörüntüle.Columns[3].Width = 310;
                    break;

                case 1:
                    newform.ShowDialog();
                    sorgugörüntüle.DataSource = from m in db.MARKAs
                                                from ü in db.ÜRÜNs
                                                from mü in db.MÜŞTERİs
                                                from s in db.SATIŞs
                                                from p in db.PERSONELs
                                                orderby p.PersonelAdı
                                                where s.PersonelTC.Equals(p.PersonelTC) && s.MüşteriTC.Equals(mü.MüşteriTC) && s.ÜrünNO.Equals(ü.ÜrünNO) && ü.MarkaNO.Equals(m.MarkaNO) && s.Durum == null
                                                select new { SatışYapanPersonel = p.PersonelAdı, mü.MüşteriAdı, m.MarkaAdı, ü.ÜrünAdı, s.Tarih, s.Fiyat, s.Adet };
                    sorgugörüntüle.Columns[0].Width = 160;
                    sorgugörüntüle.Columns[1].Width = 160;
                    sorgugörüntüle.Columns[2].Width = 105;
                    sorgugörüntüle.Columns[3].Width = 125;
                    sorgugörüntüle.Columns[4].Width = 110;
                    sorgugörüntüle.Columns[5].Width = 70;
                    sorgugörüntüle.Columns[6].Width = 50;
                    break;
                case 2:
                    newform.ShowDialog();
                    int min = 1000;
                    var v2 = from p in db.PERSONELs
                             where p.Durum.Equals("ÇALIŞIYOR")
                            select p;
                    foreach(PERSONEL x in v2)
                    {
                        if (min > (int)x.YaptığıSatışSayısı)
                            min = (int)x.YaptığıSatışSayısı;
                    }
                    sorgugörüntüle.DataSource = from p in db.PERSONELs
                                                where p.YaptığıSatışSayısı == min && p.Durum.Equals("ÇALIŞIYOR")
                                                select new { p.PersonelAdı, p.PersonelTC, p.Telefon, p.Adres, Sayı = p.YaptığıSatışSayısı };
                    sorgugörüntüle.Columns[0].Width = 210;
                    sorgugörüntüle.Columns[1].Width = 130;
                    sorgugörüntüle.Columns[2].Width = 130;
                    sorgugörüntüle.Columns[3].Width = 250;
                    sorgugörüntüle.Columns[4].Width = 60;
                    break;
                case 3:
                    newform.ShowDialog();
                    int max = 0;
                    var v = from p in db.PERSONELs
                            select p;
                    foreach (PERSONEL x in v)
                    {
                        if (max < (int)x.YaptığıSatışSayısı)
                            max = (int)x.YaptığıSatışSayısı;
                    }
                    sorgugörüntüle.DataSource = from p in db.PERSONELs
                                                where p.YaptığıSatışSayısı == max && p.Durum.Equals("ÇALIŞIYOR")
                                                select new { p.PersonelAdı, p.PersonelTC, p.Telefon, p.Adres, Sayı = p.YaptığıSatışSayısı };
                    sorgugörüntüle.Columns[0].Width = 210;
                    sorgugörüntüle.Columns[1].Width = 130;
                    sorgugörüntüle.Columns[2].Width = 130;
                    sorgugörüntüle.Columns[3].Width = 250;
                    sorgugörüntüle.Columns[4].Width = 60;
                    break;
                case 4:
                    newform.ShowDialog();
                    float max1 = 0;
                    var v1 = from p in db.PERSONELs
                             select p;
                    foreach (PERSONEL x in v1)
                    {
                        if (max1 < (float)x.SatışlardanEldeEttiğiMiktar)
                            max1 = (int)x.SatışlardanEldeEttiğiMiktar;
                    }
                    sorgugörüntüle.DataSource = from p in db.PERSONELs
                                                where p.SatışlardanEldeEttiğiMiktar == max1 && p.Durum.Equals("ÇALIŞIYOR")
                                                select new { p.PersonelAdı, p.PersonelTC, p.Telefon, p.Adres, Gelir = p.SatışlardanEldeEttiğiMiktar };
                    sorgugörüntüle.Columns[0].Width = 210;
                    sorgugörüntüle.Columns[1].Width = 130;
                    sorgugörüntüle.Columns[2].Width = 130;
                    sorgugörüntüle.Columns[3].Width = 230;
                    sorgugörüntüle.Columns[4].Width = 80;
                    break;
                case 5:
                    newform.ShowDialog();
                    sorgugörüntüle.DataSource = from m in db.MARKAs
                                                from ü in db.ÜRÜNs
                                                from mü in db.MÜŞTERİs
                                                from s in db.SATIŞs
                                                from p in db.PERSONELs
                                                orderby p.PersonelAdı
                                                where s.PersonelTC.Equals(p.PersonelTC) && s.MüşteriTC.Equals(mü.MüşteriTC) && s.ÜrünNO.Equals(ü.ÜrünNO) && ü.MarkaNO.Equals(m.MarkaNO) && s.Durum == "i"
                                                select new { SatışYapanPersonel = p.PersonelAdı, mü.MüşteriAdı, m.MarkaAdı, ü.ÜrünAdı, s.Tarih, s.Fiyat, s.Adet };
                    sorgugörüntüle.Columns[0].Width = 160;
                    sorgugörüntüle.Columns[1].Width = 160;
                    sorgugörüntüle.Columns[2].Width = 105;
                    sorgugörüntüle.Columns[3].Width = 125;
                    sorgugörüntüle.Columns[4].Width = 110;
                    sorgugörüntüle.Columns[5].Width = 70;
                    sorgugörüntüle.Columns[6].Width = 50;
                    break;
                case 6:
                    newform.ShowDialog();
                    sorgugörüntüle.DataSource = from ürün in db.ÜRÜNs
                                                from marka in db.MARKAs
                                                where ürün.MarkaNO.Equals(marka.MarkaNO) && ürün.Stok < 10
                                                select new { NO = ürün.ÜrünNO, marka.MarkaAdı, ÜrünAdıVeCinsi = ürün.ÜrünAdı, ürün.AlışFiyat, ürün.SatışFiyat, ürün.Stok };
                    sorgugörüntüle.Columns[0].Width = 70;
                    sorgugörüntüle.Columns[1].Width = 180;
                    sorgugörüntüle.Columns[2].Width = 270;
                    sorgugörüntüle.Columns[3].Width = 90;
                    sorgugörüntüle.Columns[4].Width = 90;
                    sorgugörüntüle.Columns[5].Width = 90;
                    break;
            }
        }
    }
}
