using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetUserByName(string userName) => await _userRepository.GetByUserNameAsync(userName);

        public async Task<List<User>> GetAllUsers() => await _userRepository.GetAll();

        public async Task AddUser(User user)
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task<User> GetById(int id) => await _userRepository.GetByIdAsync(id);

        public async Task UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteUser(User user)
        {
            _userRepository.DeleteAsync(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
