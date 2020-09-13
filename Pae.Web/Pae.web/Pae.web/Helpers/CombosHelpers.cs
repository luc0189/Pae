using Microsoft.AspNetCore.Mvc.Rendering;
using Pae.web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
    public class CombosHelpers :ICombosHelpers
    {
        private readonly DataContext _dataContext;

        public CombosHelpers(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

     
        public IEnumerable<SelectListItem> GetComboPeriodoTypes()
        {
            var list = _dataContext.Periodos.Select(et => new SelectListItem
            {
                Text = et.MonthDelivery,
                Value = $"{et.Id}"
            }).OrderBy(et => et.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un Periodo...)",
                Value = "0"
            });
            return list;
        }
        public IEnumerable<SelectListItem> GetComboSedes()
        {
            var list = _dataContext.Sedes.Select(et => new SelectListItem
            {
                Text = et.NameSedes,
                Value = $"{et.Id}"
            }).OrderBy(et => et.Text)
             .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione una Sede...)",
                Value = "0"
            });
            return list;
        }
    }
}
