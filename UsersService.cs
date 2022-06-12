using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class UsersService : IUsersService
    {
        private readonly Database _database;
        public UsersService()
        {
            if(_database.Users.Find()==null)
            {
                _database.Users.Add(new User {Login="admin", Password="admin" });
            }
        }
        public PaginatedData<UserDto> Get(PaginationDto dto)
        {
            List<UserDto> ListaUserDto = new List<UserDto>();
            List<User> ListaUser = (List<User>)(from u in _database.Users
                                    select u);
            int licznik = 0;
            foreach(var element in ListaUser)
            {
                ListaUserDto.Add(
                    new UserDto 
                    { 
                        Id=element.Id,
                        Name=element.Name,
                        Login=element.Login,
                        Surname=element.Surname,
                    }
                );
                licznik++;
            }
            switch(dto.SortColumn)
            {
                case "Id":
                    ListaUserDto.OrderBy(u=> u.Id);
                    break;
                case "Name":
                    ListaUserDto.OrderBy(u => u.Name);
                    break;
                case "Login":
                    ListaUserDto.OrderBy(u => u.Login);
                    break;
                case "Surname":
                    ListaUserDto.OrderBy(u => u.Surname);
                    break;
            }
            PaginatedData<UserDto> wynik = new PaginatedData<UserDto> { Count = licznik, Data = ListaUserDto };
            return wynik;
        }

        public UserDto Post(PostUserDto dto)
        {
            _database.Users.Add(
                new User 
                { 
                    Login = dto.Login, 
                    Password = dto.Password 
                }
             );
            UserDto user = new UserDto { Login = dto.Login };
            _database.SaveChanges();
            return user;
        }
    }
}
