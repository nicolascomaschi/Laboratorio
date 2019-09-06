using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CapaDatos;

namespace Laboratorio
{
    public partial class frmEmpleado : Form
    {
        public string GetPath()
        {
            string path = Path.Combine(Application.StartupPath, "emplado.json");
            return path;
        }
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
                List<DEmpleado> EmpleadoList = new List<DEmpleado>();
                DEmpleado empleado = new DEmpleado()
                {
                    Id = Int32.Parse(txtId.Text),
                    Nombre = txtNombre.Text,
                    DNI = Int32.Parse(txtDNI.Text),
                    Direccion = txtDireccion.Text,
                };
                EmpleadoList.Add(empleado);
                var jsonList = JsonConvert.SerializeObject(EmpleadoList);
                string path = GetPath();
                File.WriteAllText(path, jsonList);
                Limpiar();
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            string path = GetPath();
            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                List<DEmpleado> empleado = JsonConvert.DeserializeObject<List<DEmpleado>>(json);
                DEmpleado empleado1 = new DEmpleado();
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
