using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcServiceTest.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceTest.APIs
{
    public class CatAPI : Cat.CatBase
    {
        private readonly ILogger<CatAPI> _logger;
        private readonly IAService aService;

        public CatAPI(ILogger<CatAPI> logger, IAService aService)
        {
            _logger = logger;
            this.aService = aService;
        }

        public override Task<HungerStatus> Feed(CatFood food, ServerCallContext context)
        {
            _logger.LogDebug("Feed");

            return Task.FromResult(new HungerStatus
            {
                Status = $"I am full from eating {food.FoodName}"
            });
        }

        public override Task<Count> IncreaseCount(Empty empty, ServerCallContext context)
        {
            int a = aService.CountPlusOne();
            return Task.FromResult(new Count
            {
                Count_ = a
            });
        }

    }
}
