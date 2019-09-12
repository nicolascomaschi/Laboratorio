using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Laboratorio
{
    public partial class frmPrincipal : Form
    {
        public List<string> obtenerArchivosDirectorio(string rutaArchivo)
        {
            List<string> listaRuta = new List<string>();
            listaRuta = Directory.GetFiles(Path.GetDirectoryName(rutaArchivo), Path.GetFileName(rutaArchivo)).ToList();
            return listaRuta;
        }

        public void CargarGrid()
        {
            List<string> lista = obtenerArchivosDirectorio("E:\\Datos\\*.json");
            DataTable dt = new DataTable("Archivos");
            dt.Columns.Add(new DataColumn("Archivo", typeof(string)));
            for (int i = 0; i < lista.Count; i++)
            {
                dt.Rows.Add(lista[i].ToString());
            }
            dataArchivos.DataSource = dt;
        }

        public frmPrincipal()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void DataArchivos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ruta = dataArchivos.CurrentRow.Cells[0].Value.ToString();
            frmEmpleado form = new frmEmpleado(ruta);
            form.Show();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string path = @"E:\\Datos\\"+this.textBox1.Text+".json";
            File.WriteAllText(path, "");
            this.textBox1.Text = string.Empty;
            CargarGrid();
        }
    }
}
