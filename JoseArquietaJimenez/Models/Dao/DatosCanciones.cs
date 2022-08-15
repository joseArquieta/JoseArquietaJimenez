using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JoseArquietaJimenez.Models.Dao
{
    public class DatosCanciones
    {
        public int id_Cancion { get; set; }
        public string Titulo { get; set; }
        public string Grupo { get; set; }
        public int? Ano { get; set; }
        public string Genero { get; set; }
    }
}