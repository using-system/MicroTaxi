namespace Trip.Api.Application.Behaviors
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using MediatR;

    using Trip.Api.Application.IntegrationEvents;
    using Trip.Api.Infrastructure.Data;


    /// <summary>
    /// Transaction Behaviour
    /// </summary>
    /// <typeparam name="TRequest">The type of the request.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <seealso cref="MediatR.IPipelineBehavior{TRequest, TResponse}" />
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;
        private readonly TripContext _dbContext;
        private readonly ITripIntegrationEventService tripIntegrationEventService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionBehaviour{TRequest, TResponse}" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="tripIntegrationEventService">The ordering integration event service.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">TripContext
        /// or
        /// tripIntegrationEventService
        /// or
        /// ILogger</exception>
        public TransactionBehaviour(TripContext dbContext,
            ITripIntegrationEventService tripIntegrationEventService,
            ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(TripContext));
            this.tripIntegrationEventService = tripIntegrationEventService ?? throw new ArgumentException(nameof(tripIntegrationEventService));
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        }

        /// <summary>
        /// Handles the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="next">The next.</param>
        /// <returns></returns>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);
            var typeName = GetGenericTypeName(request);

            try
            {
                if (_dbContext.HasActiveTransaction)
                {
                    return await next();
                }

                var strategy = _dbContext.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {
                    using (var transaction = await _dbContext.BeginTransactionAsync())
                    {
                        _logger.LogInformation("----- Begin transaction {TransactionId} for {CommandName} ({@Command})", transaction.TransactionId, typeName, request);

                        response = await next();

                        _logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}", transaction.TransactionId, typeName);

                        await _dbContext.CommitTransactionAsync(transaction);
                    }

                    await tripIntegrationEventService.PublishEventsThroughEventBusAsync();
                });

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

                throw;
            }
        }

        private static string GetGenericTypeName(object @object)
        {
            var typeName = string.Empty;
            var type = @object.GetType();

            if (type.IsGenericType)
            {
                var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
                typeName = $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
            }
            else
            {
                typeName = type.Name;
            }

            return typeName;
        }
    }
}
