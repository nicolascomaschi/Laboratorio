using System;
using System.IO;

namespace Laboratorio
{
    public partial class Tools
    {
        //Ruta donde se guardan los archivos(mantener las \\ si se cambia por otra)
        public static string pathDefault = "E:\\Datos\\";
        public static string GetPath(string path)
        {
            string pathCompleto = Path.Combine(Environment.CurrentDirectory, path);
            return pathCompleto;
        }
    }
}
