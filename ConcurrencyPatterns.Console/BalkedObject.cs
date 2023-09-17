using System.ComponentModel;

namespace ConcurrencyPatterns.Console;

public class BalkedObject
{
    private readonly Action _job;

    private bool _isInProgress = false;

    public BalkedObject(Action job) => _job = job;

    public void DoJob()
    {
        lock (this)
        {
            if (_isInProgress)
                return;
            _isInProgress = true;
        }
        _job();
        Complete();
    }

    private void Complete()
    {
        lock (this)
        {
            _isInProgress = false;
        }
    }
}
