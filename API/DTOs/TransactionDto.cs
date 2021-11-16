using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.DTOs
{
    public class TransactionDto
    {

    [JsonProperty("User ID")]
    [Required]
    public int UserId { get; set; }

    [Required]
    public UserDto User { get; set; }

    [JsonProperty("Amount")]
    [Required]
    public decimal Amount { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}