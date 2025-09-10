using DePoisty.ParserService.Application.Interfaces;
using System.Threading.Channels;

namespace DePoisty.ParserService.Application.Services
{
    public class BackgroundTaskQueue : IBackgroundTaskQueue
    {
        private readonly Channel<Func<CancellationToken, IServiceProvider, Task>> _queue =
            Channel.CreateUnbounded<Func<CancellationToken, IServiceProvider, Task>>();
        public void Queue(Func<CancellationToken, IServiceProvider, Task> workItem)
        {
            if (workItem == null)
                throw new ArgumentNullException(nameof(workItem));

            _queue.Writer.TryWrite(workItem);
        }
        public async Task<Func<CancellationToken, IServiceProvider, Task>> DequeueAsync(CancellationToken cancellationToken)
        {
            return await _queue.Reader.ReadAsync(cancellationToken);
        }
    }
}