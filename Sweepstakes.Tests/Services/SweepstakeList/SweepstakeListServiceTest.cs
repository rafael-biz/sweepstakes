using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sweepstakes.Services.SweepstakeCreate;
using Sweepstakes.Services.SweepstakeList;
using System;
using System.Collections.Generic;

namespace Sweepstakes.Tests.Services.SweepstakeList
{
    [TestClass]
    public sealed class SweepstakeListServiceTest
    {
        [TestMethod]
        [Description("It must return a list of sweepstake ordered by descending draw date.")]
        public void TestGetAll()
        {
            var provider = SweepstakeServiceProviderFactory.Build();

            var createService = provider.GetRequiredService<SweepstakeCreateService>();
            var listService = provider.GetRequiredService<SweepstakeListService>();

            createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Dovis",
                Description = "Mother's day giveaway.",
                DrawDate = new DateTime(2021, 6, 21, 14, 0, 0)
            });

            createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Domingo’s Pizza",
                Description = "Pizza Time for a Year!",
                DrawDate = new DateTime(2021, 12, 21, 14, 0, 0)
            });

            createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Maromba Supplements",
                Description = "The annual clearance draw.",
                DrawDate = new DateTime(2021, 3, 20, 14, 0, 0)
            });

            createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Fresh Foods Inc",
                Description = "Win $1000 a week for life.",
                DrawDate = new DateTime(2021, 9, 22, 14, 0, 0)
            });

            IEnumerable<SweepstakeListDTO> items = listService.GetAll();

            var enumerator = items.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext(), "Sweepstake not found.");
            
            Assert.IsNotNull(enumerator.Current.Id);
            Assert.AreEqual("Domingo’s Pizza", enumerator.Current.Name);
            Assert.AreEqual("Pizza Time for a Year!", enumerator.Current.Description);
            Assert.AreEqual(new DateTime(2021, 12, 21, 14, 0, 0), enumerator.Current.DrawDate);

            Assert.IsTrue(enumerator.MoveNext(), "Sweepstake not found.");

            Assert.IsNotNull(enumerator.Current.Id);
            Assert.AreEqual("Fresh Foods Inc", enumerator.Current.Name);
            Assert.AreEqual("Win $1000 a week for life.", enumerator.Current.Description);
            Assert.AreEqual(new DateTime(2021, 9, 22, 14, 0, 0), enumerator.Current.DrawDate);

            Assert.IsTrue(enumerator.MoveNext(), "Sweepstake not found.");

            Assert.IsNotNull(enumerator.Current.Id);
            Assert.AreEqual("Dovis", enumerator.Current.Name);
            Assert.AreEqual("Mother's day giveaway.", enumerator.Current.Description);
            Assert.AreEqual(new DateTime(2021, 6, 21, 14, 0, 0), enumerator.Current.DrawDate);

            Assert.IsTrue(enumerator.MoveNext(), "Sweepstake not found.");

            Assert.IsNotNull(enumerator.Current.Id);
            Assert.AreEqual("Maromba Supplements", enumerator.Current.Name);
            Assert.AreEqual("The annual clearance draw.", enumerator.Current.Description);
            Assert.AreEqual(new DateTime(2021, 3, 20, 14, 0, 0), enumerator.Current.DrawDate);

            Assert.IsFalse(enumerator.MoveNext(), "Too many itens on the list.");
        }
    }
}
