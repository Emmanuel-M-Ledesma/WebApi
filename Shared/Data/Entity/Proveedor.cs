using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Shared.Data.Entity
{
    [Index(nameof(Id),Name = "UQ_Id_Proveedor", IsUnique =true)]
    public class Proveedor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de proveedor es obligatorio.")]
        public string NombreProvedor { get; set; }
        
        public string Empresa { get; set; }
        [Required(ErrorMessage = "El telefono del proveedor es obligatorio.")]
        public int Telefono { get; set; }
        [Required(ErrorMessage = "Es necesaria una descripcion")]
        public string Descripcion { get; set; }

    }
}
