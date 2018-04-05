using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProfileViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Display(Name = "Estado/Cidade")]
        [StringLength(20, MinimumLength = 2)]
        public string City { get; set; }

        [Display(Name = "Foto")]
        [DataType(DataType.ImageUrl)]
        public string UrlPhoto { get; set; }

        public string Email { get; set; }
    }
}