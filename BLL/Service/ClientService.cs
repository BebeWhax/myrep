using BLL.Core;
using DataLayer.Core;
using Domain;
using Mapper;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ClientService : IClientService
    {
        IUnitOfWork unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ClientDTO client)
        {
            await unitOfWork.ClientRepository.CreateAsync(client.ToEntity());
            await unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<ClientModel>> FindAsync(ClientDTO clientFilter)
        {
            var result = await unitOfWork.ClientRepository.FindAsync(p =>
                 !String.IsNullOrEmpty(clientFilter.Name) ? p.Name.Contains(clientFilter.Name) : true);
            return result.ToDTO().ToModel();
        }

        public async Task<IEnumerable<ClientModel>> GetAllAsync()
        {
            var result = await unitOfWork.ClientRepository.GetAllAsync();
            return result.ToDTO().ToModel();
        }

        public async Task<ClientModel> GetAsync(Guid id)
        {
            var result=await unitOfWork.ClientRepository.GetAsync(id);
            return result.ToDTO().ToModel();
        }

        public async Task RemoveAsync(ClientDTO client)
        {
            unitOfWork.ClientRepository.Delete(client.ToEntity());
            await unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(ClientDTO client)
        {
            unitOfWork.ClientRepository.Update(client.ToEntity());
            await unitOfWork.SaveAsync();
        }
    }
}
