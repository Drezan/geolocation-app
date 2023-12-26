﻿using System.ComponentModel.DataAnnotations;

namespace GeolocationApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        [EmailAddress(ErrorMessage = "Set an correct email.")]
        public string Email { get; set; } = null!;
    }
}
