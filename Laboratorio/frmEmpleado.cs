using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                List<Empleado> EmpleadoList = new List<Empleado>();
                Empleado empleado = new Empleado()
                {
                    Id = Int32.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    DNI = Int32.Parse(txtDNI.Text),
                    Direccion = txtDireccion.Text,
                };
                EmpleadoList.Add(empleado);
                var jsonList = JsonConvert.SerializeObject(EmpleadoList);
                string path = @"e:\empleado.json";
                File.WriteAllText(path, jsonList);
                Limpiar();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            string path = @"e:\empleado.json";
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                List<Empleado> empleado = JsonConvert.DeserializeObject<List<Empleado>>(json);
                Empleado empleado1 = new Empleado();
                empleado1 = empleado.First();
                txtId.Text = empleado1.Id.ToString();
                txtNombre.Text = empleado1.Nombre.ToString();
                txtDNI.Text = empleado1.DNI.ToString();
                txtDireccion.Text = empleado1.Direccion;
            }
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
