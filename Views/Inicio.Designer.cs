namespace Subastas_Final
{
    partial class Inicio
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelPregunta = new System.Windows.Forms.Label();
            this.grpRol = new System.Windows.Forms.GroupBox();
            this.rbPostor = new System.Windows.Forms.RadioButton();
            this.rbSubastador = new System.Windows.Forms.RadioButton();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.grpRol.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.Font = new System.Drawing.Font("Impact", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(370, 44);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(470, 64);
            this.labelTitulo.TabIndex = 2;
            this.labelTitulo.Text = "Sistema de Subastas";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.labelTitulo.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelPregunta
            // 
            this.labelPregunta.AutoSize = true;
            this.labelPregunta.Font = new System.Drawing.Font("Javanese Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPregunta.Location = new System.Drawing.Point(468, 142);
            this.labelPregunta.Name = "labelPregunta";
            this.labelPregunta.Size = new System.Drawing.Size(278, 54);
            this.labelPregunta.TabIndex = 3;
            this.labelPregunta.Text = "¿Cómo desea ingresar?";
            this.labelPregunta.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // grpRol
            // 
            this.grpRol.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.grpRol.Controls.Add(this.rbPostor);
            this.grpRol.Controls.Add(this.rbSubastador);
            this.grpRol.Font = new System.Drawing.Font("Javanese Text", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRol.Location = new System.Drawing.Point(477, 215);
            this.grpRol.Name = "grpRol";
            this.grpRol.Size = new System.Drawing.Size(250, 120);
            this.grpRol.TabIndex = 4;
            this.grpRol.TabStop = false;
            this.grpRol.Text = "Seleccione su rol";
            this.grpRol.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbPostor
            // 
            this.rbPostor.AutoSize = true;
            this.rbPostor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbPostor.Location = new System.Drawing.Point(50, 75);
            this.rbPostor.Name = "rbPostor";
            this.rbPostor.Size = new System.Drawing.Size(90, 40);
            this.rbPostor.TabIndex = 1;
            this.rbPostor.Text = "Postor";
            this.rbPostor.UseVisualStyleBackColor = true;
            // 
            // rbSubastador
            // 
            this.rbSubastador.AutoSize = true;
            this.rbSubastador.Checked = true;
            this.rbSubastador.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rbSubastador.Location = new System.Drawing.Point(50, 28);
            this.rbSubastador.Name = "rbSubastador";
            this.rbSubastador.Size = new System.Drawing.Size(129, 40);
            this.rbSubastador.TabIndex = 0;
            this.rbSubastador.TabStop = true;
            this.rbSubastador.Text = "Subastador";
            this.rbSubastador.UseMnemonic = false;
            this.rbSubastador.UseVisualStyleBackColor = true;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnIngresar.Font = new System.Drawing.Font("Impact", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIngresar.Location = new System.Drawing.Point(511, 385);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(165, 53);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // Inicio
            // 
            this.AcceptButton = this.btnIngresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(1198, 544);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.grpRol);
            this.Controls.Add(this.labelPregunta);
            this.Controls.Add(this.labelTitulo);
            this.Font = new System.Drawing.Font("Impact", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio - Subastas";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.grpRol.ResumeLayout(false);
            this.grpRol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelPregunta;
        private System.Windows.Forms.GroupBox grpRol;
        private System.Windows.Forms.RadioButton rbPostor;
        private System.Windows.Forms.RadioButton rbSubastador;
        private System.Windows.Forms.Button btnIngresar;
    }
}

