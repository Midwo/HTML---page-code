using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sciezka;
            if (!textBox1.Text.StartsWith("http://"))
                sciezka = "http://" + textBox1.Text;
            else
                sciezka = textBox1.Text;
            try
            {
                WebRequest zadanie1 = WebRequest.Create(sciezka);
                zadanie1.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse odpowiedz = (HttpWebResponse)zadanie1.GetResponse();
                string s = odpowiedz.ContentEncoding;
                Stream strumien = odpowiedz.GetResponseStream();
                StreamReader sr = new StreamReader(strumien, Encoding.Default, true);
                string tekst = sr.ReadToEnd();
                textBox2.Text = tekst;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd ładowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, null);
        }
    }
}
