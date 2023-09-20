using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Media;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
    
namespace Çek_Bul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int ekleaktif = -1;
        int cekaktif = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = false;
            SoundPlayer oynat = new SoundPlayer();
            string yol = @"C:\Windows\Media\Alarm03.wav";
            oynat.SoundLocation = yol;
            button2.Enabled = false;
            button2.BackColor = Color.Red;
            button3.Enabled = false;
            button3.BackColor = Color.Red;
            oynat.Play();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoundPlayer hata = new SoundPlayer();
            string hyol = @"C:\Windows\Media\Windows Hardware Fail.wav";
            hata.SoundLocation = hyol;
            if (e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                hata.Play();
            }
                        if (char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;

            }
            if (char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button1.PerformClick();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isim = textBox1.Text;
            if (isim == "")
            {
                MessageBox.Show("Lütfen listeye eklemek için bir değer giriniz.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return;
            }
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString().ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listBox1.SetSelected(i, true);
                    MessageBox.Show("Girilen değer zaten katılımcı listesinde bulunmaktadır.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
            }
            listBox1.Items.Add(isim.ToLower());
            SoundPlayer ekle = new SoundPlayer();
            string ekleyol = @"C:\Windows\Media\Speech On.wav";
            ekle.SoundLocation = ekleyol;
            ekle.Play();
            textBox1.Text = "";
            textBox1.Focus(); ;
            button2.Enabled = true;
            button2.BackColor = Color.Green;
            cekaktif++;
            ekleaktif++;
            if (cekaktif >= 2)
            {
                button3.Enabled = true;
                button3.BackColor = Color.Green;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indeks = listBox1.SelectedIndex;
            if (indeks < 0)
            {
                return;
            }
            listBox1.Items.RemoveAt(indeks);
            SoundPlayer kaldir = new SoundPlayer();
            string kaldiryol = @"C:\Windows\Media\Speech Sleep.wav";
            kaldir.SoundLocation = kaldiryol;
            kaldir.Play();
            ekleaktif--; ;
            if (ekleaktif < 0)
            {
                button2.Enabled = false;
                button2.BackColor = Color.Red;
            }
            int liste = listBox1.Items.Count;
            if (liste < 2)
            {
                button3.Enabled = false;
                button3.BackColor = Color.Red;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int isimler = listBox1.Items.Count;
            Random sayi = new Random();
            int secilen = sayi.Next(0, isimler);
            listBox1.SelectedIndex = secilen;
            SoundPlayer kazanan = new SoundPlayer();
            string yolk = @"C:\Windows\Media\tada.wav";
            kazanan.SoundLocation = yolk;
            kazanan.Play();
            MessageBox.Show(listBox1.SelectedItem.ToString() + " isimli kişi çekilişi kazandı!", "Çekiliş sonucu!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listBox1.Items.RemoveAt(secilen);
            ekleaktif--;
            if (ekleaktif == -1)
            {
                button2.Enabled = false;
                button2.BackColor = Color.Red;
                button3.Enabled = false;
                button3.BackColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu program Burak Bozteke tarafından hazırlanmıştır. Minimum iki isim arasında çekiliş yapmak ve bir kişi belirlemek için tasarlanmıştır. Program otomatik güncelleme kontrolüne sahiptir.\r\nİletişim için bozteke01@gmail.com adresinden bana ulaşabilirsiniz.", "Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
