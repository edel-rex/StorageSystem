using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace WebAPI.Models
{
    public class Storages
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Data { get; set; }
        public Users? User { get; set; }
    }
}
