using System;

namespace NerdStore.Vendas.Domain
{
    public class Roteiro
    {
        // Desenvolvimento do Dominio de Vendas

        // Pedido - Item Pedido - Voucher

        /*
         Um Item de pedido representa um produto e pode conter mais de uma unidade
        Independente da ação, um item precisa ser sempre valido:
        Possuir: ID e nome do produto, quantidade entre 1 e 15 unidades, valor maior que 0

        Um pedido enquanto náo iniciado (processo de pagamento) esta no estado de rascunho
        e deve pertencer a um cliente

        1 - Adicionar item
            1.1 - Ao adicionar um item é necessario calcular o valor total do pedido
            1.2 - Se um item ja esta na lista, entao deve acrescentar a quantidade do item no pedido
            1.3 - O item deve ter entre 1 e 15 unidades do produto

        2 - Atualizacao de Item
            2.1 - O item precisa estar na lista para ser atualizado
            2.2 - Um item pode ser atualizado contendo mais ou menos unidades do que anteriormente
            2.3 - Ao atualizar um item é necessario calcular o valor total do pedido
            2.4 - Um item deve permanecer entre 1 e 15 unidades do produto

        3 - Remocao de Item
            3.1 - O Item precisa estar na lista para ser removido
            3.2 - Ao remover um item é necessario calular o valor total do pedido

        Um voucher possui um codigo unico e o desconto pode ser percentual ou valor fixo
        Usar uma flag indicando que um pedido teve um voucher de desconto aplicado e o valor do desconto

        4 - Aplicar voucher de desconto
            4.1 - O voucher so pode ser aplicado se estiver valido, para isso:
                4.1.1 - Deve possuir um codigo
                4.1.2 - A data de validade e superior a data atual
                4.1.3 - O voucher esta ativo
                4.1.4 - O voucher possui quantidade disponivel
                4.1.5 - Um das formas de desconto devem estar preenchidas com o valor acima de 0
            4.2 - Calular o desconto conforme tipo do voucher
                4.2.1 - Voucher com descontonto percentual
                4.2.2 - Voucher com descontonto em valores (reais)
            4.3 - Quando o valor do desconto ultrapassar o total do pedido o pedido receber o valor: 0
            4.3 - Apos a aplicacao do voucher o desconto deve ser re-calculado, apos toda modificacao da lista de itens do pedido
         */

        /*
         Pedido Commands - Handler

        O Command Handler de pedido irá manipular um command para cada intencao em relacao ao pedido.
        Em todos os comandos manipulados devem ser verificadosÇ

        - Se o command é valido
        - Se o pedido existe
        - Se o item do pedido existe

        Na alteracao de estado do pedidoÇ
        - Deve ser feita via repositorio
        - Deve enviar um evento

        1 - AdicionarItemPedidoCommand
            1.1 Verificar se é um pedido novo ou em andamento
            1.2 - Verificar se o item já foi adicionado a lista
         */
    }
}
