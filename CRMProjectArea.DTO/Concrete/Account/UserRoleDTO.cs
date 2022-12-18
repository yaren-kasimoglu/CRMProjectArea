using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DTO.Concrete.Account
{
	public class UserRoleDTO
	{
		/// <summary>
		/// Role Id
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Role Adı
		/// </summary>
		public string? Name { get; set; }
		/// <summary>
		/// Gelen kullancı bu role sahip ise true değil ise false 
		/// </summary>
		public bool IsSelected { get; set; }
		
	}
}
