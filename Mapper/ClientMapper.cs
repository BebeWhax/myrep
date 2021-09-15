using Domain;
using Entity;
using Model;
using System.Collections.Generic;

namespace Mapper
{
    public static class ClientMapper
    {
        public static IEnumerable<ClientDTO> ToDTO(this IEnumerable<ClientModel> clients)
        {
            List<ClientDTO> result = new();
            foreach (var t in clients)
                result.Add(t.ToDTO());
            return result;
        }
        public static IEnumerable<ClientEntity> ToEntity(this IEnumerable<ClientDTO> clients)
        {
            List<ClientEntity> result = new ();
            foreach (var t in clients)
                result.Add(t.ToEntity());
            return result;
        }
        public static IEnumerable<ClientDTO> ToDTO(this IEnumerable<ClientEntity> clients)
        {
            List<ClientDTO> result = new List<ClientDTO>();
            foreach (var t in clients)
                result.Add(t.ToDTO());
            return result;
        }
        public static IEnumerable<ClientModel> ToModel(this IEnumerable<ClientDTO> clients)
        {
            List<ClientModel> result = new ();
            foreach (var t in clients)
                result.Add(t.ToModel());
            return result;
        }
        public static ClientEntity ToEntity (this ClientDTO client)
        {
            client ??= new ClientDTO();
            return new ClientEntity
            {
                Id = client.Id,
                Name = client.Name
            };
        }
        public static ClientDTO ToDTO(this ClientEntity client)
        {
            client ??= new ClientEntity();
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name
            };
        }
        public static ClientDTO ToDTO(this ClientModel client)
        {
            client ??= new ClientModel();
            return new ClientDTO
            {
                Id = client.Id,
                Name = client.Name
            };
        }
        public static ClientModel ToModel(this ClientDTO client)
        {
            client ??= new ClientDTO();
            return new ClientModel
            {
                Id = client.Id,
                Name = client.Name
            };
        }
        
    }
}
