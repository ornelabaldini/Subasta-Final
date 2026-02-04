namespace Subastas_Final.Views
{
    partial class SubastadorView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.dgvSubastas = new System.Windows.Forms.DataGridView();
            this.btnCrearrSubasta = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbFiltroSubastas = new System.Windows.Forms.ComboBox();
            this.lblFiltrarSubastas = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPujaMinima = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.txtPuja = new System.Windows.Forms.TextBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Impact", 14F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(114, 9);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(290, 35);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenid@ Subastador";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.White;
            this.lblId.Location = new System.Drawing.Point(480, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(34, 20);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID: ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(804, 21);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email: ";
            // 
            // dgvSubastas
            // 
            this.dgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubastas.Location = new System.Drawing.Point(22, 156);
            this.dgvSubastas.Name = "dgvSubastas";
            this.dgvSubastas.RowHeadersWidth = 62;
            this.dgvSubastas.RowTemplate.Height = 28;
            this.dgvSubastas.Size = new System.Drawing.Size(1001, 476);
            this.dgvSubastas.TabIndex = 3;
            this.dgvSubastas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubastas_CellContentClick);
            // 
            // btnCrearrSubasta
            // 
            this.btnCrearrSubasta.BackColor = System.Drawing.Color.Black;
            this.btnCrearrSubasta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearrSubasta.Font = new System.Drawing.Font("Javanese Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearrSubasta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCrearrSubasta.Location = new System.Drawing.Point(1050, 514);
            this.btnCrearrSubasta.Name = "btnCrearrSubasta";
            this.btnCrearrSubasta.Size = new System.Drawing.Size(226, 65);
            this.btnCrearrSubasta.TabIndex = 4;
            this.btnCrearrSubasta.Text = "Crear Subasta";
            this.btnCrearrSubasta.UseVisualStyleBackColor = false;
            this.btnCrearrSubasta.Click += new System.EventHandler(this.btnCrearSubasta_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Black;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolver.Location = new System.Drawing.Point(12, 12);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(72, 29);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbFiltroSubastas
            // 
            this.cmbFiltroSubastas.FormattingEnabled = true;
            this.cmbFiltroSubastas.Items.AddRange(new object[] {
            "Subastas en curso",
            "Últimas 10 finalizadas"});
            this.cmbFiltroSubastas.Location = new System.Drawing.Point(22, 109);
            this.cmbFiltroSubastas.Name = "cmbFiltroSubastas";
            this.cmbFiltroSubastas.Size = new System.Drawing.Size(172, 28);
            this.cmbFiltroSubastas.TabIndex = 7;
            this.cmbFiltroSubastas.SelectedIndexChanged += new System.EventHandler(this.CmbFiltroSubastas_SelectedIndexChanged);
            // 
            // lblFiltrarSubastas
            // 
            this.lblFiltrarSubastas.AutoSize = true;
            this.lblFiltrarSubastas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFiltrarSubastas.Location = new System.Drawing.Point(18, 76);
            this.lblFiltrarSubastas.Name = "lblFiltrarSubastas";
            this.lblFiltrarSubastas.Size = new System.Drawing.Size(121, 20);
            this.lblFiltrarSubastas.TabIndex = 8;
            this.lblFiltrarSubastas.Text = "Filtrar Subastas";
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblArticulo.Location = new System.Drawing.Point(1111, 156);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(62, 20);
            this.lblArticulo.TabIndex = 9;
            this.lblArticulo.Text = "Articulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(1029, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Precio Base";
            // 
            // lblPujaMinima
            // 
            this.lblPujaMinima.AutoSize = true;
            this.lblPujaMinima.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPujaMinima.Location = new System.Drawing.Point(1029, 411);
            this.lblPujaMinima.Name = "lblPujaMinima";
            this.lblPujaMinima.Size = new System.Drawing.Size(94, 20);
            this.lblPujaMinima.TabIndex = 11;
            this.lblPujaMinima.Text = "Puja mínima";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(1029, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fecha Fin";
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.Location = new System.Drawing.Point(1140, 368);
            this.txtPrecioBase.MaxLength = 10;
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(100, 26);
            this.txtPrecioBase.TabIndex = 13;
            this.txtPrecioBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(1029, 190);
            this.txtArticulo.MaxLength = 300;
            this.txtArticulo.Multiline = true;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtArticulo.Size = new System.Drawing.Size(247, 144);
            this.txtArticulo.TabIndex = 14;
            // 
            // txtPuja
            // 
            this.txtPuja.Location = new System.Drawing.Point(1140, 408);
            this.txtPuja.MaxLength = 10;
            this.txtPuja.Name = "txtPuja";
            this.txtPuja.Size = new System.Drawing.Size(100, 26);
            this.txtPuja.TabIndex = 16;
            this.txtPuja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Location = new System.Drawing.Point(1115, 447);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.ShowUpDown = true;
            this.dtpFechaFin.Size = new System.Drawing.Size(161, 26);
            this.dtpFechaFin.TabIndex = 17;
            // 
            // SubastadorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1300, 663);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.txtPuja);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.txtPrecioBase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPujaMinima);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.lblFiltrarSubastas);
            this.Controls.Add(this.cmbFiltroSubastas);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCrearrSubasta);
            this.Controls.Add(this.dgvSubastas);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblEmail);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "SubastadorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subastador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DataGridView dgvSubastas;
        private System.Windows.Forms.Button btnCrearrSubasta;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cmbFiltroSubastas;
        private System.Windows.Forms.Label lblFiltrarSubastas;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPujaMinima;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.TextBox txtPuja;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
    }
}
