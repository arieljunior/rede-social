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

        [Display(Name = "Cidade")]
        [StringLength(20, MinimumLength = 2)]
        public string City { get; set; }

        public string UrlPhoto { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        public string Email { get; set; }

        public bool IsFollowed { get; set; } // Variável para verificar se o usuário logado está seguindo outro usuário na view
    }
}