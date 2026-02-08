using Subastas_Final.Controllers;
using Subastas_Final.Entities;
using Subastas_Final.Repositories;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Subastas_Final.Views
{
    public partial class RegistroPostorView : Form
    {
        private PostorController postorController;
        public Postor Postor { get; private set; }

        public RegistroPostorView()
        {
            InitializeComponent();
            postorController = new PostorController();

            // Eventos para Enter
            txtNombre.KeyDown += txtNombre_KeyDown;
            txtEmail.KeyDown += txtEmail_KeyDown;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar email
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Ingresa un email válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear Postor
            Postor nuevoPostor = new Postor
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text
            };

            // Guardar en repositorio
            postorController.CrearPostor(nuevoPostor);

            // Pasar el Postor registrado a quien llamó
            this.Postor = nuevoPostor;

            MessageBox.Show("Registro exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Cerrar formulario con OK
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnGuardar.PerformClick();
            }
        }
    }
}
