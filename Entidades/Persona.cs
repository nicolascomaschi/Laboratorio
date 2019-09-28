using System;

namespace Entidades
{
    [Serializable]
    public class Persona : IPersona, IIdentificable, IEquatable<Persona>, ICopiable<Persona>
    {
        int id;
        string nombre;
        int dni;
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Dni { get => dni; set => dni = value; }

        public void CopiarDesde(Persona origen)
        {
            this.id = origen.id;
            this.nombre = origen.nombre;
            this.dni = origen.dni;
        }
        public bool Equals(Persona other)
        {
            return this.id == other.id;
        }

        public int GetDNI()
        {
            return dni;
        }

        public int GetId()
        {
            return id;
        }

        public string GetNombre()
        {
            return nombre;
        }
    }
}
