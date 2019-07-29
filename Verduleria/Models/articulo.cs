using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Data.Entity.Spatial;

namespace Verduleria.Models
{
    public partial class Articulo
    {
           public int Codigo { set; get; }
           public string Descripcion { set; get; }
           public float Precio { set; get; } 
    }
}
