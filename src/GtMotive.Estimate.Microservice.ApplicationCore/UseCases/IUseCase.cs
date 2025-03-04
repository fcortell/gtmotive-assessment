using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases
{
    /// <summary>
    /// Interface for the handler of a use case.
    /// </summary>
    /// <typeparam name="TUseCaseInput">Type of the input message.</typeparam>
    /// <typeparam name="TUseCaseOutput">Type of the output message.</typeparam>
    public interface IUseCase<in TUseCaseInput, TUseCaseOutput>
        where TUseCaseInput : IUseCaseInput
        where TUseCaseOutput : IUseCaseOutput
    {
        /// <summary>
        /// Executes the use case with the specified input and returns the output.
        /// </summary>
        /// <param name="input">The input message for the use case.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the output message.</returns>
        Task<TUseCaseOutput> Execute(TUseCaseInput input);
    }
}
