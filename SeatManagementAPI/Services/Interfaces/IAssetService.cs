using SeatManagementDomain.Entities;
using SeatManagementAPI.DTOs;

namespace SeatManagementAPI.Services.Interfaces
{
    public interface IAssetService
    {
        IEnumerable<Asset> GetAssets();
        int AddAsset(AssetDTO asset);
    }
}
