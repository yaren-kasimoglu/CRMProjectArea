using CRMProjectArea.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DTO.Concrete.Account
{
	public class RoleDTO : BaseDTO
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? NormalizedName { get; set; }
		public string? ConcurrencyStamp { get; set; }

	}
}
