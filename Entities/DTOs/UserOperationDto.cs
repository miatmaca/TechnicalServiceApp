using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
  public  class UserOperationDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Claim { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }


    }
}
