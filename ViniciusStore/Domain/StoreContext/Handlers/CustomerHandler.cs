using Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Repositories;
using Domain.StoreContext.Services;
using Domain.StoreContext.ValueObjects;
using FluentValidator;
using Shared.Commands;

namespace Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCustomerCommand>
    {
        private readonly ICostumerRepository costumerRepository;
        private readonly IEmailService emailService;

        public CustomerHandler(ICostumerRepository costumerRepository, IEmailService emailService)
        {
            this.costumerRepository = costumerRepository;
            this.emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verificar se o CPF já existe na base
            if (costumerRepository.CheckCustomerExistsByDocument(command.Document)) AddNotification("Document", "Este CPF já está em uso");

            // Verificar se o E-mail já existe na base
            if (costumerRepository.CheckCustomerExistsByEmail(command.Email))
                AddNotification("Email", "Este Email já está em uso");

            // Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            // Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid) return null;

            // Persisitir o cliente
            costumerRepository.SaveCustomer(customer);

            // Enviar um e-mail de boas vindas
            emailService.SendEmail(email.ToString(), "helloEmail@email.com", "Bem Vindo", "Seja bem vindo ao Vinícius Store!");

            // Retornar o resultado para tela

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.ToString());
        }

        public ICommandResult Handle(AddAddressCustomerCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}