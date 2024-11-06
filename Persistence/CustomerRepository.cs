using Application.Abstractions.Repositories;
using Domain.Models.Customers;
using Marten;
using Persistence.Abstractions;

namespace Persistence;

public class CustomerRepository : Repository<Customer, CustomerId>, ICustomerRepository
{
    public CustomerRepository(IDocumentStore eventStore) : base(eventStore)
    {
    }
}