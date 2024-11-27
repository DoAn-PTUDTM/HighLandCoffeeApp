using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using DTO;

namespace DAL_BLL
{
    public class User_DAL_BLL
    {
        HighlandCoffeeDataContext hl = new HighlandCoffeeDataContext();
        public User_DAL_BLL() { }
        public List<User> getUser()
        {
            return hl.Users.Select(u => u).ToList();
        }
        public int getUserByEmail(string email)
        {
            User uID = hl.Users.Where(u => u.Email == email).FirstOrDefault();
            return (int)uID.UserId;
        }
        public bool checkLogin(string email, string pass)
        {
            User u = hl.Users.Where(us => us.Email == email).FirstOrDefault();
            if (u != null)
            {
                if (u.Password == pass)
                {
                    return true;
                }
            }
            return false;
        }
        public User insertNewUser(string name, string email, string phone, string address)
        {
            User user=new User();
            user.FullName = name;
            user.Email = email;
            user.PhoneNumber = phone;
            user.Address = address;
            hl.Users.InsertOnSubmit(user);
            return user;
        }
    }
}
