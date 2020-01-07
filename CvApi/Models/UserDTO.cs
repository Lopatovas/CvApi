﻿namespace CvApi.Models
{
    public class UserDTO
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string CompanyID { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Password { get; set; }
    }
}
