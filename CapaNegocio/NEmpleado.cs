using CapaDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;

namespace CapaNegocio
{
    public class NEmpleado
    {
        public static string GetPath()
        {
            string pathCompleto = Path.Combine(Environment.CurrentDirectory, "Empleado.json");
            return pathCompleto;
        }
        public static void Guardar(int id, string nombre, int dni, string direccion)
        {
            DEmpleado empleado = new DEmpleado()
            {
                Id = id,
                Nombre = nombre,
                DNI = dni,
                Direccion = direccion,
            };
            //string pathCompleto = Path.Combine(path, "Empleado.json");
            string jsonObj = JsonConvert.SerializeObject(empleado);
            using (StreamWriter file = new StreamWriter(GetPath(), true))
            {
                file.Write(jsonObj);
                file.Close();
            }
        }

        public static DataTable Actualizar()
        {
            List<DEmpleado> list = new List<DEmpleado>();
            //string pathCompleto = Path.Combine(GetPath(), "Empleado.json");
            string line = "";
            using (StreamReader file = new StreamReader(GetPath()))
            {
                //while ((line = file.ReadLine()) != null)
                //{
                //    DEmpleado empleado = JsonConvert.DeserializeObject<DEmpleado>(line);
                //    list.Add(empleado);
                //}
                line = file.ReadToEnd();
                DataTable dTable = (DataTable)JsonConvert.DeserializeObject(line, (typeof(DataTable)));
                return dTable;
            }
        }
    }
}
