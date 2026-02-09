using Subastas_Final.Controllers;
using Subastas_Final.Entities;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Subastas_Final.Views
{
    public partial class RegistroSubastadorView : Form
    {
        private SubastadorController subastadorController;
        public Subastador Subastador { get; private set; }

        public RegistroSubastadorView()
        {
            InitializeComponent();
            subastadorController = new SubastadorController();

            // Conectar eventos KeyDown
            txtNombre.KeyDown += txtNombre_KeyDown;
            txtEmail.KeyDown += txtEmail_KeyDown;
        }

        
        private void btnGuardar_Click(object sender, EventArgs e)
{
    // 1️⃣ Validar que no estén vacíos
    if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
    {
        MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // 2️⃣ Validar email simple
    if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
    {
        MessageBox.Show("Ingresa un email válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    // 3️⃣ Crear objeto Subastador
    Subastador nuevoSubastador = new Subastador
    {
        Nombre = txtNombre.Text,
        Email = txtEmail.Text
    };

    // 4️⃣ Guardar usando el Controller, obtener el registrado (ya tiene ID correcto)
    Subastador registrado;
    bool creado = subastadorController.CrearSubastador(nuevoSubastador, out registrado);

    // 5️⃣ Asignar la propiedad para la ventana llamante
    this.Subastador = registrado;

    // 6️⃣ Mostrar mensaje según corresponda
    if (creado)
        MessageBox.Show("Registro exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
    else
        MessageBox.Show("Ya existe un subastador con ese email. Se cargaron sus datos existentes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

    // 7️⃣ Cerrar el formulario con resultado OK
    this.DialogResult = DialogResult.OK;
    this.Close();
}


        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // evita pitido
                txtEmail.Focus();          // pasa el foco al email
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;   // evita pitido
                btnGuardar.PerformClick();   // simula click en Guardar
            }
        }
    }
}
