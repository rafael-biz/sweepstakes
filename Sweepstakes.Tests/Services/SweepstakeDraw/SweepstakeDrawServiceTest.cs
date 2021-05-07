using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sweepstakes.Entities;
using Sweepstakes.Repositories;
using Sweepstakes.Services.SweepstakeCreate;
using Sweepstakes.Services.SweepstakeDetails;
using Sweepstakes.Services.SweepstakeDraw;
using Sweepstakes.Services.SweepstakeEnter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sweepstakes.Tests.Services.SweepstakeDraw
{
    [TestClass]
    public class SweepstakeDrawServiceTest
    {
        [TestMethod]
        public void TestCreate()
        {
            var repo = new SweepstakeRepositoryMock();
            var createService = new SweepstakeCreateService(repo);
            var enterService = new SweepstakeEnterService(repo);
            var detailsService = new SweepstakeDetailsService(repo);
            var drawService = new SweepstakeDrawService(repo);

            Sweepstake sweepstake = createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Winter's sweepstake",
                Description = "The annual winter draw.",
                DrawDate = new DateTime(2021, 6, 1, 14, 0, 0)
            });

            enterService.AddEntrant(sweepstake.Id, new EntrantDTO()
            {
                Name = "John",
                Email = "john@gmail.com",
                Phone = "999991111"
            });

            enterService.AddEntrant(sweepstake.Id, new EntrantDTO()
            {
                Name = "Mary",
                Email = "mary@yahoo.com",
                Phone = "999992222"
            });

            var winner = drawService.Draw(sweepstake.Id);

            Assert.IsNotNull(winner);

            var details = detailsService.Get(sweepstake.Id);

            Assert.IsNotNull(details.Winner);

            Assert.AreEqual(winner.Name, details.Winner.Name);
            Assert.AreEqual(winner.Email, details.Winner.Email);
            Assert.AreEqual(winner.Phone, details.Winner.Phone);
        }
    }
}
