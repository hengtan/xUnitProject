using System.Collections.Generic;
using System.Linq;
using MediatR;

namespace Features.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clientRepository;
        private readonly IMediator _mediator;

        public ClienteService(IClienteRepository clientRepository,
                                IMediator mediator)
        {
            _clientRepository = clientRepository;
            _mediator = mediator;
        }

        public IEnumerable<Cliente> ObterTodosAtivos()
        {
            return _clientRepository.ObterTodos().Where(c => c.Ativo);
        }

        public void Adicionar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clientRepository.Adicionar(cliente);
            _mediator.Publish(new ClientEmailNotification("admin@admin.com", cliente.Email, "Adicionar", "Adicionado com Sucesso"));
        }

        public void Atualizar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            _clientRepository.Atualizar(cliente);
            _mediator.Publish(new ClientEmailNotification("admin@admin.com", cliente.Email, "Adicionar", "Adicionado com Sucesso"));
        }

        public void Inativar(Cliente cliente)
        {
            if (!cliente.EhValido())
                return;

            cliente.Inativar();
            _clientRepository.Atualizar(cliente);
            _mediator.Publish(new ClientEmailNotification("admin@admin.com", cliente.Email, "Adicionar", "Adicionado com Sucesso"));
        }

        public void Remover(Cliente cliente)
        {
            _clientRepository.Remover(cliente.Id);
            _mediator.Publish(new ClientEmailNotification("admin@admin.com", cliente.Email, "Adicionar", "Adicionado com Sucesso"));
        }

        public void Dispose()
        {
            _clientRepository.Dispose();
        }
    }
}
