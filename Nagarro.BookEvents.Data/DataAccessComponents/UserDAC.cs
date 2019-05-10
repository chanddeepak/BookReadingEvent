using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Data
{
    public class UserDAC : DACBase, IUserDAC
    {
        public UserDAC()
            : base(DACType.UserDAC)
        {

        }
        public IUserDTO CreateUser(IUserDTO userDTO)
        {
            //It is only for illustrative purpose
            //UserModels userEntity = new UserModels();

            using (var context = new BookReadingEventsDBEntities())
            {
                User user = new User()
                {
                    Email = userDTO.Email,
                    Password = userDTO.Password,
                    FullName = userDTO.FullName,
                    Role = userDTO.Role
                };
                bool isExist = context.User.Any(u => u.Email == user.Email);
                if(!isExist)
                {
                    context.User.Add(user);
                    context.SaveChanges();
                    return userDTO;
                }

                return null;   
            }
        }

        public IUserDTO LoginUser(IUserDTO userDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                var IsValid = context.User.SingleOrDefault(u => u.Email == userDTO.Email && u.Password == userDTO.Password);
                if (IsValid != null)
                {
                    userDTO.FullName = IsValid.FullName;
                    return userDTO;
                }

                return null;
            }

        }

    }
}
