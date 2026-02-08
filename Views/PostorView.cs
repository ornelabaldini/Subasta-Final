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
        private SubastaService subastaService;

        public PostorView(Postor post)
        {
            InitializeComponent();
            postor = post;

            // Inicializar repositorios
            subastaService = new SubastaService();
     
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
            try
            {
                var hoy = DateTime.Now;
                var lista = subastaService.ObtenerTodasSubastas().AsEnumerable();

                switch (cmbFiltroSubastas.SelectedItem.ToString())
                {
                    case "Subastas en curso":
                        lista = lista.Where(s => s.Estado);
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
                        CantidadPostores = s.Pujas
                            .Select(p => p.Postor.IdPostor)
                            .Distinct()
                            .Count(),

                        Postores = string.Join(", ",
                            s.Pujas
                                .Select(p => p.Postor.Nombre)
                                .Distinct()
                        )

                    })
                    .ToList();
                AjustarColumnasSubastas(dgvSubastas);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar subastas: {ex.Message}");
            }
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
            //  Validar selección
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

            //  Obtener ID de la subasta
            int idSubasta = Convert.ToInt32(
                dgvSubastas.SelectedRows[0].Cells["IdSubasta"].Value
            );

            //  Llamar al service
            bool ok = subastaService.Pujar(idSubasta, postor);

            if (!ok)
            {
                MessageBox.Show(
                    "No se pudo realizar la puja. La subasta puede estar cerrada.",
                    "Puja rechazada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            MessageBox.Show(
                "Puja realizada correctamente.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            // Refrescar grilla
            FiltrarYCargarSubastas();
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
