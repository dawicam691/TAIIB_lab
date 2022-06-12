using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class AuthorizationService : IAuthorizationService
    {
        public User user;
        public int Login(AuthorizationDto dto)
        {
            if (user.Login == dto.Login && user.Password == dto.Password)
                return user.Id;
            return -1;
        }
    }
}
