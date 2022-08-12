using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogProject.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="ad soyad giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre ")]
        [Required(ErrorMessage = "şifre giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar ")]
        [Compare("Password" , ErrorMessage ="Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi ")]
        [Required(ErrorMessage = "mail giriniz")]
        public string Mail { get; set; }
        [Display(Name = "Kullanıcı Adı ")]
        [Required(ErrorMessage = "kullanıcı adı giriniz")]
        public string UserName { get; set; }

    }
}
