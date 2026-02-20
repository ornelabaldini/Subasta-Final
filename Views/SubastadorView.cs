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
        private SubastaController subastaController;
        private PostorController postorController;

        private List<int> subastasNotificadas = new List<int>();
        private Timer timer;
        public SubastadorView(Subastador sub)
        {
            InitializeComponent();

            subastador = sub;
            subastaController = new SubastaController();
            subastasNotificadas = new List<int>();
            postorController = new PostorController();

            cmbFiltroSubastas.Items.AddRange(new string[]
            {
             "Últimas 10 finalizadas",
            });

            cmbFiltroSubastas.SelectedIndexChanged += CmbFiltroSubastas_SelectedIndexChanged;
            cmbFiltroSubastas.SelectedIndex = 0; 

            lblBienvenido.Text = $"Bienvenid@ {subastador.Nombre}";
            lblId.Text = $"ID: {subastador.IdSubastador}";
            lblEmail.Text = $"Email: {subastador.Email}";

            dgvSubastas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSubastas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSubastas.MultiSelect = false;
            dgvSubastas.RowHeadersVisible = false;

            CargarSubastas();

            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            FiltrarYCargarSubastas();
        }

        private void CargarSubastas()
        {
            FiltrarYCargarSubastas(); 
        }

        private void CmbFiltroSubastas_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarYCargarSubastas();
        }

        private void FiltrarYCargarSubastas()
        {
            if (cmbFiltroSubastas.SelectedItem == null)
                return;

            subastaController.ActualizarSubastasVencidas();

            // Obtener solo las subastas de este subastador
            var listaSubastador = subastaController
                .ObtenerTodasSubastas()
                .Where(s => s.Subastador.IdSubastador == subastador.IdSubastador)
                .ToList();
      

            foreach (var s in listaSubastador)
            {
                if (!s.Estado && !subastasNotificadas.Contains(s.IdSubasta))
                {
                    decimal diferencia = s.IdGanador != 0
                        ? s.MontoActual - s.PrecioBase
                        : 0;

                    subastasNotificadas.Add(s.IdSubasta);
                    string mensaje;

                    if (s.IdGanador != 0)
                    {
                        var ganador = postorController.ObtenerPostorPorId(s.IdGanador);

                        mensaje =
                            $"La subasta de '{s.Articulo.Nombre}' finalizó.\n\n" +
                            $"Ganador: {ganador?.Nombre}\n" +
                            $"Monto final: {s.MontoActual}\n" +
                            $"Diferencia obtenida: {diferencia}";
                    }
                    else
                    {
                        mensaje =
                            $"La subasta de '{s.Articulo.Nombre}' finalizó sin ofertas.";
                    }
                    
                    MessageBox.Show(
                        mensaje,
                        "Subasta finalizada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                }
            }

            //  Aplicar filtro 
            var listaFiltrada = subastaController.FiltrarSubastas(
                cmbFiltroSubastas.SelectedItem.ToString()
            );

            dgvSubastas.DataSource = null;
            dgvSubastas.DataSource = TransformarParaGrid(listaFiltrada);

            AjustarColumnasSubastas();
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
            if (e.RowIndex < 0)
                return;

            int idSubasta = Convert.ToInt32(
                dgvSubastas.Rows[e.RowIndex].Cells["IdSubasta"].Value
            );

            var subasta = subastaController.ObtenerSubastaPorId(idSubasta);

            if (subasta == null)
                return;

            if (subasta.Estado)
            {
                return;
            }

            if (subasta.IdGanador == 0)
            {
                MessageBox.Show("La subasta finalizó sin ganador.");
                return;
            }

            var postorController = new PostorController();
            var ganador = postorController.ObtenerPostorPorId(subasta.IdGanador);

            decimal diferencia = subasta.MontoActual - subasta.PrecioBase;

            MessageBox.Show(
                $"RESULTADO DE LA SUBASTA\n\n" +
                $"Artículo: {subasta.Articulo.Nombre}\n" +
                $"Ganador: {ganador?.Nombre}\n" +
                $"Precio base: {subasta.PrecioBase}\n" +
                $"Monto final: {subasta.MontoActual}\n" +
                $"Diferencia obtenida: {diferencia}",
                "Resultado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

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
                dgvSubastas.Columns["IdSubasta"].FillWeight = 25;

            if (dgvSubastas.Columns.Contains("Estado"))
                dgvSubastas.Columns["Estado"].FillWeight = 60;

            if (dgvSubastas.Columns.Contains("Pujas"))
                dgvSubastas.Columns["Pujas"].FillWeight = 45;

            if (dgvSubastas.Columns.Contains("FechaFin"))
            {
                dgvSubastas.Columns["FechaFin"].FillWeight = 140;
                dgvSubastas.Columns["FechaFin"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }

            if (dgvSubastas.Columns.Contains("PujaMinima"))
            {
                dgvSubastas.Columns["PujaMinima"].HeaderText = "Puja mínima";
                dgvSubastas.Columns["PujaMinima"].FillWeight = 60;
            }

        }

        private List<object> TransformarParaGrid(List<Subasta> listaSubastas)
        {
            var postorController = new PostorController();

            return listaSubastas
                .Where(s => s != null)
                .Select(s => new
                {
                    IdSubasta = s.IdSubasta,
                    Articulo = s.Articulo.Nombre,
                    PrecioBase = s.PrecioBase,
                    PujaMinima = s.PujaMinima,
                    MontoActual = s.MontoActual,
                    Estado = s.Estado ? "Activa" : "Cerrada",
                    FechaFin = s.FechaFin,
                    Subastador = s.Subastador.Nombre,
                    Pujas = s.Pujas?.Count ?? 0,
                    VaGanando = s.IdGanador != 0
                    ? postorController.ObtenerPostorPorId(s.IdGanador)?.Nombre
                    : "Sin ganador",

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

            string info = " ~ POSTORES:\n";
            foreach (var p in postores)
                info += $"- ID: {p.IdPostor},{p.Nombre},{p.Email}\n";

            info += "\n~ SUBASTADORES:\n";
            foreach (var s in subastadores)
                info += $"- ID: {s.IdSubastador},{s.Nombre},{s.Email}\n";

            MessageBox.Show(info, "Usuarios Registrados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
