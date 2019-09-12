using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CapaDatos
{
    public class DEmpleado
    {
        public static string GetPath()
        {
            string pathCompleto = Path.Combine(Environment.CurrentDirectory, "Empleado.json");
            return pathCompleto;
        }
        public static void Guardar(Empleado empleado)
        {
            string jsonObj = JsonConvert.SerializeObject(empleado);
            using (StreamWriter file = new StreamWriter(GetPath(), true))
            {
                file.WriteLine(jsonObj);
                file.Close();
            }
        }
        public static List<Empleado> Actualizar()
        {
            List<Empleado> list = new List<Empleado>();
            string line = "";
            using (StreamReader file = new StreamReader(GetPath()))
            {
                while ((line = file.ReadLine()) != null)
                {
                    Empleado empleado = JsonConvert.DeserializeObject<Empleado>(line);
                    list.Add(empleado);
                }
                return list;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private List<Empleado> listEmp = new List<Empleado>();

        public List<Empleado> GetList()
        {
            return listEmp;
        }

        public void AddEmpleado(Empleado empleado)
        {
            listEmp.Add(empleado);
        }

        public void DeleteEmpleado(Empleado empleado)
        {
            listEmp.Remove(empleado);
        }

        public void Save(Empleado empleado)
        {
            string jsonObj = JsonConvert.SerializeObject(empleado);
            using (StreamWriter file = new StreamWriter(GetPath(), true))
            {
                file.WriteLine(jsonObj);
                file.Close();
            }
        }

        public List<Empleado> Read()
        {
            string line = "";
            using (StreamReader file = new StreamReader(GetPath()))
            {
                while ((line = file.ReadLine()) != null)
                {
                    Empleado empleado = JsonConvert.DeserializeObject<Empleado>(line);
                    listEmp.Add(empleado);
                }
                return listEmp;
            }
        }

        public Empleado Find(int id)
        {
            return listEmp.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}
