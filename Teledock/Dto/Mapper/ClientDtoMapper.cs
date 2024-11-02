using Teledock.Models;
using Teledock.Models.Enums;

namespace Teledock.Dto.Mapper
{
    public class ClientDtoMapper
    {
        public static Client MapClientDtoToClient(ClientDto dto, Client client)
        {
            if (!Enum.IsDefined(typeof(ClientType), dto.ClientType))
            {
                throw new ArgumentException($"Invalid ClientType value: {dto.ClientType}");
            }
            client.ClientType = dto.ClientType;
            client.INN = dto.INN;
            client.Name = dto.Name;
            return client;
        }
        public static Client MapClientDtoToClient(ClientDto dto)
        {
            if (!Enum.IsDefined(typeof(ClientType), dto.ClientType))
            {
                throw new ArgumentException($"Invalid ClientType value: {dto.ClientType}");
            }

            return new Client
            {
                INN = dto.INN,
                Name = dto.Name,
                ClientType = dto.ClientType,
                Founders = null // Инициализация коллекции, если необходимо
            };
        }
    }
}
