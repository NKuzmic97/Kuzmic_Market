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

    public partial class Prodavnica : Form
    {
        public delegate void PosaljiArtikal(Artikal a,int kolicina);
        public PosaljiArtikal posaljiArtikal;
        RacunForm novaForma;
        Baza baza;
        List<Artikal> lista_artikala;
        List<Grupa> lista_grupa;
        Button[] artikli_buttoni;
        public Prodavnica()
        {
            InitializeComponent();
            baza = new Baza();
            lista_artikala = new List<Artikal>();
            artikli_buttoni = new Button[100];
            lista_grupa = new List<Grupa>();
        }
        public static class Prompt
        {
            public static int ShowDialog()
            {
                Form prompt = new Form();
                prompt.Width = 160;
                prompt.Height = 65;
                prompt.ControlBox = false;
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                prompt.Text = "";
                Label textLabel = new Label() { Left = 10, Top = 10, Text = "Unesite kolicinu: " };
                NumericUpDown inputBox = new NumericUpDown() { Left = 110, Top = 5, Width = 45,Value=1,Minimum = 1,Maximum=10 };
                Button confirmation = new Button() { Text = "OK", Left = 50, Width = 60, Top = 35 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.ShowDialog();
                return (int)inputBox.Value;
            }
        }
        private void DestroyButtons(Form f)
        {
            foreach (Control c in f.Controls.OfType<Button>().ToList())
            {
                this.Controls.Remove(c);
                c.Dispose();
            }
        }
        private void Prodavnica_Load(object sender, EventArgs e)
        {
            novaForma = new RacunForm(this);
            novaForma.Show();
            string test = "Testing how Github works!";
            this.posaljiArtikal += new PosaljiArtikal(novaForma.DodajNaRacun);
            novaForma.SetDesktopLocation(this.Location.X + this.Size.Width-15, this.Location.Y);
            PostaviMetodeNaGrupe();
            this.LocationChanged += new System.EventHandler(this.Prodavnica_LocationChanged);
        }
        private void Prodavnica_LocationChanged(object sender, System.EventArgs e)
        {
            novaForma.AdjustToProdavnica();
        }
        private void PostaviMetodeNaGrupe()
        {
            foreach (Button b in kategorijaBox.Controls)
            {
                if(b.Name != "unesiArtikalBtn")
                b.Click += new EventHandler(PrikaziArtikle);
            }
        }
        private void PrikaziArtikle(object sender, EventArgs e)
        {
            Button b = sender as Button;
            kategorijaBox.Hide();
            UcitajArtikleIzBaze();
            UcitajGrupeIzBaze();
            if (b != null) {
                UcitajArtikle(int.Parse(b.Tag.ToString()));
            }
        }

        private void UcitajArtikle(int id_kategorije)
        {
            int brojac = 0;
            for (int i = 0; i < lista_artikala.Count; i++)
            {
                foreach (var artikal in lista_grupa)
                {
                    if (artikal.Id_grupa == id_kategorije && artikal.Id_artikla == lista_artikala[i].Id_artikla) {
                        artikli_buttoni[i] = new Button();
                        artikli_buttoni[i].Text = lista_artikala[i].Naziv + " " + "CENA: " + lista_artikala[i].Cena + " RSD";
                        artikli_buttoni[i].Click += btn_Click;
                        artikli_buttoni[i].Width = 230;
                        artikli_buttoni[i].Height = 23;
                        artikli_buttoni[i].FlatStyle = FlatStyle.Flat;
                        artikli_buttoni[i].Top = (0+(brojac*20));
                        artikli_buttoni[i].Left = 30;
                        artikli_buttoni[i].Tag = lista_artikala[i];
                        this.Controls.Add(artikli_buttoni[i]);
                        brojac++;
                    }
                }
            }
            DugmeZaPovratak();
        }
        private void DugmeZaPovratak()
        {
            Button povratak = new Button();
            povratak.Text = "<- KATEGORIJE";
            povratak.Width = 100;
            povratak.Height = 25;
            povratak.Left = 5;
            povratak.Click += VratiSeNaKategorije;
            povratak.Top = ClientRectangle.Height - 30;
            povratak.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(povratak);
        }
        private void DugmeZaPovratak2(GroupBox grp1)
        {
            Button povratak = new Button();
            povratak.Text = "<- KATEGORIJE";
            povratak.Width = 100;
            povratak.Height = 25;
            povratak.Left = 5;
            povratak.Click += delegate(object sender, EventArgs e) { HideGroupBox(sender, e, grp1); };
            povratak.Click += VratiSeNaKategorije;
            povratak.Top = ClientRectangle.Height - 30;
            povratak.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(povratak);
        }
        private void HideGroupBox(object sender, EventArgs e,GroupBox g)
        {
            g.Hide();
        }
        private void btn_Click(object sender,EventArgs e)
        {
            Button b = sender as Button;
            Artikal a = b.Tag as Artikal;
            int kolicina = Prompt.ShowDialog();
            posaljiArtikal(a,kolicina);
        }
        private void VratiSeNaKategorije(object sender, EventArgs e)
        {
            DestroyButtons(this);
            kategorijaBox.Show();
            lista_artikala.Clear();
            lista_grupa.Clear();
        }

        private void UcitajArtikleIzBaze()
        {
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Artikal";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artikal a = new Artikal();
                    a.Id_artikla = int.Parse(reader["id_artikla"].ToString());
                    a.Naziv = reader["naziv"].ToString();
                    a.Cena = int.Parse(reader["cena"].ToString());
                    a.Popust = (int.Parse(reader["popust"].ToString()));
                    lista_artikala.Add(a);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
        }
        private void UcitajGrupeIzBaze()
        {
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "SELECT * FROM Grupa";
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Grupa g = new Grupa();
                    g.Id_artikla = int.Parse(reader["id_artikla"].ToString());
                    g.Id_grupa = int.Parse(reader["id_grupa"].ToString());
                    lista_grupa.Add(g);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
        }
        private void DodajArtikalBtn(object sender,EventArgs e,TextBox ime_artikla,NumericUpDown cena,NumericUpDown popust,ComboBox id_kategorije)
        {
            int id = -1;
            bool provera = false;
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "INSERT INTO Artikal(naziv,cena,popust) VALUES(@ime_artikla,@cena,@popust)";
                cmd.Parameters.AddWithValue("@ime_artikla", ime_artikla.Text);
                cmd.Parameters.AddWithValue("@cena", cena.Value);
                cmd.Parameters.AddWithValue("@popust", popust.Value);
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT id_artikla FROM Artikal WHERE naziv=@ime_artikla";
                id = (int)cmd.ExecuteScalar();
                MessageBox.Show("Artikal uspesno dodat!");
                provera = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }

            if(provera)
                DodeliArtikalKategoriji(id_kategorije.SelectedIndex + 1,id);
            ime_artikla.Clear();
            cena.Value = 5;
            popust.Value = 0;
            id_kategorije.SelectedIndex = 0;

        }
        private void DodeliArtikalKategoriji(int id_kategorije,int id_artikla)
        {
            try
            {
                baza.OtvoriKonekciju();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baza.Conn;
                cmd.CommandText = "INSERT INTO Grupa(id_grupa,id_artikla) VALUES(@id_kat,@id)";
                cmd.Parameters.AddWithValue("@id_kat", id_kategorije);
                cmd.Parameters.AddWithValue("@id_art", id_artikla);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Uspesno dodeljeno kategoriji!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { baza.ZatvoriKonekciju(); }
        }
        private void unesiArtikalBtn_Click(object sender, EventArgs e)
        {
            kategorijaBox.Hide();
            UcitajArtikleIzBaze();
            GroupBox grp1 = new GroupBox();
            Label label1 = new Label();
            label1.Text = "Naziv artikla:";
            label1.Width = 80;
            label1.Height = 25;
            label1.Left = 5;
            label1.Top = ClientRectangle.Top + 10;
            this.Controls.Add(label1);
            TextBox textbox1 = new TextBox();
            textbox1.Width = 195;
            textbox1.Height = 25;
            textbox1.Left = label1.Left + label1.Width;
            textbox1.Top = ClientRectangle.Top + 10;
            this.Controls.Add(textbox1);
            Label label2 = new Label();
            label2.Text = "Cena artikla:";
            label2.Width = 80;
            label2.Height = 25;
            label2.Left = 5;
            label2.Top = ClientRectangle.Top + 40;
            this.Controls.Add(label2);
            NumericUpDown up_down1 = new NumericUpDown();
            up_down1.Width = 70;
            up_down1.Height = 25;
            up_down1.Left = label2.Left + label2.Width+125;
            up_down1.Top = label2.Top;
            up_down1.Minimum = 5;
            up_down1.Maximum = 10000;
            up_down1.Increment = 5;
            this.Controls.Add(up_down1);

            Label label3 = new Label();
            label3.Text = "Popust na cenu: %";
            label3.Width = 120;
            label3.Height = 25;
            label3.Left = 5;
            label3.Top = ClientRectangle.Top + 70;
            this.Controls.Add(label3);
            NumericUpDown up_down2 = new NumericUpDown();
            up_down2.Width = 70;
            up_down2.Height = 25;
            up_down2.Left = label3.Left + label3.Width + 85;
            up_down2.Top = label3.Top;
            up_down2.Minimum = 0;
            up_down2.Maximum = 50;
            up_down2.Increment = 5;
            this.Controls.Add(up_down2);

            Label label4 = new Label();
            label4.Text = "Kategorija artikla:";
            label4.Width = 120;
            label4.Height = 25;
            label4.Left = 5;
            label4.Top = ClientRectangle.Top + 100;
            this.Controls.Add(label4);
            ComboBox combobox1 = new ComboBox();
            combobox1.DropDownStyle = ComboBoxStyle.DropDownList;
            combobox1.Width = 140;
            combobox1.Height = 25;
            combobox1.Left = label4.Left + label4.Width+15;
            combobox1.Top = ClientRectangle.Top + 100;
            combobox1.Items.Add("Namirnice");
            combobox1.Items.Add("Zdrava hrana");
            combobox1.Items.Add("Mlecni proizvodi");
            combobox1.Items.Add("Voce i povrce");
            combobox1.Items.Add("Meso i riba");
            combobox1.Items.Add("Pića");
            combobox1.Items.Add("Slatkisi i grickalice");
            combobox1.Items.Add("Licna higijena");
            combobox1.Items.Add("Kucna hemija");
            combobox1.SelectedIndex = 0;
            this.Controls.Add(combobox1);
            Button btn = new Button();
            btn.Text = "Dodaj artikal";
            btn.Width = 100;
            btn.Height = 30;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Click += delegate (object sen, EventArgs earg) { DodajArtikalBtn(sen, earg, textbox1, up_down1,up_down2, combobox1); };
            btn.Left = 100;
            btn.Top = ClientRectangle.Top + 150;
            this.Controls.Add(btn);
            grp1.Controls.Add(label1);
            grp1.Controls.Add(label2);
            grp1.Controls.Add(label3);
            grp1.Controls.Add(label4);
            grp1.Controls.Add(textbox1);
            grp1.Controls.Add(up_down1);
            grp1.Controls.Add(up_down2);
            grp1.Controls.Add(combobox1);
            grp1.Height = 200;
            grp1.Width = 280;
            grp1.Left = 1;
            this.Controls.Add(grp1);
            DugmeZaPovratak2(grp1);
        }

        private void Prodavnica_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void namirniceBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
