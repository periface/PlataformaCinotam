using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ServicioMapeo
{
    public class AutoMapperService<T, D>
    where T : class
    where D : class
    {
        public AutoMapperService()
        {
            Mapper.CreateMap<T, D>();
            Mapper.CreateMap<D, T>();
        }
        public D GenerarModelo(T model)
        {
            try
            {

                return Mapper.Map<T, D>(model);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public D GenerarModeloGuardado(T model)
        {
            try
            {
                return Mapper.Map<T, D>(model);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public D ActualizarValores(T model, D original)
        {
            try
            {
                var o = Mapper.Map(model, original);
                return o;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
