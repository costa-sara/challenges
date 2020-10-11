using Kenbi.Domain.Dto;
using Kenbi.Domain.Models;

namespace Kenbi.API.AutoMapperSettings
{
    /// <summary>
    /// DtoToModelMappingProfile (for AutoMapper)
    /// </summary>
    public class DtoToModelMappingProfile : AutoMapper.Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DtoToModelMappingProfile()
        {
            ChallengeRegisterMap();
        }

        private void ChallengeRegisterMap()
        {
            CreateMap<ChallengeDto, Challenge>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Output, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());
        }
    }
}
