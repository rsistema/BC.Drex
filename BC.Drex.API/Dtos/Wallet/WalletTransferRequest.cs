using System.Text.Json.Serialization;

namespace BC.Drex.API.Dtos.Wallet
{
    public class WalletTransferRequest
    {
        [JsonIgnore]
        public Guid? FromUserId { get; set; }
        public Guid ToWalletId { get; set; }
        public decimal Amount { get; set; }
    }
}
