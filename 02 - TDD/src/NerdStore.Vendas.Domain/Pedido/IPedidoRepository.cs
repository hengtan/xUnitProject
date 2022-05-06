using System;
using System.Threading.Tasks;
using NerdStore.Core.Data;

namespace NerdStore.Vendas.Domain.Pedido
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);
        Task<Pedido> ObterPedidoRascunhoPorClientId(Guid clientId);
        void AdicionarItem(PedidoItem pedidoItem);
        void AtualizarItem(PedidoItem pedidoItem);
    }
}
        