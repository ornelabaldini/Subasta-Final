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
            // después para seleccionar una subasta
        }

        private void cmbFiltroSubastas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYCargarSubastas();
        }

        private void FiltrarYCargarSubastas()
        {
            if (cmbFiltroSubastas.SelectedItem == null)
                return;

            try
            {
                var lista = subastaController.FiltrarSubastas(cmbFiltroSubastas.SelectedItem.ToString());
                dgvSubastas.DataSource = TransformarParaGrid(lista);
                AjustarColumnasSubastas(dgvSubastas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar subastas: {ex.Message}");
            }
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
                dgv.Columns["IdSubasta"].FillWeight = 50;

            if (dgv.Columns.Contains("Estado"))
                dgv.Columns["Estado"].FillWeight = 70;

            if (dgv.Columns.Contains("Pujas"))
                dgv.Columns["Pujas"].FillWeight = 60;

            if (dgv.Columns.Contains("FechaInicio"))
            {
                dgv.Columns["FechaInicio"].FillWeight = 100;
                dgv.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgv.Columns.Contains("FechaFin"))
            {
                dgv.Columns["FechaFin"].FillWeight = 140;
                dgv.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgv.Columns.Contains("Postores"))
            {
                dgv.Columns["Postores"].FillWeight = 200;
            }

            if (dgv.Columns.Contains("CantidadPostores"))
            {
                dgv.Columns["CantidadPostores"].HeaderText = "Postores";
                dgv.Columns["CantidadPostores"].FillWeight = 60;
            }

        }

        private void PostorView_Load(object sender, EventArgs e)
        {

        }

        private void btnPujar_Click(object sender, EventArgs e)
        {
            if (dgvSubastas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná una subasta para poder pujar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idSubasta = Convert.ToInt32(dgvSubastas.SelectedRows[0].Cells["IdSubasta"].Value);

            bool ok = subastaController.Pujar(idSubasta, postor);

            if (!ok)
            {
                MessageBox.Show(
                    "No se pudo realizar la puja. Puede ser que la subasta esté cerrada o que seas el subastador.",
                    "Puja rechazada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            MessageBox.Show("Puja realizada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FiltrarYCargarSubastas(); // recarga grilla para actualizar montos y pujas
        }

        private void btnCambiarRol_Click_1(object sender, EventArgs e)
        {
            var subastador = new Subastador
            {
                IdSubastador = postor.IdPostor,
                Nombre = postor.Nombre,
                Email = postor.Email
            };

            var vistaSubastador = new SubastadorView(subastador);
            vistaSubastador.Show();
            this.Close();
        }
    }
}
