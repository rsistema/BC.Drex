namespace BC.Drex.API.Dtos.User
{
    public class UserResponse
    {
        public Guid UserId { get; set; }
        public Guid? WalletId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
    }
}
