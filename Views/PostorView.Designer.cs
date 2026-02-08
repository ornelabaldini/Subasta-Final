namespace Subastas_Final.Views
{
    partial class PostorView
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
            this.btnPujar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblFiltrarSubastas = new System.Windows.Forms.Label();
            this.cmbFiltroSubastas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCambiarRol = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Impact", 14F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(117, 9);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(231, 35);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenid@ Postor";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.White;
            this.lblId.Location = new System.Drawing.Point(391, 16);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(34, 20);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID: ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(665, 16);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email: ";
            // 
            // dgvSubastas
            // 
            this.dgvSubastas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubastas.Location = new System.Drawing.Point(12, 232);
            this.dgvSubastas.Name = "dgvSubastas";
            this.dgvSubastas.RowHeadersWidth = 62;
            this.dgvSubastas.RowTemplate.Height = 28;
            this.dgvSubastas.Size = new System.Drawing.Size(939, 378);
            this.dgvSubastas.TabIndex = 3;
            this.dgvSubastas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubastas_CellContentClick);
            // 
            // btnPujar
            // 
            this.btnPujar.BackColor = System.Drawing.Color.Black;
            this.btnPujar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPujar.Font = new System.Drawing.Font("Javanese Text", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPujar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPujar.Location = new System.Drawing.Point(669, 128);
            this.btnPujar.Name = "btnPujar";
            this.btnPujar.Size = new System.Drawing.Size(137, 65);
            this.btnPujar.TabIndex = 4;
            this.btnPujar.Text = "Pujar";
            this.btnPujar.UseVisualStyleBackColor = false;
            this.btnPujar.Click += new System.EventHandler(this.btnPujar_Click);
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
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblFiltrarSubastas
            // 
            this.lblFiltrarSubastas.AutoSize = true;
            this.lblFiltrarSubastas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFiltrarSubastas.Location = new System.Drawing.Point(12, 147);
            this.lblFiltrarSubastas.Name = "lblFiltrarSubastas";
            this.lblFiltrarSubastas.Size = new System.Drawing.Size(121, 20);
            this.lblFiltrarSubastas.TabIndex = 9;
            this.lblFiltrarSubastas.Text = "Filtrar Subastas";
            // 
            // cmbFiltroSubastas
            // 
            this.cmbFiltroSubastas.FormattingEnabled = true;
            this.cmbFiltroSubastas.Items.AddRange(new object[] {
            "Subastas en curso",
            "Últimas 10 finalizadas"});
            this.cmbFiltroSubastas.Location = new System.Drawing.Point(12, 185);
            this.cmbFiltroSubastas.Name = "cmbFiltroSubastas";
            this.cmbFiltroSubastas.Size = new System.Drawing.Size(172, 28);
            this.cmbFiltroSubastas.TabIndex = 10;
            this.cmbFiltroSubastas.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroSubastas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(643, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Seleccioná una  subasta";
            // 
            // btnCambiarRol
            // 
            this.btnCambiarRol.Location = new System.Drawing.Point(999, 392);
            this.btnCambiarRol.Name = "btnCambiarRol";
            this.btnCambiarRol.Size = new System.Drawing.Size(194, 29);
            this.btnCambiarRol.TabIndex = 12;
            this.btnCambiarRol.Text = "Cambiar a Subastador";
            this.btnCambiarRol.UseVisualStyleBackColor = true;
            this.btnCambiarRol.Click += new System.EventHandler(this.btnCambiarRol_Click_1);
            // 
            // PostorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1450, 622);
            this.Controls.Add(this.btnCambiarRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbFiltroSubastas);
            this.Controls.Add(this.lblFiltrarSubastas);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnPujar);
            this.Controls.Add(this.dgvSubastas);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblEmail);
            this.Name = "PostorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postor";
            this.Load += new System.EventHandler(this.PostorView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DataGridView dgvSubastas;
        private System.Windows.Forms.Button btnPujar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblFiltrarSubastas;
        private System.Windows.Forms.ComboBox cmbFiltroSubastas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCambiarRol;
    }
}
