using CRMProjectArea.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DTO.Concrete.Account
{
	public class LoginDTO : BaseDTO
	{
		[Required] //Zorunlu alan olsun
		[EmailAddress] //Buradaki veri email validaton geçsin
		[Display(Name = "Kullanıcı Adı")] //label kullanıcı adı yazsın
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Şifre")]
		public string Password { get; set; }

		[Display(Name = "Beni Hatırla")]
		public bool RememberMe { get; set; }
	}
}
