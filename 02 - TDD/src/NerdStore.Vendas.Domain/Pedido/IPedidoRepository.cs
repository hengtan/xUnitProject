using NerdStore.Core.Data;

namespace NerdStore.Vendas.Domain.Pedido
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        void Adicionar(Pedido pedido);
    }
}