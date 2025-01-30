using AutoMapper;
using BC.Drex.API.Dtos;
using BC.Drex.API.Dtos.User;
using BC.Drex.API.Dtos.Wallet;
using BC.Drex.Domain.Entities;

namespace BC.Drex.API.Mappings
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            #region -> Base
            CreateMap(typeof(ServiceResult<>), typeof(ResultResponse<>))
                .ForMember("Data", opt => opt.MapFrom("Data"));
            #endregion

            #region -> User
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(org => org.Id))
                .ForMember(dest => dest.WalletId, opt => opt.MapFrom(org => org.Wallet != null ? org.Wallet.Id : (Guid?)null));

            CreateMap<IEnumerable<User>, ResultResponse<IEnumerable<UserResponse>>>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));

            CreateMap<UserRequest, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(org => org.UserId));

            #endregion

            #region  -> Wallet
            CreateMap<Wallet, WalletResponse>()
                .ForMember(dest => dest.isActive, opt => opt.MapFrom(org => org.Active))
                .ForMember(dest => dest.WalletId, opt => opt.MapFrom(org => org.Id));
            #endregion
        }
    }
}
