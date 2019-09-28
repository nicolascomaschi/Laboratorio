using System;

namespace Entidades
{
    [Serializable]
    public class Empleado : Persona, ICopiable<Empleado>, IEquatable<Empleado>
    {
        private string _Direccion;
        public string Direccion { get => _Direccion; set => _Direccion = value; }

        public Empleado()
        {
            Id = 0;
            Nombre = string.Empty;
            Dni = 0;
        }
        public void CopiarDesde(Empleado origen)
        {
            this.Id = origen.Id;
            this.Nombre = origen.Nombre;
            this.Dni = origen.Dni;
            this.Direccion = origen.Direccion;
        }
        public bool Equals(Empleado other)
        {
            return this.Id == other.Id;
        }
    }
}
