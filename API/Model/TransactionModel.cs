using System;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string Notice { get; set; }
    }
}