using __ProjectName__.DataAccess.Models;
using __ProjectName__.Domain.Models;
using Justin.EntityFramework.Model;
using Justin.EntityFramework.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __ProjectName__.DataAccess.Services {

    public interface IUserService : IBaseService<User> {
        
    }

    public class UserService : BaseService<User>, IUserService {

        private readonly __ProjectName__DbContext _dbContext;
        public UserService(__ProjectName__DbContext dbContext) : base(dbContext) {
            _dbContext = dbContext;
        }

    }
}
