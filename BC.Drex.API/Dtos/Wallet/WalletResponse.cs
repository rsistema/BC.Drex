namespace BC.Drex.API.Dtos.Wallet
{
    public class WalletResponse
    {
        public Guid WalletId { get; set; }
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public bool isActive { get; set; }
    }
}
