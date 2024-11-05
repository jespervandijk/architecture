using Domain.Abstractions;
using Domain.Models.Customers.Events;
using Qowaiv;

namespace Domain.Models.Customers;

public class Customer : AggregateRoot<CustomerId>
{
    private Customer(CustomerName name, EmailAddress emailAddress) : base(CustomerId.Next())
    {
        Name = name;
        EmailAddress = emailAddress;
    }
    public CustomerName Name { get; set; }
    public EmailAddress EmailAddress { get; set; }

    public static Customer CreateCustomer(CustomerName name, EmailAddress emailAddress)
    {
        var customer = new Customer(name, emailAddress);
        customer.Changes.Add(new CustomerCreated
        {
            Id = customer.Id,
            Name = name,
            EmailAddress = emailAddress,
        });
        return customer;
    }
}