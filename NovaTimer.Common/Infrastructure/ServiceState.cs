using System;
namespace NovaTimer.Common.Infrastructure
{
    public enum ServiceState
    {
        Uninitialized,
        Initialized,
        Running,
        Paused,
        Stopped,
        Faulted
    }
}
