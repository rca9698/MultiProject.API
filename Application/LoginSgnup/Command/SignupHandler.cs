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
    public class SignupHandler : IRequestHandler<SignupCommand,ReturnType<bool>>
    {
        private readonly ILoginSignupRepository _loginSignupRepository;
        public SignupHandler(ILoginSignupRepository loginSignupRepository)
        {
            _loginSignupRepository = loginSignupRepository;
        }

        public async Task<ReturnType<bool>> Handle(SignupCommand request, CancellationToken cancellationToken)
        {

            ReturnType<bool> result = new ReturnType<bool>();
            try
            {
                return await _loginSignupRepository.Signup(request);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
