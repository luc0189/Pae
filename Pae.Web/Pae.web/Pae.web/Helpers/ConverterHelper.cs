using Pae.web.Data;
using Pae.web.Data.Entities;
using Pae.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _dataContext;
        private readonly ICombosHelpers _combosHelpers;

        public ConverterHelper(DataContext dataContext,
            ICombosHelpers combosHelpers)
        {
            _dataContext = dataContext;
            _combosHelpers = combosHelpers;
        }

        public async Task<DeliveryActa> ToCreditAsync(DeliveryActaViewModel model, bool isNew)
        {
            //int mes = int.Parse(model.DeadlinePay.ToString());
            return new DeliveryActa
            {
                Id = isNew ? 0 : model.Id,
                FechaCrea=DateTime.Now,
                Usucrea=model.Usucrea,
                Estudents = await _dataContext.Estudents.FindAsync(model.EstudentId),
                Periodos = await _dataContext.Periodos.FindAsync(model.PeriodoId)



            };
        }
      
    }
}
