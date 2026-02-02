using System;
using System.Windows.Forms;
using Subastas_Final.Entities;
using System.Text.RegularExpressions;
using Subastas_Final.Repositories;

namespace Subastas_Final.Views
{
    public partial class RegistroPostorView : Form
    {
        private PostorRepository postorRepository;
        public Postor Postor { get; private set; }

        public RegistroPostorView()
        {
            InitializeComponent();
            postorRepository = new PostorRepository();

        }

        private void RegistroPostorView_Load(object sender, EventArgs e)
        {

        }

        private void lblBienvenido_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar que no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar email simple
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingresa un email válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear objeto Postor
            Postor nuevoPostor = new Postor
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text
            };

            // Guardar en el repositorio
            postorRepository.CrearPostor(nuevoPostor);

            // Asignar la propiedad para que la ventana que llamó pueda acceder al nuevo Postor
            this.Postor = nuevoPostor;

            MessageBox.Show("Registro exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Setear el resultado OK para indicar éxito y cerrar el formulario
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
