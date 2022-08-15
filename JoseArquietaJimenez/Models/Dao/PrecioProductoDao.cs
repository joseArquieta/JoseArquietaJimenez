using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JoseArquietaJimenez.Models.Dao
{
    public class PrecioProductoDao
    { 
        public string descripción { get; set; }
        public string unidad_Producto { get; set; }
        public string Tipo_Proveedor { get; set; }
        public decimal? precio { get; set; }
    }
}