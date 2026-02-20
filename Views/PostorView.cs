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
        private PostorController postorController;
        private List<int> subastasNotificadas = new List<int>();
        private PujaController pujaController;
        private Timer timer;


        public PostorView(Postor post)
        {
            InitializeComponent();

            postor = post;
            subastaController = new SubastaController();
            pujaController = new PujaController();
            postorController = new PostorController();


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
            nudMonto.Maximum = 1000000000;
            nudMonto.Increment = 1;


            FiltrarYCargarSubastas();

            timer = new Timer();
            timer.Interval = 5000; 
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
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

            // Actualizar vencidas
            subastaController.ActualizarSubastasVencidas();

            // Revisar todas las subastas para notificación automática
            var todas = subastaController.ObtenerTodasSubastas();
            

            // Aplicar filtro para mostrar en la grilla
            var lista = subastaController.FiltrarSubastas(
                cmbFiltroSubastas.SelectedItem.ToString()
            );

            dgvSubastas.DataSource = null;
            dgvSubastas.DataSource = TransformarParaGrid(lista);

            AjustarColumnasSubastas(dgvSubastas);

            dgvSubastas_SelectionChanged(null, null);
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

                   //Diferencia = s.IdGanador != 0
                       // ? s.MontoActual - s.PrecioBase
                        //: 0

                })
                .ToList<object>();
        }

        private void AjustarColumnasSubastas(DataGridView dgv)
        {

            if (dgv.Columns.Contains("MontoActual"))
                dgv.Columns["MontoActual"].FillWeight = 80;

            if (dgvSubastas.Columns.Contains("IdSubasta"))
                dgvSubastas.Columns["IdSubasta"].FillWeight = 20;

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
            var subasta = subastaController.ObtenerSubastaPorId(idSubasta);

            if (subasta == null)
            {
                MessageBox.Show("Subasta no encontrada.");
                return;
            }

            if (!subasta.Estado)
            {
                MessageBox.Show("La subasta ya finalizó.");
                return;
            }


            decimal montoIngresado = nudMonto.Value;

            bool ok = pujaController.CrearPuja(idSubasta, postor, montoIngresado);


            if (!ok)
            {
                MessageBox.Show(
                    "La puja no es válida.\n\nPuede ser que:\n" +
                    "- No supere el monto mínimo\n" +
                    "- La subasta esté cerrada\n" +
                    "- Seas el subastador\n",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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

        private void dgvSubastas_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
