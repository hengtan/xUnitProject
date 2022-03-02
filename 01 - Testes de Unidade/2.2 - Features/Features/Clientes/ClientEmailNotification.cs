using MediatR;

namespace Features
{
    public class ClientEmailNotification : INotification
    {
        public string Origetem { get; private set; }
        public string Destino { get; private set; }
        public string Assunto { get; private set; }
        public string Mensagem { get; private set; }

        public ClientEmailNotification(
            string origetem, string destino,
            string assunto, string mensagem)
        {
            Origetem = origetem;
            Destino = destino;
            Assunto = assunto;
            Mensagem = mensagem;
        }
    }
}
