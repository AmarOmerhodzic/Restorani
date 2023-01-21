using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Restorani.Models.ViewModels
{
	public class JeloVM
	{
		public Jelo Jelo { get; set; }
		public IEnumerable<SelectListItem> NameDropDown { get; set; }
	}
}
