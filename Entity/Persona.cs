using System.Security.AccessControl;
using System.Security;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity
{
    public class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public string Ciudad { get; set; }
        
        public List<Apoyo> Apoyos { get; } = new List<Apoyo>();
    }
}