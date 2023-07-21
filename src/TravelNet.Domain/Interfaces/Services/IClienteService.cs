using TravelNet.Domain.Entities.ClienteContext;

namespace TravelNet.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<Cliente> Get(Guid id);
        Task<ICollection<Cliente>> GetAll();
        Task<Cliente> Post(Cliente cliente);
        Task<Cliente> Put(Cliente cliente);
        Task<bool> Delete(Guid id);
    }
}
