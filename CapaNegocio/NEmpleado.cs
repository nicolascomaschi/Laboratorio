using CapaDatos;
using Entidades;
using System;
using System.Collections.Generic;
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
            Empleado empleado = new Empleado()
            {
                Id = id,
                Nombre = nombre,
                DNI = dni,
                Direccion = direccion,
            };
            DEmpleado.Guardar(empleado);
        }

        public static List<Empleado> Actualizar()
        {
            return DEmpleado.Actualizar();
        }
    }
}
