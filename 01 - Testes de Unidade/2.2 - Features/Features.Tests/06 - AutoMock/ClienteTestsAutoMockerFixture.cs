using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using Features.Clientes;
using Moq.AutoMock;
using Xunit;

namespace Features.Tests
{
    [CollectionDefinition(nameof(ClienteAutoMockerCollection))]
    public class ClienteAutoMockerCollection : ICollectionFixture<ClienteTestsAutoMockerFixture>
    {

    }

    public class ClienteTestsAutoMockerFixture : IDisposable
    {
        public ClienteService ClienteService;
        public AutoMocker Mocker;

        public Cliente GerarClienteValido()
        {
            return CriarClienteValido(1, true).FirstOrDefault();
        }

        public Cliente GerarClienteInvalido()
        {
            return CriarClienteInvalido(1, true).FirstOrDefault();
        }

        public List<Cliente> ObterClientesVariados()
        {
            var clientes = new List<Cliente>();

            clientes.AddRange(CriarClienteValido(50, true).ToList());
            clientes.AddRange(CriarClienteValido(50, false).ToList());

            return clientes;
        }

        public IEnumerable<Cliente> CriarClienteValido(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    f.Name.FirstName(genero),
                    f.Name.LastName(genero),
                    f.Date.Past(80, DateTime.Now.AddYears(-18)),
                    "",
                    ativo,
                    DateTime.Now))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLowerInvariant(), "live"));
            return cliente.Generate(quantidade);
        }

        public IEnumerable<Cliente> CriarClienteInvalido(int quantidade, bool ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();

            var cliente = new Faker<Cliente>("pt_BR")
                .CustomInstantiator(f => new Cliente(
                    Guid.NewGuid(),
                    "",
                    f.Name.LastName(genero),
                    DateTime.Now,
                    "",
                    ativo,
                    DateTime.Now))
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.Nome.ToLower(), c.Sobrenome.ToLowerInvariant(), "live"));
            return cliente.Generate(quantidade);
        }

        public ClienteService ObterClienteService()
        {
            Mocker = new AutoMocker();
            ClienteService = Mocker.CreateInstance<ClienteService>();

            return ClienteService;
        }
        public void Dispose()
        {
        }
    }
}