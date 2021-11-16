using System;
using System.ComponentModel.DataAnnotations;

public class TransactionModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [Display(Name = "Amount")]
    public decimal Amount { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public string Notice { get; set; }
}