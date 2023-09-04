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

        public int AddAsset(AssetDTO assetDTO)
        {
            var asset = new Asset()
            {
                Name = assetDTO.Name
            };
            _unitOfWork.Asset.Add(asset);
            _unitOfWork.Commit();
            return asset.Id;
        }
    }
}
