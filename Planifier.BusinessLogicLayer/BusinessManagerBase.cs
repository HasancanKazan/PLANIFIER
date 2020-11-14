using AutoMapper;
using Planifier.Core.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.BusinessLogicLayer
{
    public class BusinessManagerBase
    {
        protected IMapper Mapper;
        public BusinessManagerBase()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                RequestMessagesToEntities.Map(cfg);
                EntitiesToResponseMessages.Map(cfg);
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        protected T ExecuteWithExeptionHandledOperation<T>(Func<T> func)
        {
            try
            {
                var result = func.Invoke();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
