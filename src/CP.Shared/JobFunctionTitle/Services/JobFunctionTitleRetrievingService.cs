﻿using CP.Platform.Crud.Services;
using CP.Shared.Contract.JobFunctionTitile.Models;
using CP.Shared.Contract.JobFunctionTitile.Services;
using JobFunctionTitleEntity = CP.Repository.Models.JobFunctionTitle;

namespace CP.Shared.JobFunctionTitle.Services
{
    public class JobFunctionTitleRetrievingService : 
        SimpleRetrievingService<JobFunctionTitleEntity, JobFunctionTitleView>,
        IJobFunctionTitleRetrievingService
    {
    }
}