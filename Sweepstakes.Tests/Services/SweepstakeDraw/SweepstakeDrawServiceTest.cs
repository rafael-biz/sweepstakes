using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sweepstakes.Entities;
using Sweepstakes.Services.SweepstakeCreate;
using Sweepstakes.Services.SweepstakeDetails;
using Sweepstakes.Services.SweepstakeDraw;
using Sweepstakes.Services.SweepstakeEnter;
using System;

namespace Sweepstakes.Tests.Services.SweepstakeDraw
{
    [TestClass]
    public class SweepstakeDrawServiceTest
    {
        [TestMethod]
        [Description("It must draw a winner.")]
        public void TestDraw()
        {
            var provider = SweepstakeServiceProviderFactory.Build();

            var createService = provider.GetRequiredService<SweepstakeCreateService>();
            var enterService = provider.GetRequiredService<SweepstakeEnterService>();
            var detailsService = provider.GetRequiredService<SweepstakeDetailsService>();
            var drawService = provider.GetRequiredService<SweepstakeDrawService>();

            Sweepstake sweepstake = createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Dovis",
                Description = "Mother's day giveaway.",
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
