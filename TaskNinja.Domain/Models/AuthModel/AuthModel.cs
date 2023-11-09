using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskNinja.Domain.Models.AuthModel
{
    public class AuthModel
    {
        public string Token { get; set; } = string.Empty;
        public bool Result { get; set; }
        public List<string>? Errors { get; set; }
    }
}
