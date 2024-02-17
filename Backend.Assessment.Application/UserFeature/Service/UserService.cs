using AutoMapper;
using Backend.Assessment.Application.Interfaces;
using Backend.Assessment.Application.Repositories;
using Backend.Assessment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Assessment.Application.UserFeature.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        IRepository<User> userRepository;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            userRepository = new UserRepository(_unitOfWork);

        }
        public IActionResult CreateRandomNames()
        {
            List<User> RandomUsers = new List<User>();
            for(int i = 0; i < 10; i++)
            {
                var name = RandomString();
                RandomUsers.Add(new User() { UserName = name });
            }
            return userRepository.CreateRange(RandomUsers).Result;
        }
        
        public List<User> GetAllUsersAlphabetized()
        {
            var allUsers = userRepository.FindAll().Result.Value;
            if(allUsers != null && allUsers.Any())
            {
                allUsers = allUsers.OrderBy(x => x.UserName);
                return allUsers.ToList();
            }
            return new List<User>();
        }

        public string GetUserNameAlphabetized(string Name)
        {
            var stringSplit = Name.Split(' ');
            List<string> orderdStrings = new List<string>();
            foreach(string s in stringSplit)
            {
                orderdStrings.Add(String.Concat(s.ToLower().OrderBy(ch => ch)));
            }
            return string.Join(" ", orderdStrings.ToArray());

        }

        public string RandomString()
        {
            Random random = new Random();
            var builder = new StringBuilder(12);
            char offset = 'A';
            const int lettersOffset = 26;

            for (var i = 0; i < 12; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return builder.ToString();
        }
    }
}
