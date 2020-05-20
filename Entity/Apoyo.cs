using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Entity
{
    public class Apoyo
    {
        [Key]
        public int ApoyoId { get; set; }
        public float Valor { get; set; }
        public string Modalidad { get; set; }
        public DateTime Fecha { get; set; }

        public long PersonaId { get; set; }
        public Persona Persona { get; set; }
        
    }
}