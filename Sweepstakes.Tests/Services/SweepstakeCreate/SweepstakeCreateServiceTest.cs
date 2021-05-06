using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sweepstakes.Entities;
using Sweepstakes.Repositories;
using Sweepstakes.Services.SweepstakeCreate;
using System;

namespace Sweepstakes.Tests.Services.SweepstakeCreate
{
    [TestClass]
    public class SweepstakeCreateServiceTest
    {
        [TestMethod]
        public void TestCreate()
        {
            var repo = new SweepstakeRepositoryMock();
            var service = new SweepstakeCreateService(repo);

            Sweepstake sweepstake = service.Create(new SweepstakeCreateDTO()
            {
                Name = "Winter's sweepstake",
                Description = "The annual winter draw.",
                DrawDate = new DateTime(2021, 6, 1, 14, 0, 0)
            });

            Assert.IsNotNull(sweepstake.Id);
            Assert.AreEqual("Winter's sweepstake", sweepstake.Name);
            Assert.AreEqual("The annual winter draw.", sweepstake.Description);
            Assert.AreEqual(new DateTime(2021, 6, 1, 14, 0, 0), sweepstake.DrawDate);
        }
    }
}
