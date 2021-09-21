using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcServiceTest;
using NUnit.Framework;

namespace GrpcServiceUnitTest
{
    public class CatTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFeed()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5002");
            var client = new Cat.CatClient(channel);

            CatFood catFood = new CatFood() { FoodName = "Dry food" };
            HungerStatus reply = client.Feed(catFood);
            Assert.IsTrue(reply.Status.Contains(catFood.FoodName));
        }

        [Test]
        public void TestGetCount()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5002");
            var client = new Cat.CatClient(channel);

            // 1st request
            Count reply = client.IncreaseCount(new Empty());
            int orig = reply.Count_;

            // 2nd request
            reply = client.IncreaseCount(new Empty());
            Assert.AreEqual(orig + 1, reply.Count_);
        }
    }
}