using System.Collections.Generic;

namespace FormsAuthentications.Models
{
    public class SessionModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
    }
}