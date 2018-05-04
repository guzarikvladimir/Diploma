using System;

namespace CP.Platform.RequestTime.Contract
{
    public interface IRequestTimeService
    {
        DateTime Time { get; }
    }
}