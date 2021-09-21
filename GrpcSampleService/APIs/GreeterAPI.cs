using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceTest.APIs
{
    public class GreeterAPI : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterAPI> _logger;

        public GreeterAPI(ILogger<GreeterAPI> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            _logger.LogDebug("say hello");
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
