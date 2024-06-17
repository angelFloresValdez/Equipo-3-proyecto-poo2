using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProyectoFinalPOO2.Models
{
    public class RegEmpleadoModel
    {
        public RegEmpleadoModel()
        {
        }
         public Guid Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaNac { get; set; }
        public string Nacionalidad { get; set; }
        public string EstadoCivil { get; set; }
        public string Curp {get; set;}
        public string Rfc { get; set;}
        public string Domicilio {get; set;}
        public string Turno { get; set; }
        public string Jefe {get; set;}
        public string Departamento {get; set;}  

         public Guid? JefeId { get; set; }
        public JefeModel? JefeModel { get; set; }
        public string? NombreJefe { get; set; }
         public List<SelectListItem>? ListJefes { get; set; }  


        


    }
}