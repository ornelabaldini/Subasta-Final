using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Subastas_Final.Views
{
    public partial class SubastadorView : Form
    {
        private Subastador subastador;
        private SubastadorRepository subRepo;
        private SubastaRepository subastaRepo;

        public SubastadorView(Subastador sub)
        {
            InitializeComponent();
            subastador = sub;

            // Configurar ComboBox
            cmbFiltroSubastas.SelectedIndex = 0; // Por defecto "Subastas en curso"
            cmbFiltroSubastas.SelectedIndexChanged += CmbFiltroSubastas_SelectedIndexChanged;

            // Inicializar repositorios
            subRepo = new SubastadorRepository();
            subastaRepo = new SubastaRepository();

            // Mostrar info del subastador en Labels
            lblBienvenido.Text = $"Bienvenid@ {subastador.Nombre}";
            lblId.Text = $"ID: {subastador.IdSubastador}";
            lblEmail.Text = $"Email: {subastador.Email}";

            // Configurar DataGridView
            dgvSubastas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubastas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.MultiSelect = false;
            dgvSubastas.RowHeadersVisible = false;

            // Cargar subastas en el grid
            CargarSubastas();
        }

        private void CargarSubastas()
        {
            try
            {
                var lista = subastaRepo.ObtenerTodasSubastas()
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

                dgvSubastas.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar subastas: {ex.Message}");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSubastas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Más adelante podemos usar esto para seleccionar una subasta
        }

        private void lblBienvenido_Click(object sender, EventArgs e)
        {
            // Sin funcionalidad por ahora
        }

        private void CmbFiltroSubastas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYCargarSubastas();
        }
        private void FiltrarYCargarSubastas()
        {
            try
            {
                var hoy = DateTime.Now;
                var lista = new SubastaRepository().ObtenerTodasSubastas().AsEnumerable();

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar campos
                if (string.IsNullOrWhiteSpace(txtArticulo.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioBase.Text) ||
                    string.IsNullOrWhiteSpace(txtPuja.Text))
                {
                    MessageBox.Show("Por favor completa todos los campos.");
                    return;
                }

                // Parsear números
                if (!decimal.TryParse(txtPrecioBase.Text, out decimal precioBase))
                {
                    MessageBox.Show("Precio base inválido.");
                    return;
                }

                if (!decimal.TryParse(txtPuja.Text, out decimal pujaMinima))
                {
                    MessageBox.Show("Puja mínima inválida.");
                    return;
                }

                // Crear subasta
                var subasta = new Subasta
                {
                    Articulo = new Articulo
                    {
                        Nombre = txtArticulo.Text
                    },
                    PrecioBase = precioBase,
                    MontoActual = precioBase, // inicia en precio base
                    //PujaMinima = pujaMinima,
                    FechaInicio = DateTime.Now,
                    FechaFin = dtpFechaFin.Value,
                    Estado = true,
                    Subastador = subastador // el subastador logueado
                };

                // Guardar en DB
                subastaRepo.CrearSubasta(subasta);

                MessageBox.Show("Subasta creada correctamente!");
                LimpiarCampos();
                CargarSubastas(); // actualizar DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear subasta: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            txtArticulo.Clear();
            txtPrecioBase.Clear();
            txtPuja.Clear();
            dtpFechaFin.Value = DateTime.Now.AddDays(1); // valor por defecto
        }



    }
}
