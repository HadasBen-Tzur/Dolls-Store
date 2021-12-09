using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ent
{
    public partial class Users
    {
        public Users()
        {
            Orders = new HashSet<Orders>();
        }

        public short UserId { get; set; }
        public string UserName { get; set; }
        [MinLength(6, ErrorMessage = "סיסמה חייבת להכיל לפחות 6 תווים ")]
        public string Password { get; set; }
        [EmailAddress(ErrorMessage = "כתובת מייל לא תקינה")]
        public string EMail { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
