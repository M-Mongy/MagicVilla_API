﻿using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web.Models.DTO
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
