using Application.Abstractions;
using Carter;
using Domain.Models.Customers;
using Marten;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Application.Features.Customers;

public sealed class GetCustomersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("customers",
            async (ISender sender) => Results.Ok(await sender.Send(new GetCustomersQuery())));
    }
}

public class GetCustomersQuery : IQuery<List<Customer>>
{
}

public class GetCustomersQueryHandler : IQueryHandler<GetCustomersQuery, List<Customer>>
{
    private readonly IDocumentStore _eventStore;

    public GetCustomersQueryHandler(IDocumentStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        await using var session = _eventStore.QuerySession();
        return session.Query<Customer>().ToList();
    }
}