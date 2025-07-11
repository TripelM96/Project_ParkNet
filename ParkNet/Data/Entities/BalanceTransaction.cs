﻿using Microsoft.AspNetCore.Identity;
using ParkNet.Data.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace ParkNet.Data.Entities;

public class BalanceTransaction
{
    public int Id { get; set; }

    public IdentityUser User { get; set; }
    [Required]
    public string UserId { get; set; }

    [Column(TypeName = "Datetime2(0)")]
    public DateTime Date { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Ammount { get; set; }    
    public string Description { get; set; }

}