﻿using SeatManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Managers
{
    public class AllocationManager<T> : IAllocationManager<T> where T : class
    {
        private readonly string _endPoint;
        public AllocationManager(string endPoint)
        {
            _endPoint = endPoint;
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void Allocate(T obj)
        {
            var newEndpoint = _endPoint + "/allocate"; 
            IApiCall<T> newObj = new ApiCall<T>(newEndpoint); 
            newObj.PutData(obj);
        }
        public void Deallocate(T obj)
        {
            var newEndpoint = _endPoint + "/deallocate";
            IApiCall<T> newObj = new ApiCall<T>(newEndpoint);
            newObj.PutData(obj);
        }
    }
}
