﻿using System.Collections.Generic;
using CP.Compensation.Contract.Models;

namespace CP.Compensation.Contract.Services
{
    public interface ICompensationSerivce
    {
        IEnumerable<CompensationView> Get();
    }
}