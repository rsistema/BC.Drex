using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BC.Drex.Domain.Entities
{
    public class Wallet
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public bool Active { get; set; }
        public User? User { get; set; }
    }
}

