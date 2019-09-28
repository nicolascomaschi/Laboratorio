using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Laboratorio
{
    public class Repositorio<T> where T : IEquatable<T>, ICopiable<T>
    {
        protected List<T> list = new List<T>();

        public List<T> GetList()
        {
            return CopiarObjs.Copiar(list);
        }

        public void AddEmpleado(T obj)
        {
            list.Add(obj);
        }

        public void DeleteEmpleado(T obj)
        {
            var original = list.Find(x => x.Equals(obj));
            if (original != null)
            {
                list.Remove(original);
            }
        }
        public void Update(T obj)
        {
            var original = list.Find(x => x.Equals(obj));
            if (original != null)
            {
                original.CopiarDesde(obj);
            }
        }

        public void Save(T obj, string path)
        {
            string jsonObj = JsonConvert.SerializeObject(obj);
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(jsonObj);
                file.Close();
            }
        }
        public void SaveList(List<T> list, string path)
        {
            DataContractJsonSerializer f = new DataContractJsonSerializer(typeof(List<T>));
            using (System.IO.Stream s = File.Open(path, FileMode.Create))
            {
                f.WriteObject(s, list);
            }
        }

        public List<T> Read(string path)
        {
            string line = "";
            using (StreamReader file = new StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    T obj = JsonConvert.DeserializeObject<T>(line);
                    list.Add(obj);
                }
                return list;
            }
        }

        public virtual T Find(int id)
        {
            foreach (var item in list)
            {
                //interface
                IIdentificable obj = item as IIdentificable;
                if (obj != null)
                {
                    if (obj.Id != id)
                    {
                        CopiarObjs.Copiar(item);
                    }
                }
            }
            return default(T);
        }
    }
}
