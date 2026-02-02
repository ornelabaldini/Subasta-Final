using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Subastas_Final.Views;
using Subastas_Final.Entities; 



namespace Subastas_Final
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (rbSubastador.Checked)
            {
                RegistroSubastadorView registro = new RegistroSubastadorView();
                if (registro.ShowDialog() == DialogResult.OK)
                {
                    Subastador sub = registro.Subastador;

                    // Aca podés llamar al Service para guardar en la lista o DB
                    SubastadorView frm = new SubastadorView(sub);
                    frm.Show();
                    
                }
            }
            else if (rbPostor.Checked)
            {
                RegistroPostorView registro = new RegistroPostorView();
                if (registro.ShowDialog() == DialogResult.OK)
                {
                    Postor post = registro.Postor;

                    // Aca podés llamar al Service para guardar en la lista o DB
                    PostorView frm = new PostorView(post);
                    frm.Show();
                    
                }
            }
        }


        private void Inicio_Load(object sender, EventArgs e)
        {

        }
    }

}

