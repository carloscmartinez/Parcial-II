using System.Reflection;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class PersonaInputModel
    {
       [Required]
       //[RegularExpression(@"^[0-9]{7,10}$", ErrorMessage = "La identificacion  es solo numeros de 7 a 10 digitos")]
        public long PersonaId { get; set; }
      //  [Required(ErrorMessage ="El Nombre es requerido")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage ="El Apellido es requerido")]
        public string Apellidos { get; set; }
      //  [Required]
      //  [SexValidation(ErrorMessage = "Especifique un sexo [M ó F]")]
        public string Sexo { get; set; }
       // [Required(ErrorMessage ="La edad es requerida")]
        public int Edad { get; set; }
       // [Required(ErrorMessage ="El Departamento es requerido")]
        public string Departamento { get; set; }
       // [Required(ErrorMessage ="La Ciudad es requerida")]
        public string Ciudad { get; set; }
       
    }
    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel()
        {

        }
        public PersonaViewModel(Persona persona)
        {
            PersonaId = persona.PersonaId;
            Nombre = persona.Nombre;
            Apellidos = persona.Apellidos;
            Sexo = persona.Sexo;
            Edad = persona.Edad;
            Departamento = persona.Departamento;
            Ciudad = persona.Ciudad;

        }
        
    }
}


    public class SexValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "M" || Convert.ToString(value) == "F")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
