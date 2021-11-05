using Movie_catalog_react.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_catalog_react.Abstract
{
     public interface IUserRepository
    {
        public User Create(User user);
        public User GetByEmail(string email);
        public User GetById(int id);

    }
}
