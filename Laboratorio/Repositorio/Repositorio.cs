using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Laboratorio
{
    public class Repositorio<T> 
    {
        private List<T> list = new List<T>();

        public List<T> GetList()
        {
            return list;
        }

        public void AddEmpleado(T obj)
        {
            list.Add(obj);
        }

        public void DeleteEmpleado(T obj)
        {
            list.Remove(obj);
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

        public T Find(int id)
        {
            foreach (var item in list)
            {
                //interface
                IIdentificable obj = item as IIdentificable;
                if (obj != null)
                {
                    if (obj.id != id)
                    {
                        return item;
                    }
                }
            }
            return default(T);
        }
    }
}
