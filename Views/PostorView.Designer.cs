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
            this.dgvPostores = new System.Windows.Forms.DataGridView();
            this.btnMostrarPostores = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Impact", 14F);
            this.lblBienvenido.ForeColor = System.Drawing.Color.White;
            this.lblBienvenido.Location = new System.Drawing.Point(260, 20);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(231, 35);
            this.lblBienvenido.TabIndex = 0;
            this.lblBienvenido.Text = "Bienvenid@ Postor";
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
            // dgvPostores
            // 
            this.dgvPostores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPostores.Location = new System.Drawing.Point(12, 223);
            this.dgvPostores.Name = "dgvPostores";
            this.dgvPostores.RowHeadersWidth = 62;
            this.dgvPostores.RowTemplate.Height = 28;
            this.dgvPostores.Size = new System.Drawing.Size(641, 215);
            this.dgvPostores.TabIndex = 3;
            this.dgvPostores.Visible = false;
            this.dgvPostores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPostores_CellContentClick);
            // 
            // btnMostrarPostores
            // 
            this.btnMostrarPostores.BackColor = System.Drawing.Color.Black;
            this.btnMostrarPostores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarPostores.Font = new System.Drawing.Font("Javanese Text", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarPostores.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMostrarPostores.Location = new System.Drawing.Point(12, 162);
            this.btnMostrarPostores.Name = "btnMostrarPostores";
            this.btnMostrarPostores.Size = new System.Drawing.Size(221, 37);
            this.btnMostrarPostores.TabIndex = 4;
            this.btnMostrarPostores.Text = "Mostrar Postores";
            this.btnMostrarPostores.UseVisualStyleBackColor = false;
            this.btnMostrarPostores.Click += new System.EventHandler(this.btnMostrarPostores_Click);
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
            // PostorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnMostrarPostores);
            this.Controls.Add(this.dgvPostores);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblEmail);
            this.Name = "PostorView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Postor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.DataGridView dgvPostores;
        private System.Windows.Forms.Button btnMostrarPostores;
        private System.Windows.Forms.Button btnVolver;
    }
}
