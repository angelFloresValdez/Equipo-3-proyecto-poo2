using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPOO2.Models
{
    public class LoginEncargadoModel
    {
        public LoginEncargadoModel()
        {
        }

        public Guid Id { get; set; }
        public string CorreoEnc { get; set; }
        public string ContraseñaEnc { get; set; }
        
    }
}