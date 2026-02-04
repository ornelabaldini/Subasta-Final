using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using Subastas_Final.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Subastas_Final.Views
{
    public partial class PostorView : Form
    {
        private Postor postor;
        private PostorRepository postorRepo;
        private SubastaRepository subastaRepo;

        public PostorView(Postor post)
        {
            InitializeComponent();
            postor = post;

            // Inicializar repositorios
            postorRepo = new PostorRepository();
            subastaRepo = new SubastaRepository();

            // Mostrar info del postor en Labels
            lblBienvenido.Text = $"Bienvenid@ {postor.Nombre}";
            lblId.Text = $"ID: {postor.IdPostor}";
            lblEmail.Text = $"Email: {postor.Email}";

            // Configuración del DataGridView
            dgvSubastas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubastas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.MultiSelect = false;
            dgvSubastas.RowHeadersVisible = false;

            // Configurar ComboBox
            cmbFiltroSubastas.SelectedIndex = 0; // Por defecto "Subastas en curso"
            cmbFiltroSubastas.SelectedIndexChanged += cmbFiltroSubastas_SelectedIndexChanged;

            // Cargar subastas desde el inicio usando filtro
            FiltrarYCargarSubastas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSubastas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Podemos usar esto después para seleccionar una subasta
        }

        private void cmbFiltroSubastas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYCargarSubastas();
        }

        private void FiltrarYCargarSubastas()
        {
            try
            {
                var hoy = DateTime.Now;
                var lista = subastaRepo.ObtenerTodasSubastas().AsEnumerable();

                switch (cmbFiltroSubastas.SelectedItem.ToString())
                {
                    case "Subastas en curso":
                        lista = lista.Where(s => s.Estado && s.FechaInicio <= hoy && s.FechaFin >= hoy);
                        break;

                    case "Últimas 10 finalizadas":
                        lista = lista.Where(s => !s.Estado)
                                     .OrderByDescending(s => s.FechaFin)
                                     .Take(10);
                        break;

                    case "Subastas pendientes":
                        lista = lista.Where(s => s.FechaInicio > hoy);
                        break;
                }

                dgvSubastas.DataSource = lista
                    .Select(s => new
                    {
                        s.IdSubasta,
                        Articulo = s.Articulo?.Nombre,
                        PrecioBase = s.PrecioBase,
                        MontoActual = s.MontoActual,
                        Estado = s.Estado ? "Activa" : "Cerrada",
                        FechaInicio = s.FechaInicio,
                        FechaFin = s.FechaFin,
                        Subastador = s.Subastador?.Nombre,
                        Pujas = s.Pujas.Count,
                        Postores = string.Join(", ", s.Postores.Select(p => p.Nombre))
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar subastas: {ex.Message}");
            }
        }

        private void PostorView_Load(object sender, EventArgs e)
        {

        }

        private void btnPujar_Click(object sender, EventArgs e)
        {
            // 1. Validar selección
            if (dgvSubastas.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccioná una subasta para poder pujar.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var fila = dgvSubastas.SelectedRows[0];

            int idSubasta = Convert.ToInt32(fila.Cells["IdSubasta"].Value);
            string estado = fila.Cells["Estado"].Value.ToString();

            // 2. Validar que esté activa
            if (estado != "Activa")
            {
                MessageBox.Show(
                    "No podés pujar en una subasta cerrada.",
                    "Subasta no disponible",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 3. Solo prueba por ahora
            MessageBox.Show($"Subasta {idSubasta} activa. Podés pujar.");
        }

    }
}
