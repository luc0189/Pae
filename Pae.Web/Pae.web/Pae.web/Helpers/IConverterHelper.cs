using Pae.web.Data.Entities;
using Pae.web.Models;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
    public interface IConverterHelper
    {
        Task<DeliveryActa> ToCreditAsync(DeliveryActaViewModel model, bool isNew);//
        Task<DetailsDelivery> ToDetailDataActaAsync(DetailsActaViewModel model, bool isNew);//
        DetailsDelivery ToDetailsDeliveryAsync(DetailsActaViewModel model, bool isNew);//
        Task<Sedes> ToSedeAsync(AddSedeViewModel modelfull, bool isNew);
        AddSedeViewModel ToSedeViewModel(Sedes exams);
        DeliveryActaViewModel ToDeliveryActaViewModel(DeliveryActa deliveryActa);
        
        Task<DeliveryActa> ToDeliveryActaAsync(DeliveryActaViewModel model, bool isNew);

        DetailsDeliveryViewModel ToEditDetailsActaViewModel(DetailsDelivery deliveryActa);
       
        //Task<DeliveryActa> ToDeliveryActaAsync(DeliveryActaViewModel model, bool isNew);

    }
}