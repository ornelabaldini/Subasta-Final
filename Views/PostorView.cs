using Subastas_Final.Controllers;
using Subastas_Final.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Subastas_Final.Views
{
    public partial class PostorView : Form
    {
        private Postor postor;
        private Subastador subastador;
        private SubastaController subastaController;

        public PostorView(Postor post)
        {
            InitializeComponent();

            postor = post;
            subastaController = new SubastaController();

            lblBienvenido.Text = $"Bienvenid@ {postor.Nombre}";
            lblId.Text = $"ID: {postor.IdPostor}";
            lblEmail.Text = $"Email: {postor.Email}";

            dgvSubastas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubastas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.MultiSelect = false;
            dgvSubastas.RowHeadersVisible = false;

            cmbFiltroSubastas.SelectedIndex = 0;
            cmbFiltroSubastas.SelectedIndexChanged += cmbFiltroSubastas_SelectedIndexChanged;

            dgvSubastas.SelectionChanged += dgvSubastas_SelectionChanged;

            nudMonto.DecimalPlaces = 0;
            nudMonto.Minimum = 0;
            nudMonto.Maximum = 1000000000; // o decimal.MaxValue
            nudMonto.Increment = 1;


            FiltrarYCargarSubastas();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFiltroSubastas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYCargarSubastas();
        }

        private void FiltrarYCargarSubastas()
        {
            if (cmbFiltroSubastas.SelectedItem == null)
                return;

            var lista = subastaController.FiltrarSubastas(
                cmbFiltroSubastas.SelectedItem.ToString()
            );

            dgvSubastas.DataSource = null;
            dgvSubastas.DataSource = TransformarParaGrid(lista);

            AjustarColumnasSubastas(dgvSubastas);

            // fuerza actualización del mínimo al refrescar
            dgvSubastas_SelectionChanged(null, null);
        }

        private List<object> TransformarParaGrid(List<Subasta> listaSubastas)
        {
            return listaSubastas
                .Where(s => s != null)
                .Select(s => new
                {
                    IdSubasta = s.IdSubasta,
                    Articulo = s.Articulo?.Nombre ?? "Sin artículo",
                    PrecioBase = s.PrecioBase,
                    PujaMinima = s.PujaMinima,
                    MontoActual = s.MontoActual,
                    Estado = s.Estado ? "Activa" : "Cerrada",
                    FechaInicio = s.FechaInicio,
                    FechaFin = s.FechaFin,
                    Subastador = s.Subastador?.Nombre ?? "Sin subastador",
                    Pujas = s.Pujas?.Count ?? 0,
                    Postores = s.Postores != null && s.Postores.Any()
                                ? string.Join(", ", s.Postores.Select(p => p.Nombre))
                                : "Sin postores"
                })
                .ToList<object>();
        }

        private void AjustarColumnasSubastas(DataGridView dgv)
        {
            if (dgv.Columns.Contains("IdSubasta"))
                dgv.Columns["IdSubasta"].FillWeight = 40;

            if (dgv.Columns.Contains("PujaMinima"))
                dgv.Columns["PujaMinima"].FillWeight = 60;

            if (dgv.Columns.Contains("MontoActual"))
                dgv.Columns["MontoActual"].FillWeight = 70;

            if (dgv.Columns.Contains("Pujas"))
                dgv.Columns["Pujas"].FillWeight = 50;

            if (dgv.Columns.Contains("FechaInicio"))
                dgv.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            if (dgv.Columns.Contains("FechaFin"))
                dgv.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
        }

        private void dgvSubastas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSubastas.SelectedRows.Count == 0)
                return;

            int idSubasta = Convert.ToInt32(
                dgvSubastas.SelectedRows[0].Cells["IdSubasta"].Value
            );

            var subasta = subastaController.ObtenerSubastaPorId(idSubasta);
            if (subasta == null) return;

            decimal minimo = subasta.MontoActual + subasta.PujaMinima;

            nudMonto.Minimum = 0;

 
        }


        private void btnPujar_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná una subasta.", "Atención");
                return;
            }

            int idSubasta = Convert.ToInt32(
                dgvSubastas.SelectedRows[0].Cells["IdSubasta"].Value
            );

            decimal montoIngresado = nudMonto.Value;

            bool ok = subastaController.Pujar(idSubasta, postor, montoIngresado);

            if (!ok)
            {
                MessageBox.Show("La puja no cumple el mínimo.", "Error");
                return;
            }

            MessageBox.Show("Puja realizada correctamente");

            FiltrarYCargarSubastas();
        }

        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            var postorController = new PostorController();
            var subastadorController = new SubastadorController();

            // Obtener listas
            var postores = postorController.ObtenerTodosPostores();
            var subastadores = subastadorController.ObtenerTodosSubastadores();

            // Construir texto para mostrar
            string info = " ~ POSTORES:\n";
            foreach (var p in postores)
                info += $"- ID: {p.IdPostor},{p.Nombre},{p.Email}\n";

            info += "\n~ SUBASTADORES:\n";
            foreach (var s in subastadores)
                info += $"-ID: {s.IdSubastador},{s.Nombre},{s.Email}\n";

            // Mostrar en MessageBox
            MessageBox.Show(info, "Usuarios Registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
