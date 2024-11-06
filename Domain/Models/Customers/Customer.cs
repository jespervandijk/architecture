using Domain.Abstractions;
using Domain.Models.Customers.Events;

namespace Domain.Models.Customers;

public class Customer : AggregateRoot<CustomerId>
{
    private Customer(CustomerName name, CustomerEmailAddress emailAddress) : base(CustomerId.Next())
    {
        Name = name;
        EmailAddress = emailAddress;
    }
    public CustomerName Name { get; set; }
    public CustomerEmailAddress EmailAddress { get; set; }

    public static Customer CreateCustomer(CustomerName name, CustomerEmailAddress emailAddress)
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