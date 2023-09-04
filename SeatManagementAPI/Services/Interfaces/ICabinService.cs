﻿using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface ICabinService
    {
        IEnumerable<Cabin> GetCabins();
        void AddCabin(CabinDTO cabinDTO);

        IEnumerable<Cabin> GetUnoccupiedCabins();

        void AllocateCabin(int CabinId, int EmployeeId);
    }
}
