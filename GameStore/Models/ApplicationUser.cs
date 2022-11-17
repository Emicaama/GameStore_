using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Nombre Completo")]
        public string NombreCompelto { get; set; }
    }
}
