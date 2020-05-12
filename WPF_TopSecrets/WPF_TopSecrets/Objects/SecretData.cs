using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TopSecrets.Objects
{
    public class SecretData
    {
        public bool IsSelected { get; set; }
        public string Url { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }   
    }
}
