﻿using Pae.web.Data;
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
        
               public async Task<DetailsDelivery> ToDetailDataActaAsync(DetailsActaViewModel model, bool isNew)
        {
            //int mes = int.Parse(model.DeadlinePay.ToString());
            return new DetailsDelivery
            {
                Id = isNew ? 0 : model.Id,
                DeliveryActa= await _dataContext.DeliveryActas.FindAsync(model.ActaId),
                DocAcudiente=model.DocAcudiente,
                FullNameAcudiente=model.FullNameAcudiente,
                TelMovil=model.TelMovil,
                SiteDelivery=model.SiteDelivery,
                ImageStudentUrl=model.ImageStudentUrl,
                ImageActaUrl=model.ImageActaUrl,
                ImageAcudienteUrl=model.ImageAcudienteUrl,
                ImageDeliveryUrl=model.ImageDeliveryUrl


            };
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

        public  DetailsDelivery ToDetailsDeliveryAsync(DetailsActaViewModel model, bool isNew)
        {
            //int mes = int.Parse(model.DeadlinePay.ToString());
            return new DetailsDelivery
            {
                Id = isNew ? 0 : model.Id,
                DocAcudiente=model.DocAcudiente,
                FullNameAcudiente=model.FullNameAcudiente,
                ImageActaUrl=model.ImageActaUrl,
                ImageAcudienteUrl=model.ImageAcudienteUrl,
                ImageDeliveryUrl=model.ImageDeliveryUrl,
                ImageStudentUrl=model.ImageStudentUrl,
                SiteDelivery=model.SiteDelivery,
                TelMovil=model.TelMovil
            };
        }

    }
}
