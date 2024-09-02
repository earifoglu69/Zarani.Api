using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zarani.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazyMapper = new(() =>
        {
            MapperConfiguration mapperConfiguration = new(configuration =>
            {
                configuration.AddProfile<MapProfile>();
            });

            return mapperConfiguration.CreateMapper();
        });

        public static IMapper Mapper => lazyMapper.Value;
    }
}
