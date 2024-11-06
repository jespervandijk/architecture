using Domain.Models.Customers;
using Domain.Models.Customers.Events;
using Marten.Events.Aggregation;

namespace Persistence;

public class CustomerProjection : SingleStreamProjection<Customer>
{
    public Customer Create(CustomerCreated e)
    {
        return new Customer(e.Id ?? CustomerId.Empty, e.Name, e.EmailAddress);
    }
}