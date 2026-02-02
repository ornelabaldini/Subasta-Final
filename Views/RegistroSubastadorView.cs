using System;
using System.Windows.Forms;
using Subastas_Final.Entities;
using System.Text.RegularExpressions;
using Subastas_Final.Repositories;

namespace Subastas_Final.Views
{
    public partial class RegistroSubastadorView : Form
    {
        private SubastadorRepository subastadorRepository; 
        public Subastador Subastador { get; private set; }

        public RegistroSubastadorView()
        {
            InitializeComponent();
            subastadorRepository = new SubastadorRepository(); 
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

            // Crear objeto Subastador
            Subastador nuevoSubastador = new Subastador
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text
            };

            // Guardar en el repositorio
            subastadorRepository.CrearSubastador(nuevoSubastador);

            // Asignar la propiedad para que la ventana que llamó pueda acceder al nuevo Subastador
            this.Subastador = nuevoSubastador;

            MessageBox.Show("Registro exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Setear el resultado OK para indicar éxito y cerrar el formulario
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RegistroSubastadorView_Load(object sender, EventArgs e)
        {
            // Icializar, o dejarlo vacío
        }
        private void lblEmail_Click(object sender, EventArgs e)
        {
            // No se hace nada al hacer click en una etiqueta
        }


    }
}
