using System.Threading;
using System.Threading.Tasks;

public interface IEventCaller
{
    void Add(IGameEvent newEvent);
    Task PlayNext(CancellationToken cancellationToken = default);
}
