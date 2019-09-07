using System;
using System.Windows.Forms;
using CapaNegocio;

namespace Laboratorio
{
    public partial class frmEmpleado : Form
    {
        public bool Validar()
        {
            if (txtId.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese un ID valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtNombre.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese un Nombre valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (txtDNI.Text == string.Empty)
            {
                MessageBox.Show("Por favor ingrese un DNI valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        public void Limpiar()
        {
            txtDireccion.Text = string.Empty;
            txtDNI.Text = string.Empty;
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        public void Mostrar()
        {
            dataListado.DataSource = NEmpleado.Actualizar();
        }

        public frmEmpleado()
        {
            InitializeComponent();
            Mostrar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                NEmpleado.Guardar(Int32.Parse(txtId.Text), txtNombre.Text, Int32.Parse(txtDNI.Text), txtDireccion.Text);
                Limpiar();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void TxtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void TxtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
