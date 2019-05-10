using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Shared
{
    public interface IUserDTO : IDTO
    {
        int Id { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Role { get; set; }
    }
}
