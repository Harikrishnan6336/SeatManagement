using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagementDomain.Entities
{
    public class MeetingRoomAsset
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("FK_MeetingRoomAsset_MeetingRoom_MeetingRoomId")]
        public int MeetingRoomId { get; set; }

        [ForeignKey("FK_MeetingRoomAsset_Asset_AssetId")]
        public int AssetId { get; set; }

        public Asset Asset { get; set; } = null!;

        public MeetingRoom MeetingRoom { get; set; } = null!;
    }
}
