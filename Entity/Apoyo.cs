using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Entity
{
    public class Apoyo
    {
        [Key]
        public string ApoyoId { get; set; }
        public string Valor { get; set; }
        public string Modalidad { get; set; }
        public DateTime Fecha { get; set; }

        public string PersonaId { get; set; }
        public Persona Persona { get; set; }
        
    }
}