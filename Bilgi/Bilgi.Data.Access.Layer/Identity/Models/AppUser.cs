
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilgi.Data.Access.Layer.Identity.Models
{
    public class AppUser : IdentityUser<int>
    {
		public string Isim { get; set; }
		public string SoyIsim { get; set; }
	}
}
