using Domain.Abstractions;
using Domain.Models.Customers.Events;
using Domain.Models.GeneralValueObjects;

namespace Domain.Models.Customers;

public class Customer : AggregateRoot<CustomerId>, IAggregateRoot<CustomerId>
{
    public Customer(CustomerId customerId, CustomerName name, EmailAddress emailAddress)
    {
        Name = name;
        EmailAddress = emailAddress;
    }

    public CustomerId Id { get; }
    public CustomerName Name { get; set; }
    public EmailAddress EmailAddress { get; set; }

    public static Customer CreateCustomer(CustomerName name, EmailAddress emailAddress)
    {
        var customer = new Customer(CustomerId.Next(), name, emailAddress);
        customer.Changes.Add(new CustomerCreated
        {
            Id = customer.Id,
            Name = name,
            EmailAddress = emailAddress,
        });
        return customer;
    }
}