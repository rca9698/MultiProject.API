using Application.Common.Interface;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.LoginSgnup.Command
{
    public class LoginHandler : IRequestHandler<LoginCommand,ReturnType<bool>>
    {
        private readonly ILoginSignupRepository _loginSignupRepository;
        public LoginHandler(ILoginSignupRepository loginSignupRepository)
        {
            _loginSignupRepository = loginSignupRepository;
        }

        public async Task<ReturnType<bool>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ReturnType<bool> result = new ReturnType<bool>();
            try
            {
                return await _loginSignupRepository.Login(request);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
