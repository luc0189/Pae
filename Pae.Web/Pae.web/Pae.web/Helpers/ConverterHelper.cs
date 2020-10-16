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
        
               public async Task<DetailsDelivery> ToDetailDataActaAsync(DetailsActaViewModel model, bool isNew)
        {
            //int mes = int.Parse(model.DeadlinePay.ToString());
            return new DetailsDelivery
            {
                Id = isNew ? 0 : model.Id,
                DeliveryActa= await _dataContext.DeliveryActas.FindAsync(model.ActaId),
               
                TelMovil=model.TelMovil,
             
                Imagedocl=model.Imagedocl,
                Imagedoc2=model.Imagedoc2,
               


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
                Estudents = await _dataContext.Estudents.FindAsync(model.StudentID),
               Entrega3=model.Entrega3,
               Entrega4=model.Entrega4,
               Entrega5=model.Entrega5,
               Entrega6=model.Entrega6,
               Entrega7=model.Entrega7


            };
        }

        public  DetailsDelivery ToDetailsDeliveryAsync(DetailsActaViewModel model, bool isNew)
        {
            //int mes = int.Parse(model.DeadlinePay.ToString());
            return new DetailsDelivery
            {
                Id = isNew ? 0 : model.Id,
              
                TelMovil=model.TelMovil
            };
        }

        public async Task<Sedes> ToSedeAsync(AddSedeViewModel modelfull, bool isNew)
        {
            return new Sedes
            {
                Id = isNew ? 0 : modelfull.Id,
                Institucion = await _dataContext.Institucions.FindAsync(modelfull.InstitucionId),
                NameSedes=modelfull.NameSedes
            };
        }
        //public async Task<DeliveryActa> ToDeliveryActaAsync(DeliveryActaViewModel modelfull, bool isNew)
        //{
        //    return new DeliveryActa
        //    {
        //        Id = isNew ? 0 : modelfull.Id,
        //        Estudents = await _dataContext.Estudents.FindAsync(modelfull.EstudentId),
               
        //        Usucrea=modelfull.Usucrea
        //    };
        //}

        public AddSedeViewModel ToSedeViewModel(Sedes sede )
        {
            return new AddSedeViewModel
            {
               Id=sede.Id,
               InstitucionId =sede.Institucion.Id,
                Institucion = sede.Institucion,
                NameSedes = sede.NameSedes
            };
        }

    
        

       public DeliveryActaViewModel ToDeliveryActaViewModel(DeliveryActa deliveryActa)
        {
            return new DeliveryActaViewModel
            {
                Id=deliveryActa.Id,
            
                Usucrea=deliveryActa.Usucrea,
            
                StudentID=deliveryActa.Estudents.Id,
                Entrega3=deliveryActa.Entrega3,
                Entrega4=deliveryActa.Entrega4,
                Entrega5=deliveryActa.Entrega5,
                Entrega6=deliveryActa.Entrega6,
                Entrega7=deliveryActa.Entrega7
            };
        }
      

        public async Task<DeliveryActa> ToDeliveryActaAsync(DeliveryActaViewModel model, bool isNew)
        {
            return new DeliveryActa
            {

                Id = isNew ? 0 : model.Id,
                Entrega3=model.Entrega3,
                Entrega4=model.Entrega4,
                Entrega5=model.Entrega5,
                Entrega6=model.Entrega6,
                Entrega7=model.Entrega7,
                Usucrea = model.Usucrea,
                Estudents = await _dataContext.Estudents.FindAsync(model.StudentID)
            };
        }
     

        public DetailsDeliveryViewModel ToEditDetailsActaViewModel(DetailsDelivery deliveryActa)
        {
            return new DetailsDeliveryViewModel
            {
                IdActa = deliveryActa.Id,
                TelMovil=deliveryActa.TelMovil,
              Imagedoc2=deliveryActa.Imagedoc2,
              Imagedocl=deliveryActa.Imagedocl
               

            };
        }

    }
}
