using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidades;

namespace Laboratorio
{
    public partial class frmEmpleado : Form
    {
        Repositorio<Empleado> repo = new Repositorio<Empleado>();
        private string path = string.Empty;
        private List<Empleado> list = new List<Empleado>();
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

        public frmEmpleado(string ruta)
        {
            InitializeComponent();
            path = Tools.GetPath(ruta);
            list = repo.Read(path);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Empleado emp = new Empleado()
                {
                    Direccion = txtDireccion.Text,
                    Nombre = txtNombre.Text,
                    Id = Int32.Parse(txtId.Text),
                    Dni = Int32.Parse(txtDNI.Text),
                };
                repo.Save(emp, path);
                Limpiar();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {

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

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void BtnListado_Click(object sender, EventArgs e)
        {
            list = repo.Read(path);
            frmEmpleadoListado form = new frmEmpleadoListado(path, list);
            form.Show();
        }
    }
}
