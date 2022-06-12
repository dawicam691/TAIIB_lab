using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public interface IAuthorizationService
    {
        public int Login(AuthorizationDto dto);
    }
}
