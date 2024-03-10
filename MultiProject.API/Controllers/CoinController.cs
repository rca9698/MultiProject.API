using Application.CoinsDetail.Command;
using Application.CoinsDetail.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public CoinController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetTransaction")]
        public async Task<ReturnType<CoinModel>> GetTransaction(ListCoinsDetailQuery request)
        {
            ReturnType<CoinModel> returnType = new ReturnType<CoinModel>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > GetAccounts");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddCoins")]
        public async Task<ReturnType<bool>> AddCoins(AddCoinsCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AddCoins");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteCoins")]
        public async Task<ReturnType<bool>> DeleteCoins(DeleteCoinsCommand request)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {
                await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at AccountController > AddCoins");
            }
            return returnType;
        }
    }
}
