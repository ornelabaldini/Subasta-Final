using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Windows.Forms;

namespace Subastas_Final.Views
{
    public partial class PostorView : Form
    {
        private Postor postor;

        public PostorView(Postor post)
        {
            InitializeComponent();
            postor = post;

            // Mostrar info del postor en Labels
            lblBienvenido.Text = $"Bienvenid@ {postor.Nombre}";
            lblId.Text = $"ID: {postor.IdPostor}";
            lblEmail.Text = $"Email: {postor.Email}";

            // Configuración del DataGridView
            dgvPostores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPostores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPostores.MultiSelect = false;

            // Cargar los postores desde el inicio
            CargarPostores();
        }

        private void dgvPostores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnMostrarPostores_Click(object sender, EventArgs e)
        {
            dgvPostores.Visible = !dgvPostores.Visible;

            btnMostrarPostores.Text = dgvPostores.Visible
                ? "Ocultar postores"
                : "Mostrar postores";

            // Si abrís el grid, cargamos los datos
            if (dgvPostores.Visible)
            {
                CargarPostores();
            }
        }

        // Método para cargar los datos
        private void CargarPostores()
        {
            var repo = new PostorRepository();
            var lista = repo.ObtenerTodosPostores();
            MessageBox.Show(lista.Count.ToString());
            MessageBox.Show(lista.Count.ToString());
            dgvPostores.DataSource = null; // limpiar antes
            dgvPostores.DataSource = repo.ObtenerTodosPostores();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
