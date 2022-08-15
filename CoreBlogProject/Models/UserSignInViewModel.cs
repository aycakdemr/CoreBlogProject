using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="kullanıcı adını girin")]
        public string userName{ get; set; }
        [Required(ErrorMessage = "password girin")]
        public string password{ get; set; }
    }
}
