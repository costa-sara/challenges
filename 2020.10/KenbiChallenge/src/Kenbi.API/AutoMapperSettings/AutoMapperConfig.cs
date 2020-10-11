using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kenbi.API.AutoMapperSettings
{
    /// <summary>
    /// AutoMapperConfig
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// RegisterMappings
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelMappingProfile());
            });

            configuration.AssertConfigurationIsValid();

            return configuration;
        }
    }
}
