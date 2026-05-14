﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace backend.Position.Module.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<T> : Controller
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;

        public BaseController(IMapper mapper, ILogger<T> logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        protected string GetUserIdFromClaims()
        {
            var userIdClaim = User.FindFirst("Id");
            if (userIdClaim != null)
            {
                return userIdClaim.Value;
            }

            throw new AuthenticationException();
        }
    }
}