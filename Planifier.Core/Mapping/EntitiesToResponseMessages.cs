using AutoMapper;
using Planifier.Core.Contracts.ResponseMessages;
using Planifier.DataAccess.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planifier.Core.Mapping
{
    public class EntitiesToResponseMessages
    {
        public static void Map(IMapperConfiguration mapperConfiguration)
        {
            mapperConfiguration.CreateMap<USER,UserResponse>();
        }
    }
}
