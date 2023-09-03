using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;

namespace SeatManagement.DataAccess.SeedData
{
    public class SeedData
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeedData(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Initialize()
        {
            if (!_unitOfWork.Asset.GetAll().Any())
            {
                _unitOfWork.Asset.AddRange(new List<Asset>
                {
                    new Asset
                    {
                        Name = "Television"
                    },
                    new Asset
                    {
                        Name = "Projector"
                    },
                    new Asset
                    {
                        Name = "Refridgerator"
                    }
                });
                _unitOfWork.Commit();
            }

            if (!_unitOfWork.Building.GetAll().Any())
            {
                _unitOfWork.Building.AddRange(new List<Building>
                {
                    new Building
                    {
                        Name = "Yamuna",
                        Abbreviation = "YAM"
                    },
                    new Building
                    {
                        Name = "Ganga",
                        Abbreviation = "GAN"
                    },
                    new Building
                    {
                        Name = "Kaveri",
                        Abbreviation = "KAV"
                    }
                });
                _unitOfWork.Commit();
            }

            if (!_unitOfWork.City.GetAll().Any())
            {
                _unitOfWork.City.AddRange(new List<City>
                {
                    new City
                    {
                        Name = "Thiruvanathapuram",
                        Abbreviation = "TVM"
                    },
                    new City
                    {
                        Name = "Bengaluru",
                        Abbreviation = "BLR"
                    },
                    new City
                    {
                        Name = "Hyderabad",
                        Abbreviation = "HYD"
                    }
                });
                _unitOfWork.Commit();
            }

            if (!_unitOfWork.Department.GetAll().Any())
            {
                _unitOfWork.Department.AddRange(new List<Department>
                {
                    new Department
                    {
                        Name = "Human Resource"
                    },
                    new Department
                    {
                        Name = "Sales"
                    },
                    new Department
                    {
                        Name = "Engineering"
                    }
                });
                _unitOfWork.Commit();
            }

            if (!_unitOfWork.Employee.GetAll().Any())
            {
                _unitOfWork.Employee.AddRange(new List<Employee>
                {
                    new Employee
                    {
                        Name = "John Doe",
                        DepartmentId = 1
                    },
                    new Employee
                    {
                        Name = "Jane Doe",
                        DepartmentId = 2
                    },
                    new Employee
                    {
                        Name = "Jeenifer Doe",
                        DepartmentId = 1
                    }
                });
                _unitOfWork.Commit();
            }

            if (!_unitOfWork.Facility.GetAll().Any())
            {
                _unitOfWork.Facility.AddRange(new List<Facility>
                {
                    new Facility
                    {
                        Name = "ABC",
                        Floor = 1,
                        CityId = 1,
                        BuildingId = 1
                    },
                    new Facility
                    {
                        Name = "DEF",
                        Floor = 6,
                        CityId = 1,
                        BuildingId = 1
                    },
                    new Facility
                    {
                        Name = "GHI",
                        Floor = 10,
                        CityId = 1,
                        BuildingId = 1
                    }
                });
                _unitOfWork.Commit();
            }

            if (!_unitOfWork.Cabin.GetAll().Any())
            {
                _unitOfWork.Cabin.AddRange(new List<Cabin>
                {
                    new Cabin
                    {
                        Name = "C001",
                        FacilityId = 1,
                        EmployeeId = 1
                    },
                    new Cabin
                     {
                        Name = "C002",
                        FacilityId = 1,
                        EmployeeId = 2
                    },
                    new Cabin
                     {
                        Name = "C003",
                        FacilityId = 2,
                        EmployeeId = 3
                    },
                });
                _unitOfWork.Commit();
            }

            if (!_unitOfWork.Seat.GetAll().Any())
            {
                _unitOfWork.Seat.AddRange(new List<Seat>
                {
                    new Seat
                    {
                        Name = "S001",
                        FacilityId = 1,
                        EmployeeId = 1
                    },
                    new Seat
                    {
                        Name = "S002",
                        FacilityId = 1,
                        EmployeeId = 2
                    },
                    new Seat
                    {
                        Name = "S003",
                        FacilityId = 1,
                        EmployeeId = 3
                    },
                });
                _unitOfWork.Commit();
            }

            _unitOfWork.Commit();
        }
    }
}
