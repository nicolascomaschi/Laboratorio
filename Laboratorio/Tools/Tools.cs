using System;
using System.IO;

namespace Laboratorio
{
    public partial class Tools
    {
        public static string GetPath(string path)
        {
            string pathCompleto = Path.Combine(Environment.CurrentDirectory, path);
            return pathCompleto;
        }
    }
}
