using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IzendaBoundary.Models
{
    public class UserDetail
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
    }
}