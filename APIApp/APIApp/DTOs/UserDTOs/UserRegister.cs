﻿namespace APIApp.DTOs.UserDTOs
{
    public class UserRegister
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public bool? Gender { get; set; }
    }
}
