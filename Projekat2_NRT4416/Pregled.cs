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
    public partial class Pregled : Form
    {
        Baza baza;
        List<Racun> lista_racuna;
        public Pregled()
        {
            InitializeComponent();
        }

        private void Pregled_Load(object sender, EventArgs e)
        {
            lista_racuna = new List<Racun>();
            baza = new Baza();
            dateTimePicker1.MinDate = DateTime.Today.AddDays(-20);
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker2.MinDate = dateTimePicker1.MinDate;
            dateTimePicker2.MaxDate = DateTime.Today;
            UcitajRacune();
        }
        private void UcitajRacune()
        {
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Racun";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Racun r = new Racun();
                    r.Id_racun = int.Parse(reader["id_racun"].ToString());
                    r.Cena = int.Parse(reader["cena"].ToString());
                    r.Datum = DateTime.ParseExact(reader["datum"].ToString(), "dd.MM.yyyy", null);
                    r.Vreme = DateTime.ParseExact(reader["vreme"].ToString(),"HH:mm",null);
                    lista_racuna.Add(r);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
        }
        private void UcitajBtn_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            foreach (var racun in lista_racuna)
            {
                if (checkBox1.Checked)
                {
                    var item = new ListViewItem(racun.Datum.ToString("dd.MM.yyyy"));
                    item.SubItems.Add(racun.Vreme.ToString("HH:mm"));
                    item.SubItems.Add(racun.Cena.ToString());
                    item.Tag = racun;
                    listView1.Items.Add(item);
                }
                else if ((dateTimePicker1.Value <= racun.Datum) && (racun.Datum <= dateTimePicker2.Value))
                {
                    var item = new ListViewItem(racun.Datum.ToString("dd.MM.yyyy"));
                    item.SubItems.Add(racun.Vreme.ToString("HH:mm"));
                    item.SubItems.Add(racun.Cena.ToString());
                    item.Tag = racun;
                    listView1.Items.Add(item);
                }
            }
            MessageBox.Show("Racuni uspesno ucitani!");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prodavnica frm = new Prodavnica();
            frm.Show();
            this.Close();
        }
    }
}
