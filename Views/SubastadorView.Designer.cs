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
            this.dgvSubastadores = new System.Windows.Forms.DataGridView();
            this.btnMostrarSubastadores = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastadores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Impact", 14F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(260, 20);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(290, 35);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenid@ Subastador";
            this.lblBienvenido.Click += new System.EventHandler(this.lblBienvenido_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.ForeColor = System.Drawing.Color.White;
            this.lblId.Location = new System.Drawing.Point(50, 80);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(34, 20);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID: ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(50, 110);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 20);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email: ";
            // 
            // dgvSubastadores
            // 
            this.dgvSubastadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubastadores.Location = new System.Drawing.Point(12, 239);
            this.dgvSubastadores.Name = "dgvSubastadores";
            this.dgvSubastadores.RowHeadersWidth = 62;
            this.dgvSubastadores.RowTemplate.Height = 28;
            this.dgvSubastadores.Size = new System.Drawing.Size(616, 188);
            this.dgvSubastadores.TabIndex = 3;
            this.dgvSubastadores.Visible = false;
            this.dgvSubastadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubastadores_CellContentClick);
            // 
            // btnMostrarSubastadores
            // 
            this.btnMostrarSubastadores.BackColor = System.Drawing.Color.Black;
            this.btnMostrarSubastadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarSubastadores.Font = new System.Drawing.Font("Javanese Text", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarSubastadores.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMostrarSubastadores.Location = new System.Drawing.Point(12, 181);
            this.btnMostrarSubastadores.Name = "btnMostrarSubastadores";
            this.btnMostrarSubastadores.Size = new System.Drawing.Size(226, 38);
            this.btnMostrarSubastadores.TabIndex = 4;
            this.btnMostrarSubastadores.Text = "Mostrar Subastadores";
            this.btnMostrarSubastadores.UseVisualStyleBackColor = false;
            this.btnMostrarSubastadores.Click += new System.EventHandler(this.btnMostrarSubastadores_Click);
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
            // SubastadorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnMostrarSubastadores);
            this.Controls.Add(this.dgvSubastadores);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblEmail);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "SubastadorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subastador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubastadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DataGridView dgvSubastadores;
        private System.Windows.Forms.Button btnMostrarSubastadores;
        private System.Windows.Forms.Button btnVolver;
    }
}
