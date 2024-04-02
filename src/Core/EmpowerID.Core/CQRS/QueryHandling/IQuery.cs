namespace EmpowerID.Core.CQRS.QueryHandling;

public interface IQuery<out TResponse> : IRequest<TResponse> {}