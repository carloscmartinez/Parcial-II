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
       // [Required]
        public string PersonaId { get; set; }
        ///[Required(ErrorMessage ="El Nombre es requerido")]
        public string Nombre { get; set; }
        //[Required(ErrorMessage ="El Apellido es requerido")]
        public string Apellidos { get; set; }
        // [Required(ErrorMessage ="El Telefono es requerido")]
        // [Required]
        // [SexValidation(ErrorMessage = "Especifique un sexo [M ó F]")]
        //[Required]             
        //[RegularExpression(@"^[0-9]{7,10}$", ErrorMessage = "El telefono es solo numeros de 7 a 10 digitos")]
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
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




    

    // public class SexValidation : ValidationAttribute
    // {
    //     protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //     {
    //         if (Convert.ToString(value) == "M" || Convert.ToString(value) == "F")
    //             return ValidationResult.Success;
    //         else
    //             return new ValidationResult(ErrorMessage);
    //     }
    // }
