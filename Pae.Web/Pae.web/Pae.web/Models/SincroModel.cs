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
            sql = $"select * from Estudents where DateUpdate>'{dateUpdate}' order by Id asc";
            return dataload.SqlConsulta(sql);
        }
        internal DataSet PostStudentsServer(string dateUpdate) //--select para listar los datos a enviar
        {
            sql = $"select * from Estudents where DateUpdate>'{dateUpdate}'";
            return dataload.SqlConsulta(sql);
        }

        internal DataSet InstitucionServer(string dateUpdate) //--select para obtener los datos a sincronizar
        {
            sql = $"select * from Institucions where FechaActualización>'{dateUpdate}' order by Id asc";
            return dataload.SqlConsulta(sql);
        } internal DataSet SedesServer(string dateUpdate) //--select para obtener los datos a sincronizar
        {
            sql = $"select * from Sedes where FechaActualización>'{dateUpdate}' order by Id asc";
            return dataload.SqlConsulta(sql);
        }
        internal DataSet ActasServer(string dateUpdate) //--select para obtener los datos a sincronizar
        {
            sql = $@"select * 
                        from DeliveryActas d 
                            inner join Estudents es on es.id=d.EstudentsId
                            where d.FechaActualización>'{dateUpdate}' ";
            return dataload.SqlConsulta(sql);
        }
    }
}
