using Application.Abstractions.Repositories;
using Domain.Models.Customers;
using Marten;
using Persistence.Abstractions;

namespace Persistence;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(IDocumentStore eventStore) : base(eventStore)
    {
    }
}