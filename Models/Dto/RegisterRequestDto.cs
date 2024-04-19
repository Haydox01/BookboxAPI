﻿using System.ComponentModel.DataAnnotations;

namespace Bookbox.Models.Dto
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
      //  [EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}