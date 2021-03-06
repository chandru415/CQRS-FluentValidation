﻿using Application.Handlers.CHandlers;
using Application.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static API.Contracts.ApiRoutes;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        [HttpGet(UserRoutes.ByUserId)]
        public async Task<IActionResult> GetByUserId([FromRoute] string userId)
            => Ok(await Mediator.Send(new UserQuery { UserId = userId }));

        [HttpPost(UserRoutes.createuser)]
        public async Task<IActionResult>
        UpdateSocialDetails([FromBody] CreateUserCommand createUser)
        {
            var result = await Mediator.Send(createUser);
            return Created($"/user/{result.UserId}", result);
        }
    }
}
