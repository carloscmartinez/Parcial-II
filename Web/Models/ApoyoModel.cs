using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class ApoyoInputModel
    {
        [Required]
        public int ApoyoId { get; set; }
       // [Required(ErrorMessage ="El valor es requerido")]
        public float Valor { get; set; }
        //[Required(ErrorMessage ="El Apellido es requerido")]
        public string Modalidad { get; set; }     
        //[Required(ErrorMessage ="La fecha es requerida")]
        public DateTime Fecha { get; set; }
        //[RegularExpression(@"^[0-9]{7,10}$", ErrorMessage = "La identificacion  es solo numeros de 7 a 10 digitos")]
        public long PersonaId { get; set; }
        
    }
    public class ApoyoViewModel : ApoyoInputModel
    {
        public ApoyoViewModel()
        {

        }
        public ApoyoViewModel(Apoyo apoyo)
        {
            ApoyoId = apoyo.ApoyoId;
            PersonaId = apoyo.PersonaId;
            Valor = apoyo.Valor;
            Modalidad = apoyo.Modalidad;
            Fecha = apoyo.Fecha;          

        }
        
    }
}