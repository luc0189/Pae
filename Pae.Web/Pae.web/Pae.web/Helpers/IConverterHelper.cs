using Pae.web.Data.Entities;
using Pae.web.Models;
using System.Threading.Tasks;

namespace Pae.web.Helpers
{
    public interface IConverterHelper
    {
        Task<DeliveryActa> ToCreditAsync(DeliveryActaViewModel model, bool isNew);//
    }
}