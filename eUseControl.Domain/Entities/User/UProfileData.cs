﻿using eUseControl.Domain.Enums;

namespace eUseControl.Domain.Entities.User
{
    public class UProfileData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public URole Level { get; set; }
    }
}
