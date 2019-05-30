using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Projekat2_NRT4416
{
    public partial class RacunForm : Form
    {
        Baza baza;
        int suma = 0;
        private Prodavnica prodavnica = null;
        public RacunForm(Prodavnica frm)
        {
            baza = new Baza();
            prodavnica = frm;
            InitializeComponent();
            AdjustToProdavnica();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            //this.ControlBox = false;
            this.Text = "Racun";
        }
        internal void AdjustToProdavnica()
        {
            this.Left = prodavnica.Right-15;
            this.Top = prodavnica.Top;
            this.Refresh();
        }
        public void DodajNaRacun(Artikal a,int kolicina)
        {
            var item = new ListViewItem(a.Naziv);
            item.SubItems.Add(kolicina.ToString());
            item.SubItems.Add((kolicina*(a.Cena-(a.Cena*((float)a.Popust/100)))).ToString());
            item.Tag = a;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (a.Id_artikla == ((Artikal)listView1.Items[i].Tag).Id_artikla)
                {
                    MessageBox.Show("Artikal se vec nalazi na racunu!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            listView1.Items.Add(item);
            suma += kolicina * (int)(a.Cena - (a.Cena *(((float)a.Popust/100))));
            sumaLbl.Text = suma.ToString();
        }

        private void RacunForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void izbrisiRacunBtn_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            suma = 0;
            sumaLbl.Text = suma.ToString();
        }

        private void RacunForm_Load(object sender, EventArgs e)
        {
            AdjustToProdavnica();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 )
            {
                var item = listView1.SelectedItems[0];
                int kolicina = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                int cena = int.Parse(listView1.SelectedItems[0].SubItems[2].Text);
                suma = suma - (cena/kolicina);
                sumaLbl.Text = suma.ToString();
                if (kolicina == 1)
                {
                    listView1.Items.Remove(item);
                    return;
                }
                listView1.SelectedItems[0].SubItems[1].Text = (kolicina - 1).ToString();
                listView1.SelectedItems[0].SubItems[2].Text = (cena - (cena / kolicina)).ToString();

            }
        }

        private void izdajRacun_btn_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                try
                {

                    baza.OtvoriKonekciju();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = baza.Conn;
                    cmd.CommandText = "INSERT INTO Racun(cena,datum,vreme) VALUES(@cena,@datum,@vreme)";
                    cmd.Parameters.AddWithValue("@cena", suma.ToString());
                    cmd.Parameters.AddWithValue("@datum", DateTime.Now.ToString("dd.MM.yyyy"));
                    cmd.Parameters.AddWithValue("@vreme", DateTime.Now.ToString("HH:mm"));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Racun uspesno izdat!");
                    listView1.Items.Clear();
                    suma = 0;
                    sumaLbl.Text = suma.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { baza.ZatvoriKonekciju(); }
            }
            else
                MessageBox.Show("Racun nije izdat, nema stavki!");
        }

        private void pregledBtn_Click(object sender, EventArgs e)
        {
            Pregled pregled = new Pregled();
            this.Hide();
            prodavnica.Hide();
            pregled.Show();
        }
    }
}
