using Application.CoinsDetail.Command;
using Application.CoinsDetail.Common.Interface;
using Application.CoinsDetail.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiProject.API.ServiceFilter;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ValidateSessionFilter))]
    public class CoinController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        private readonly ICoinRepository _coinRepository;
        public CoinController(IMediator mediator, ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor, ICoinRepository coinRepository) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
            _coinRepository = coinRepository; 
        }

        [HttpPost]
        [Route("GetCoinsRequest")]
        public async Task<ReturnType<CoinsRequestModel>> GetCoinsRequest(GetCoinsRequestQuery request)
        {
            ReturnType<CoinsRequestModel> returnType = new ReturnType<CoinsRequestModel>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > GetAccounts");
            }
            return returnType;
        }

        [HttpGet]
        [Route("GetCoinsToAccountRequest/{CoinType}/{SessionUser}")]
        public async Task<ReturnType<CoinsToAccountRequestModel>> GetCoinsToAccountRequest(int CoinType,long SessionUser)
        {
            ReturnType<CoinsToAccountRequestModel> returnType = new ReturnType<CoinsToAccountRequestModel>();
            GetCoinsToAccountRequestQuery request= new GetCoinsToAccountRequestQuery()
            {
                CoinType = CoinType,
                SessionUser = SessionUser
            };
            if (_userId != SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > GetCoinsToAccountRequest");
            }
            return returnType;
        }

        [HttpPost]
        [Route("GetTransaction")]
        public async Task<ReturnType<CoinsRequestModel>> GetTransaction(ListCoinsDetailQuery request)
        {
            ReturnType<CoinsRequestModel> returnType = new ReturnType<CoinsRequestModel>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > GetAccounts");
            }
            return returnType;
        }

        [HttpPost]
        [Route("AddCoinsRequest")]
        public async Task<ReturnType<string>> AddCoinsRequest(InsertCoinRequestCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > AddCoinsRequest");
            }
            return returnType;
        }

        [HttpPost]
        [Route("WithDrawCoinsRequest")]
        public async Task<ReturnType<string>> WithDrawCoinsRequest(WithdrawCoinRequestCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > AddCoinsRequest");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateCoins")]
        public async Task<ReturnType<string>> UpdateCoins(UpdateCoinsCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if(_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            } 

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > UpdateCoins");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteCoins")]
        public async Task<ReturnType<string>> DeleteCoins(DeleteCoinsCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > DeleteCoins");
            }
            return returnType;
        }


        [HttpPost]
        [Route("UpdateCoinsToAccountRequest")]
        public async Task<ReturnType<string>> UpdateCoinsToAccountRequest(UpdateCoinsToAccountRequestCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > UpdateCoinsToAccountRequest");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateCoinsToAccount")]
        public async Task<ReturnType<string>> UpdateCoinsToAccount(UpdateCoinsToAccountCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > UpdateCoinsToAccount");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteAccountRequestCoins")]
        public async Task<ReturnType<string>> DeleteAccountRequestCoins(DeleteAccountRequestCoinsCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > DeleteAccountRequestCoins");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteRequestCoins")]
        public async Task<ReturnType<string>> DeleteRequestCoins(DeleteRequestCoinsCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > DeleteRequestCoins");
            }
            return returnType;
        }



        [HttpPost]
        [Route("DepositeCoinsByUserid")]
        public async Task<ReturnType<string>> DepositeCoinsByUserid(DepositeCoinsByUseridCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _coinRepository.DepositeCoinsByUserid(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > UpdateCoins");
            }
            return returnType;
        }

        [HttpPost]
        [Route("WithdrawCoinsByuserId")]
        public async Task<ReturnType<string>> WithdrawCoinsByuserId(WithdrawCoinsByuserIdCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();

            if (_userId != request.SessionUser)
            {
                returnType.ReturnMessage = "Not a valid session User!!!";
                return returnType;
            }

            try
            {
                returnType = await _coinRepository.WithdrawCoinsByuserId(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at CoinController > DeleteCoins");
            }
            return returnType;
        }



    }
}
