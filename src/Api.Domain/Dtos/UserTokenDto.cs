﻿namespace Domain.Dtos
{
    public class UserTokenDto
    {
        public bool Authenticated { get; set; }
        public DateTime Expiration { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
    }
}
