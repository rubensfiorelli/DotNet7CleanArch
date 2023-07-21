using TravelNet.Domain.Entities.ClienteContext;
using TravelNet.Domain.Interfaces.Repositories;
using TravelNet.Domain.Interfaces.Services;

namespace TravelNet.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepositoryGeneric<Cliente> _repository;

        public ClienteService(IRepositoryGeneric<Cliente> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<Cliente> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<ICollection<Cliente>> GetAll()
        {
            return await _repository.List();
        }

        public async Task<Cliente> Post(Cliente cliente)
        {
            if (cliente.Id == Guid.Empty)
            {
                cliente.Id = Guid.NewGuid();
            }
            return await _repository.InsertAsync(cliente);
        }

        public Task<Cliente> Put(Cliente cliente)
        {
            return _repository.UpdateAsync(cliente);
        }

    }
}
