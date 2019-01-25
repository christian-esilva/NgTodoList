﻿using NgTodoList.Domain;
using NgTodoList.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NgTodoList.Api.Controllers
{
    public class UserController : ApiController
    {
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Get(string email)
        {
            return _repository.Get(email);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
        }
    }
}
