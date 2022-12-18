using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DTO.Concrete.Account
{
	public class RolePageDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Method { get; set; }

		public List<RoleDTO> Roles { get; set; }
	}
}
