namespace Projekat2_NRT4416
{
    partial class RacunForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.izdajRacun_btn = new System.Windows.Forms.Button();
            this.ukupnoLbl = new System.Windows.Forms.Label();
            this.sumaLbl = new System.Windows.Forms.Label();
            this.valutaLbl = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Artikal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kolicina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.izbrisiRacunBtn = new System.Windows.Forms.Button();
            this.pregledBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // izdajRacun_btn
            // 
            this.izdajRacun_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.izdajRacun_btn.Location = new System.Drawing.Point(174, 579);
            this.izdajRacun_btn.Margin = new System.Windows.Forms.Padding(2);
            this.izdajRacun_btn.Name = "izdajRacun_btn";
            this.izdajRacun_btn.Size = new System.Drawing.Size(83, 24);
            this.izdajRacun_btn.TabIndex = 0;
            this.izdajRacun_btn.Text = "Izdaj racun";
            this.izdajRacun_btn.UseVisualStyleBackColor = true;
            this.izdajRacun_btn.Click += new System.EventHandler(this.izdajRacun_btn_Click);
            // 
            // ukupnoLbl
            // 
            this.ukupnoLbl.AutoSize = true;
            this.ukupnoLbl.Location = new System.Drawing.Point(102, 560);
            this.ukupnoLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ukupnoLbl.Name = "ukupnoLbl";
            this.ukupnoLbl.Size = new System.Drawing.Size(48, 13);
            this.ukupnoLbl.TabIndex = 1;
            this.ukupnoLbl.Text = "Ukupno:";
            // 
            // sumaLbl
            // 
            this.sumaLbl.AutoSize = true;
            this.sumaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sumaLbl.Location = new System.Drawing.Point(170, 551);
            this.sumaLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.sumaLbl.Name = "sumaLbl";
            this.sumaLbl.Size = new System.Drawing.Size(0, 24);
            this.sumaLbl.TabIndex = 2;
            // 
            // valutaLbl
            // 
            this.valutaLbl.AutoSize = true;
            this.valutaLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valutaLbl.Location = new System.Drawing.Point(238, 565);
            this.valutaLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.valutaLbl.Name = "valutaLbl";
            this.valutaLbl.Size = new System.Drawing.Size(19, 7);
            this.valutaLbl.TabIndex = 3;
            this.valutaLbl.Text = "RSD";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Artikal,
            this.Kolicina,
            this.Cena});
            this.listView1.Location = new System.Drawing.Point(-1, -1);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(265, 539);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // Artikal
            // 
            this.Artikal.Text = "Artikal";
            this.Artikal.Width = 185;
            // 
            // Kolicina
            // 
            this.Kolicina.Text = "QR";
            this.Kolicina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Kolicina.Width = 30;
            // 
            // Cena
            // 
            this.Cena.Text = "Cena";
            this.Cena.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Cena.Width = 45;
            // 
            // izbrisiRacunBtn
            // 
            this.izbrisiRacunBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.izbrisiRacunBtn.Location = new System.Drawing.Point(8, 552);
            this.izbrisiRacunBtn.Margin = new System.Windows.Forms.Padding(2);
            this.izbrisiRacunBtn.Name = "izbrisiRacunBtn";
            this.izbrisiRacunBtn.Size = new System.Drawing.Size(94, 24);
            this.izbrisiRacunBtn.TabIndex = 6;
            this.izbrisiRacunBtn.Text = "Izbrisi racun";
            this.izbrisiRacunBtn.UseVisualStyleBackColor = true;
            this.izbrisiRacunBtn.Click += new System.EventHandler(this.izbrisiRacunBtn_Click);
            // 
            // pregledBtn
            // 
            this.pregledBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pregledBtn.Location = new System.Drawing.Point(8, 579);
            this.pregledBtn.Name = "pregledBtn";
            this.pregledBtn.Size = new System.Drawing.Size(94, 24);
            this.pregledBtn.TabIndex = 7;
            this.pregledBtn.Text = "Pregled racuna";
            this.pregledBtn.UseVisualStyleBackColor = true;
            this.pregledBtn.Click += new System.EventHandler(this.pregledBtn_Click);
            // 
            // RacunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 609);
            this.Controls.Add(this.pregledBtn);
            this.Controls.Add(this.izbrisiRacunBtn);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.valutaLbl);
            this.Controls.Add(this.sumaLbl);
            this.Controls.Add(this.ukupnoLbl);
            this.Controls.Add(this.izdajRacun_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RacunForm";
            this.Text = "Racun";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RacunForm_FormClosing);
            this.Load += new System.EventHandler(this.RacunForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button izdajRacun_btn;
        private System.Windows.Forms.Label ukupnoLbl;
        private System.Windows.Forms.Label sumaLbl;
        private System.Windows.Forms.Label valutaLbl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Artikal;
        private System.Windows.Forms.ColumnHeader Kolicina;
        private System.Windows.Forms.ColumnHeader Cena;
        private System.Windows.Forms.Button izbrisiRacunBtn;
        private System.Windows.Forms.Button pregledBtn;
    }
}