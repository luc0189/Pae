using Pae.web.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Pae.web.Models
{
    public class SincroModel
    {
        SincroHelper dataload = new SincroHelper();
        String sql = String.Empty;
        internal DataSet Mdatoscontratonomina(String terceroID,
           String fechaini,
           String fechafin) //--Desprendible Nomina aqui sacamos el dato del contrato
        {
            sql = "declare @contratoID as nvarchar(20) " +
            "set @contratoID = (select contrato.id from th.contrato " +
            "where terceroID = '" + terceroID + "' " +
            "and fechaini<= CONVERT (date, GETDATE()) " +
            "and(fechafin is null or fechafin >= CONVERT (date, GETDATE()) )) " +
            "select @contratoID as NumeroContrato";
            return dataload.sqlconsulta(sql);
        }
    }
}
