using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorio
{
    public class RepositorioIdentificable<T> : Repositorio<T> where T : IIdentificable, IEquatable<T>, ICopiable<T>
    {
        public T Find(int id, List<T> lista)
        {
            return lista.Where(i => i.Id == id).FirstOrDefault();
        }

        public new void DeleteEmpleado(T obj)
        {
            var objoriginal = list.Find(x => x.Id == obj.Id);
            if (objoriginal != null)
            {
                list.Remove(objoriginal);
            }
        }
    }
}
