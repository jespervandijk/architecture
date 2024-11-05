using Application.Abstractions.Repositories;
using Domain.Models.Customers;
using Infrastructure.Abstractions;
using Marten;

namespace Infrastructure;

public class CustomerRepository : Repository<Customer, CustomerId>, ICustomerRepository
{
    public CustomerRepository(IDocumentStore eventStore) : base(eventStore)
    {
    }
}