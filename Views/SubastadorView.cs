using Subastas_Final.Entities;
using Subastas_Final.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Subastas_Final.Views
{
    public partial class SubastadorView : Form
    {
        private Subastador subastador;
        private Postor postor;
        private SubastaController subastaController;

        public SubastadorView(Subastador sub)
        {
            InitializeComponent();
            subastador = sub;

            cmbFiltroSubastas.SelectedIndex = 0; // filtro por defecto
            cmbFiltroSubastas.SelectedIndexChanged += CmbFiltroSubastas_SelectedIndexChanged;
            cmbFiltroSubastas.Items.AddRange(new string[]
            {
                "Subastas en curso",
                "Últimas 10 finalizadas",
            });

            cmbFiltroSubastas.SelectedIndex = 0;


            subastaController = new SubastaController();

            lblBienvenido.Text = $"Bienvenid@ {subastador.Nombre}";
            lblId.Text = $"ID: {subastador.IdSubastador}";
            lblEmail.Text = $"Email: {subastador.Email}";

            dgvSubastas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubastas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.MultiSelect = false;
            dgvSubastas.RowHeadersVisible = false;

            CargarSubastas();
        }

        private void CargarSubastas()
        {
            FiltrarYCargarSubastas(); // reutiliza el método filtrado
        }

        private void CmbFiltroSubastas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYCargarSubastas();
        }

        private void FiltrarYCargarSubastas()
        {
            if (cmbFiltroSubastas.SelectedItem == null || subastaController == null)
                return;

            try
            {
                var lista = subastaController.FiltrarSubastas(cmbFiltroSubastas.SelectedItem.ToString());
                dgvSubastas.DataSource = TransformarParaGrid(lista);
                AjustarColumnasSubastas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar subastas: {ex.Message}");
            }
        }

        private void btnCrearSubasta_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtArticulo.Text) ||
                    string.IsNullOrWhiteSpace(txtPrecioBase.Text) ||
                    string.IsNullOrWhiteSpace(txtPuja.Text))
                {
                    MessageBox.Show("Por favor completa todos los campos.");
                    return;
                }

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

                var subasta = new Subasta
                {
                    Articulo = new Articulo { Nombre = txtArticulo.Text },
                    PrecioBase = precioBase,
                    PujaMinima = pujaMinima,
                    MontoActual = precioBase,                  
                    FechaFin = dtpFechaFin.Value,
                    Estado = true,
                    Subastador = subastador
                };

                bool creada = subastaController.CrearSubasta(subasta);

                if (!creada)
                {
                    MessageBox.Show(
                        "La fecha fin debe ser al menos 1 hora posterior a la actual.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show("Subasta creada correctamente!");
                LimpiarCampos();
                CargarSubastas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear subasta: {ex.Message}");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSubastas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Para más adelante: seleccionar subasta
        }

        private void LimpiarCampos()
        {
            txtArticulo.Clear();
            txtPrecioBase.Clear();
            txtPuja.Clear();
            dtpFechaFin.Value = DateTime.Now.AddDays(1);
        }

        private void AjustarColumnasSubastas()
        {

            if (dgvSubastas.Columns.Contains("IdSubasta"))
                dgvSubastas.Columns["IdSubasta"].FillWeight = 50;

            if (dgvSubastas.Columns.Contains("Estado"))
                dgvSubastas.Columns["Estado"].FillWeight = 70;

            if (dgvSubastas.Columns.Contains("Pujas"))
                dgvSubastas.Columns["Pujas"].FillWeight = 60;

            if (dgvSubastas.Columns.Contains("FechaInicio"))
            {
                dgvSubastas.Columns["FechaInicio"].FillWeight = 140;
                dgvSubastas.Columns["FechaInicio"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvSubastas.Columns.Contains("FechaFin"))
            {
                dgvSubastas.Columns["FechaFin"].FillWeight = 140;
                dgvSubastas.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvSubastas.Columns.Contains("PujaMinima"))
            {
                dgvSubastas.Columns["PujaMinima"].HeaderText = "Puja mínima";
                dgvSubastas.Columns["PujaMinima"].FillWeight = 70;
            }

        }

        private List<object> TransformarParaGrid(List<Subasta> listaSubastas)
        {
            return listaSubastas
                .Where(s => s != null)
                .Select(s => new
                {
                 
                    Articulo = s.Articulo?.Nombre ?? "Sin artículo",
                    Estado = s.Estado ? "Activa" : "Cerrada",
                    Subastador = s.Subastador?.Nombre ?? "Sin subastador",
                    Pujas = s.Pujas?.Count ?? 0,
                    Postores = s.Postores != null && s.Postores.Any()
                                ? string.Join(", ", s.Postores.Select(p => p.Nombre))
                                : "Sin postores"
                })
                .ToList<object>();
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
                info += $"- ID: {s.IdSubastador},{s.Nombre},{s.Email}\n";

            // Mostrar en MessageBox
            MessageBox.Show(info, "Usuarios Registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
