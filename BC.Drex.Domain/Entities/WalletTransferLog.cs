namespace BC.Drex.Domain.Entities
{
    public class WalletTransferLog : BaseEntity
    {
        public Guid FromWalletId { get; set; }
        public Guid ToWalletId { get; set; }
        public decimal Amount { get; set; }
    }
}
