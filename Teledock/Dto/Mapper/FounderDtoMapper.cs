using Teledock.Models;

namespace Teledock.Dto.Mapper
{
    public class FounderDtoMapper
    {
        public static Founder MapFounderDtoToFounder(FounderDto dto, Founder founder)
        { 
            founder.INN = dto.INN;
            founder.FullName = dto.FullName;
            founder.ClientId = dto.ClientId;
            return founder;
        }
        public static Founder MapFounderDtoToFounder(FounderDto dto)
            => new Founder()
            {
                INN = dto.INN,
                FullName = dto.FullName,
                ClientId = dto.ClientId,
            };
    }
}
