using Domain.Abstractions;
using Domain.Models.Customers.Events;
using Qowaiv;

namespace Domain.Models.Customers;

public class Customer : AggregateRoot
{
    private Customer(CustomerId id, CustomerName name, EmailAddress emailAddress)
    {
        Id = id;
        Name = name;
        EmailAddress = emailAddress;
    }
    
    public CustomerId Id { get; set; }
    public CustomerName Name { get; set; }
    public EmailAddress EmailAddress { get; set; }

    public static void AddCustomer(CustomerName name, EmailAddress emailAddress)
    {
        new CustomerAdded
        {
            Id = CustomerId.Next(),
            Name = name,
            EmailAddress = emailAddress,
        };
    }
}