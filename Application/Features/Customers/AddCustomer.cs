using Application.Abstractions;
using Application.Abstractions.Repositories;
using Carter;
using Domain.Models.Customers;
using Domain.Models.GeneralValueObjects;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Application.Features.Customers;

public sealed class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("customers", async (AddCustomer command, ISender sender) =>
        {
            return Results.Ok(await sender.Send(command));
        });
    }
}

public record AddCustomer : ICommand<Guid>
{
    public required CustomerName Name { get; set; }
    public required EmailAddress EmailAddress { get; set; }
}

public sealed class AddCustomerHandler : ICommandHandler<AddCustomer, Guid>
{
    private readonly ICustomerRepository _customerRepository;

    public AddCustomerHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    public Task<Guid> Handle(AddCustomer request, CancellationToken cancellationToken)
    {
        var customer = Customer.CreateCustomer(request.Name, request.EmailAddress);
        _customerRepository.StartStream(customer, null);
        return Task.FromResult(customer.Id.Value);
    }
}