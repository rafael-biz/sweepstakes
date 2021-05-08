using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sweepstakes.Entities;
using Sweepstakes.Services.SweepstakeCreate;
using Sweepstakes.Services.SweepstakeDetails;
using Sweepstakes.Services.SweepstakeEnter;
using System;

namespace Sweepstakes.Tests.Services.SweepstakeEnter
{
    [TestClass]
    public class SweepstakeEnterServiceTest
    {
        [TestMethod]
        [Description("It must add entrants to a sweepstake.")]
        public void TestAddEntrant()
        {
            var provider = SweepstakeServiceProviderFactory.Build();

            var createService = provider.GetRequiredService<SweepstakeCreateService>();
            var enterService = provider.GetRequiredService<SweepstakeEnterService>();
            var detailsService = provider.GetRequiredService<SweepstakeDetailsService>();

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

            var details = detailsService.Get(sweepstake.Id);

            Assert.IsNotNull(details.Id);
            Assert.AreEqual("Dovis", details.Name);
            Assert.AreEqual("Mother's day giveaway.", details.Description);
            Assert.AreEqual(new DateTime(2021, 6, 1, 14, 0, 0), details.DrawDate);

            Assert.AreEqual(2, details.Entrants.Count);

            Assert.AreEqual("John", details.Entrants[0].Name);
            Assert.AreEqual("john@gmail.com", details.Entrants[0].Email);
            Assert.AreEqual("999991111", details.Entrants[0].Phone);

            Assert.AreEqual("Mary", details.Entrants[1].Name);
            Assert.AreEqual("mary@yahoo.com", details.Entrants[1].Email);
            Assert.AreEqual("999992222", details.Entrants[1].Phone);
        }
    }
}
