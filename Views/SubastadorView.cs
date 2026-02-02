using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Windows.Forms;

namespace Subastas_Final.Views
{
    public partial class SubastadorView : Form
    {
        private Subastador subastador;

        public SubastadorView(Subastador sub)
        {
            InitializeComponent();
            subastador = sub;

            // Mostrar info del subastador en Labels
            lblBienvenido.Text = $"Bienvenid@ {subastador.Nombre}";
            lblId.Text = $"ID: {subastador.IdSubastador}";
            lblEmail.Text = $"Email: {subastador.Email}";
        }

        private void btnMostrarSubastadores_Click(object sender, EventArgs e)
        {
            dgvSubastadores.Visible = !dgvSubastadores.Visible;

            btnMostrarSubastadores.Text = dgvSubastadores.Visible
                ? "Ocultar subastadores"
                : "Mostrar subastadores";

            if (dgvSubastadores.Visible)
            {
                CargarSubastadores();
            }
        }

        private void CargarSubastadores()
        {
            var repo = new SubastadorRepository();
            dgvSubastadores.DataSource = null;
            dgvSubastadores.DataSource = repo.ObtenerTodosSubastadores();
        }

        private void lblBienvenido_Click(object sender, EventArgs e)
        {

        }
    }
}
