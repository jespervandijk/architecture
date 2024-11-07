using System.Text.Json.Serialization;
using Domain.Abstractions;
using Domain.Models.Customers.Events;
using Domain.Models.GeneralValueObjects;
using Marten.Events.Aggregation;

namespace Domain.Models.Customers;

public class Customer : AggregateRoot
{
    // Empty Constructor for Marten
    public Customer()
    {
    }
    
    public Customer(CustomerName name, EmailAddress emailAddress, Guid? streamId = null) : base(streamId)
    {
        Name = name;
        EmailAddress = emailAddress;
    }
    
    public CustomerId Id => new(StreamId);
    public CustomerName Name { get; set; }
    public EmailAddress EmailAddress { get; set; }

    public static Customer CreateCustomer(CustomerName name, EmailAddress emailAddress)
    {
        var customer = new Customer(name, emailAddress);
        customer.Changes.Add(
            new CustomerCreated
            {
                StreamId = customer.StreamId,
                Name = customer.Name,
                EmailAddress = customer.EmailAddress,
            });
        return customer;
    }
}

public class CustomerProjection : SingleStreamProjection<Customer>
{
    public static Customer Create(CustomerCreated @event)
    {
        return new Customer(@event.Name, @event.EmailAddress, @event.StreamId);
    }
}
