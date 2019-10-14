using System;
using System.Linq;
using TODOListApplication.Business.Services.Interfaces;
using TODOListApplication.Data;
using TODOListApplication.Data.DbModel;
using TODOListApplication.ServiceModel.Account;

namespace TODOListApplication.Business.Services
{
    public class UserService : IUserService
    {
        private readonly ITodoListApplicationRepository _dbRepository;
        public UserService(ITodoListApplicationRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public void GetUserList()
        {
            var a = _dbRepository.Where<User>(e => e.Id == 1).ToList();

        }

        public RegisterRs Register(RegisterRq request)
        {
            var response = new RegisterRs();
            var user= new User();
            user.EmailAdress = request.Email;
            user.Name = request.Name;
            user.Password = request.Password;
            user.CreatedDate=DateTime.Now;
            user.Status =1;

            _dbRepository.Add(user);
            _dbRepository.SaveChanges();
            response.UserId = user.Id;
            return response;
        }

        public LoginRs Login(LoginRq request)
        {
            var response = new LoginRs();
            var user = _dbRepository.FirstOrDefault<User>(e =>
                e.EmailAdress.Equals(request.Email) && e.Password.Equals(request.Password));
            if (user == null)
            {
                
                response.IsSuccess = false;
                response.Message = "The email or password entered is incorrect.";
                return response;
            }

            response.UserId = user.Id;

            return response;
        }
    }
}
