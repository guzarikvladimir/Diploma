using System;
using CP.Platform.RequestTime.Contract;

namespace CP.Platform.RequestTime.Services
{
    public class RequestTime : IRequestTime
    {
        public DateTime Time => DateTime.Now;
    }
}