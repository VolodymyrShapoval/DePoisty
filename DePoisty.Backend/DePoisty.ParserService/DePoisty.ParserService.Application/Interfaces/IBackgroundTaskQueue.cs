namespace DePoisty.ParserService.Application.Interfaces
{
    public interface IBackgroundTaskQueue
    {
        void Queue(Func<CancellationToken, IServiceProvider, Task> workItem);
        Task<Func<CancellationToken, IServiceProvider, Task>> DequeueAsync(CancellationToken cancellationToken);
    }
}