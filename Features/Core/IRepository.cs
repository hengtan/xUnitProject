using System;
using System.Collections.Generic;
using Features.Clientes;

namespace Features.Core
{
    public interface IRepository<T> :IDisposable
    {
        IEnumerable<Cliente> ObterTodos();
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Inativar(Cliente cliente);
        void Remover(Guid id);
    }
}