using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Subastas_Final.Views
{
    public partial class SubastadorView : Form
    {
        private SubastadorRepository repo;
        private Subastador subastador;

        public SubastadorView(Subastador sub)
        {
            InitializeComponent();
            subastador = sub;
            repo = new SubastadorRepository();

            // Mostrar info del subastador en Labels
            lblBienvenido.Text = $"Bienvenid@ {subastador.Nombre}";
            lblId.Text = $"ID: {subastador.IdSubastador}";
            lblEmail.Text = $"Email: {subastador.Email}";
            dgvSubastadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubastadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubastadores.MultiSelect = false;

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
            try
            {
                var lista = repo.ObtenerTodosSubastadores()
                                .Select(s => new { s.IdSubastador, s.Nombre, s.Email })
                                .ToList();

                // Limpiar DataSource antes de asignar nueva lista
                dgvSubastadores.DataSource = null;
                dgvSubastadores.DataSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar subastadores: {ex.Message}");
            }
        }

        private void lblBienvenido_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSubastadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
