﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class UserForRegisterDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
