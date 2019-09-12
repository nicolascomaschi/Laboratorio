using System.IO;
using System.Runtime.Serialization.Json;

namespace Laboratorio
{
    public class CopiarObjs
    {
        public static T Copiar<T>(T source)
        {
            DataContractJsonSerializer f = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream s = new MemoryStream())
            {
                f.WriteObject(s, source);
                s.Seek(0, SeekOrigin.Begin);
                return (T)f.ReadObject(s);
            }
        }
    }
}