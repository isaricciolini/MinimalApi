using Flunt.Notifications;
using Flunt.Validations;

namespace MinimalApi.ViewModels
{
    public class CreateClienteViewModel : Notifiable<Notification>
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string  Telefone { get; set; }

        public string Endereco { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }


        public Cliente MapTo()
        {
            var contract = new Contract<Notification>()
                .Requires()
                .IsNotNull(Nome, "Informe um nome.")
                .IsGreaterThan(Nome, 3, "Nome deve conter no mínimo 3 letras.");

            AddNotifications(contract);

            return new Cliente(Guid.NewGuid(), Nome, Cpf, Telefone, Endereco, Complemento, Cep, Cidade, Uf);
    }
    }

    
}
