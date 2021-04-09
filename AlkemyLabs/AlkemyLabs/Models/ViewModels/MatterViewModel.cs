using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AlkemyLabs.Models.DTO;

namespace AlkemyLabs.Models.ViewModels
{
    public class MatterViewModel
    {
        [Required]
        [StringLength(30, ErrorMessage ="El {0} debe tener al menos {1} caracteres",MinimumLength =1)]
        public string name { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Time { get; set; }
        [Required]
        public int idTeacher { get; set; }
        [Required]
        public int quota { get; set; }
        public List<DTOteacher> teachers { set; get; }
    }
}