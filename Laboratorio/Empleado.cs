using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio
{
    public class Empleado
    {
        private int _Id;
        private string _Nombre;
        private int _DNI;
        private string _Direccion;

        public int Id { get => _Id; set => _Id = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int DNI { get => _DNI; set => _DNI = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }

    }
}
