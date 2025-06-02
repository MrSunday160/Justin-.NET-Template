using Justin.EntityFramework.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __ProjectName__.Domain.Models {
    public class User : Base {

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Nickname { get; set; }

    }
}
