using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ElectroMVC.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        public string? UserBirthday { get; set; }
        [Required]
        public string? UserPhone { get; set; }
        public string? UserAddress { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserPassword { get; set; }
		public Role UserRole { get; set; }
	}
	public enum Role { USER, ADMIN }
}
