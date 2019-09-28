using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Laboratorio
{
    public partial class frmEmpleadoListado : Form
    {
        Repositorio<Empleado> repo = new Repositorio<Empleado>();
        List<Empleado> list = new List<Empleado>();
        private string path = string.Empty;
        public List<Empleado> Mostrar()
        {
            List<Empleado> list = new List<Empleado>();
            list = repo.Read(path);
            return list;
        }
        public frmEmpleadoListado(string ruta, List<Empleado> list)
        {
            InitializeComponent();
            path = Tools.GetPath(ruta);
            this.list = list;
        }

        private void FrmEmpleadoListado_Load(object sender, EventArgs e)
        {
            empleadoBindingSource.DataSource = list;
        }

        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (Int32)dataListado.CurrentRow.Cells[2].Value;
            string nombre = dataListado.CurrentRow.Cells[3].Value.ToString();
            int dni = (Int32)dataListado.CurrentRow.Cells[4].Value;
            string direccion = dataListado.CurrentRow.Cells[1].Value.ToString();
            Empleado emp = new Empleado
            {
                Direccion = direccion,
                Dni = dni,
                Id = id,
                Nombre = nombre
            };
            list.Remove(emp);
            if (e.RowIndex == -1)
            {
                return;
            }
            empleadoBindingSource.DataSource = null;
            empleadoBindingSource.DataSource = list;
        }

        private void FrmEmpleadoListado_FormClosing(object sender, FormClosingEventArgs e)
        {
            repo.SaveList(list, path);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var repo = new RepositorioIdentificable<Empleado>();
            int val = int.Parse(txtBuscar.Text);
            var obj = repo.Find(val, list);
            empleadoBindingSource.DataSource = null;
            empleadoBindingSource.DataSource = obj;
        }

        private void TxtBuscar_KeyPress(object sender, KeyPressEventArgs e)
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
