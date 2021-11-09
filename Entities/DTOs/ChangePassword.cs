using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
  public class ChangePassword
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public int ModifiedBy { get; set; }
    }
}
