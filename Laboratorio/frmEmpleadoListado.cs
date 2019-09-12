using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Laboratorio
{
    public partial class frmEmpleadoListado : Form
    {
        Repositorio<Empleado> repo = new Repositorio<Empleado>();
        private string path = string.Empty;

        public List<Empleado> Mostrar()
        {
            List<Empleado> list = new List<Empleado>();
            list = repo.Read(path);
            return list;
        }
        public frmEmpleadoListado(string ruta)
        {
            InitializeComponent();
            path = Tools.GetPath(ruta);
            dataListado.DataSource = Mostrar();
        }

        private void FrmEmpleadoListado_Load(object sender, EventArgs e)
        {

        }

        private void DataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (Int32)dataListado.CurrentRow.Cells[1].Value;
            string nombre = dataListado.CurrentRow.Cells[2].Value.ToString();
            int dni = (Int32)dataListado.CurrentRow.Cells[3].Value;
            string direccion = dataListado.CurrentRow.Cells[4].Value.ToString();
            Empleado emp = new Empleado
            {
                Direccion = direccion,
                DNI = dni,
                Id = id,
                Nombre = nombre
            };

        }
    }
}
