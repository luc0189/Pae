using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
    public interface ICombosHelpers
    {
        IEnumerable<SelectListItem> GetComboPeriodoTypes();
    }
}
