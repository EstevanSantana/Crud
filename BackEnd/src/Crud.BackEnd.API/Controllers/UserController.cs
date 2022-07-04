using Crud.BackEnd.Application.Commands;
using Crud.BackEnd.Application.Queries;
using Crud.BackEnd.Application.ViewModel;
using Crud.BackEnd.Domain.Core.Mediator;
using Crud.BackEnd.Domain.Core.Messages.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Crud.BackEnd.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IMediatorHandler _mediatorHeadler;
        private readonly IUserQueries _userQueries;

        public UserController(INotificationHandler<DomainNotification> notifications,
                              IMediatorHandler mediatorHeadler,
                              IUserQueries userQueries) : base(notifications, mediatorHeadler)
        {
            _mediatorHeadler = mediatorHeadler;
            _userQueries = userQueries;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _userQueries.GetUserById(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                             "Atenção! Caso esse erro persista, entre em contato com o suporte.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _userQueries.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                             "Atenção! Caso esse erro persista, entre em contato com o suporte.");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("register-new-user")]
        public async Task<IActionResult> Post([FromBody]UserViewModel userViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                await _mediatorHeadler.SendCommand(new RegisterNewUserCommand(userViewModel.FistName, userViewModel.LastName, userViewModel.Email, userViewModel.Birthday, userViewModel.Schooling));

                return CustomResponse();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                             "Atenção! Caso esse erro persista, entre em contato com o suporte.");
            }
        }

        [HttpPut]
        [Route("update-user")]
        public async Task<IActionResult> Put(UserViewModel userViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                await _mediatorHeadler.SendCommand(new UpdateUserCommand(userViewModel.Id, userViewModel.FistName, userViewModel.LastName, userViewModel.Email, userViewModel.Birthday, userViewModel.Schooling));

                return CustomResponse();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                             "Atenção! Caso esse erro persista, entre em contato com o suporte.");
            }
        }

        [HttpDelete]
        [Route("delete-user")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponse(ModelState);

                await _mediatorHeadler.SendCommand(new RemoveUserCommand(id));

                return CustomResponse();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                             "Atenção! Caso esse erro persista, entre em contato com o suporte.");
            }
        }
    }
}
