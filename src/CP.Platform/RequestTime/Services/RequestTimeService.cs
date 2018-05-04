using System;
using CP.Platform.RequestTime.Contract;

namespace CP.Platform.RequestTime.Services
{
    public class RequestTimeService : IRequestTimeService
    {
        public DateTime Time => DateTime.Now;
    }
}