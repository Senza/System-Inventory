﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSysUI.Library.Models
{
    public class LoggedInUserModel : ILoggedInUserModel
    {
        public string Token { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string IDNumber { get; set; }
        public DateTime CreatedDate { get; set; }

        public void ResetUserModel()
        {
            Token = "";
            Id = "";
            FirstName = "";
            LastName = "";
            EmailAddress = "";
            IDNumber = "";
            CreatedDate = DateTime.MinValue;
    }
    }
}
