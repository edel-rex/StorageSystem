using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        
        public string UserName { get; set; } = string.Empty;
        public string? Password { get; set; }
        public ICollection<Storages>? Storage { get; set; }
    }
}   
