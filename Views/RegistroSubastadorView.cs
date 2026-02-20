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
    // Validar que no estén vacíos
    if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
    {
        MessageBox.Show("Por favor completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    //  Validar email simple
    if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
    {
        MessageBox.Show("Ingresa un email válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
    }

    //  Crear objeto Subastador
    Subastador nuevoSubastador = new Subastador
    {
        Nombre = txtNombre.Text,
        Email = txtEmail.Text
    };

    // Guardar usando el Controller, obtener el registrado
    Subastador registrado;
    bool creado = subastadorController.CrearSubastador(nuevoSubastador, out registrado);

    // Asignar la propiedad para la ventana llamante
    this.Subastador = registrado;

    if (creado)
        MessageBox.Show("Registro exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
    else
        MessageBox.Show("Ya existe un subastador con ese email. Se cargaron sus datos existentes.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
