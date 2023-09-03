using SeatManagementDomain.Entities;
using SeatManagementDomain.Repository;
using SeatManagementAPI.DTOs;
using SeatManagementAPI.Services.Interfaces;

namespace SeatManagementAPI.Services.Implementations
{
    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Asset> GetAssets()
        {
            return _unitOfWork.Asset.GetAll();
        }

        public void AddAsset(AssetDTO assetDTO)
        {
            var Asset = new Asset()
            {
                Name = assetDTO.Name
            };
            _unitOfWork.Asset.Add(Asset);
            _unitOfWork.Commit();
        }
    }
}
