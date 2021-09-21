using GrpcServiceTest.DAL;
using GrpcServiceTest.Models;
using GrpcServiceTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServiceTest.Services.Implementations
{
    public class AService : IAService
    {
        private readonly MyDBContext context;

        public AService(MyDBContext context)
        {
            this.context = context;
        }

        public int CountPlusOne()
        {
            MyEntity myEntity = new MyEntity() { Name = "new entity" };
            context.MyEntities.Add(myEntity);
            context.SaveChanges();

            return myEntity.ID;
        }
    }
}
