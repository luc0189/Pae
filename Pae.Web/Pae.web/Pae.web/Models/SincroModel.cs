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
        internal DataSet StudentsServer(string dateUpdate) //--select para obtener los datos a sincronizar
        {
            sql = $"select * from Estudents where DateUpdate>'{dateUpdate}'";
            return dataload.SqlConsulta(sql);
        }
    }
}
