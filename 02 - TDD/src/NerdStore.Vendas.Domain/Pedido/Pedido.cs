using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using NerdStore.Core.DomainObject;

namespace NerdStore.Vendas.Domain.Pedido
{
    public class Pedido : Entity
    {
        protected Pedido()
        {
            _pedidoItems = new List<PedidoItem>();
        }

        public static int MAX_UNIDADES_ITEM => 15;
        public static int MIN_UNIDADES_ITEM => 1;

        public Guid ClientId { get; protected set; }
        public decimal ValorTotal { get; private set; }
        public decimal Desconto { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public Voucher.Voucher Voucher { get; private set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;

        private void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(i => i.CalcularValor());
            CalcularValorTotalDesconto();
        }

        private bool PedidoItemExistente(PedidoItem item)
        {
            return _pedidoItems.Any(p => p.ProdutoId == item.ProdutoId);
        }

        private void ValidarPedidoItemInexistente(PedidoItem item)
        {
            if (!PedidoItemExistente(item)) throw new DomainException($"O item não existe no pedido");
        }

        private void ValidarQuantidadeItemPermitida(PedidoItem item)
        {
            var quantidadeItens = item.Quantidade;

            if (PedidoItemExistente(item))
            {
                var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
                quantidadeItens += itemExistente.Quantidade;
            }

            if (quantidadeItens >= MAX_UNIDADES_ITEM) throw new DomainException($"Máximo de {MAX_UNIDADES_ITEM} unidades por produto");
        }

        public void AdicionarItem(PedidoItem pedidoItem)
        {
            ValidarQuantidadeItemPermitida(pedidoItem);

            if (PedidoItemExistente(pedidoItem))
            {
                var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);

                itemExistente.AdicionarUnidades(pedidoItem.Quantidade);
                pedidoItem = itemExistente;
                _pedidoItems.Remove(itemExistente);
            }

            _pedidoItems.Add(pedidoItem);
            CalcularValorPedido();
        }

        public void AtualizarItem(PedidoItem pedidoItem)
        {
            ValidarPedidoItemInexistente(pedidoItem);
            ValidarQuantidadeItemPermitida(pedidoItem);

            var itemExistente = PedidoItems.FirstOrDefault(p => p.ProdutoId == pedidoItem.ProdutoId);

            _pedidoItems.Remove(itemExistente);
            _pedidoItems.Add(pedidoItem);

            CalcularValorPedido();
        }

        public void RemoverItem(PedidoItem pedidoItem)
        {
            ValidarPedidoItemInexistente(pedidoItem);

            _pedidoItems.Remove(pedidoItem);

            CalcularValorPedido();
        }

        public void TornarRascunho()
        {
            PedidoStatus = PedidoStatus.Rascunho;
        }

        public ValidationResult AplicarVoucher(Voucher.Voucher voucher)
        {
            var result = voucher.ValidarSeAplicavel();
            if (!result.IsValid) return result;

            Voucher = voucher;
            VoucherUtilizado = true;

            CalcularValorTotalDesconto();

            return result;
        }

        public void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            switch (Voucher.TipoDescontoVoucher)
            {
                case TipoDescontoVoucher.Valor:
                    {
                        if (Voucher.ValorDesconto.HasValue)
                        {
                            desconto = Voucher.ValorDesconto.Value;
                            valor -= desconto;
                        }
                        break;
                    }
                case TipoDescontoVoucher.Porcentagem:
                default:
                    {
                        if (Voucher.PercentualDesconto.HasValue)
                        {
                            desconto = (ValorTotal * Voucher.PercentualDesconto.Value) / 100;
                            valor -= desconto;
                        }
                        break;
                    }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }

        public static class PedidoFactory
        {
            public static Pedido NovoPedidoRascunho(Guid clientId)
            {
                var pedido = new Pedido
                {
                    ClientId = clientId,
                };

                pedido.TornarRascunho();
                return pedido;
            }
        }
    }
}