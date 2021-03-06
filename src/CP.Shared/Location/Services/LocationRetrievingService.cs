﻿using CP.Platform.Crud.Services;
using CP.Shared.Contract.Location.Models;
using CP.Shared.Contract.Location.Services;
using LocationEntity = CP.Repository.Models.Location;

namespace CP.Shared.Location.Services
{
    public class LocationRetrievingService : 
        SimpleRetrievingService<LocationEntity, LocationView>,
        ILocationRetrievingService
    {
    }
}