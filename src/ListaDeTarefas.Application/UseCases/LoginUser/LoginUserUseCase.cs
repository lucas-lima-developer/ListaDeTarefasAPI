﻿using AutoMapper;
using FluentValidation;
using ListaDeTarefas.Application.Exceptions;
using ListaDeTarefas.Application.Requests;
using ListaDeTarefas.Application.Responses;
using ListaDeTarefas.Domain.Entities;
using ListaDeTarefas.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ListaDeTarefas.Application.UseCases.LoginUser
{
    public class LoginUserUseCase : ILoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IValidator<LoginUserRequest> _validator;

        public LoginUserUseCase(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, IValidator<LoginUserRequest> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _validator = validator;
        }

        public async Task<LoginUserResponse> Execute(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid) throw new ValidationErrorException(result);

            var user = await _userRepository.GetByEmail(request.Email!, cancellationToken);
            if (user == null) throw new WrongCredentialsException();

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) throw new WrongCredentialsException();

            string token = CreateToken(user);

            return new LoginUserResponse { Token = token };
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
