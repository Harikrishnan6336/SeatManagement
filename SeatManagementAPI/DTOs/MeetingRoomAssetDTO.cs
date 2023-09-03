using SeatManagementDomain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementAPI.DTOs
{
    public class MeetingRoomAssetDTO
    { 
        public int Quantity { get; set; }
        public int MeetingRoomId { get; set; }
        public int AssetId { get; set; }
    }
}
