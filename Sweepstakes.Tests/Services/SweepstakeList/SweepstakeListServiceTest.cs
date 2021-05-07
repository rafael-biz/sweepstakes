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
                Name = "Winter's sweepstake",
                Description = "The annual winter draw.",
                DrawDate = new DateTime(2021, 6, 21, 14, 0, 0)
            });

            createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Sumer's sweepstake",
                Description = "The annual sumer draw.",
                DrawDate = new DateTime(2021, 12, 21, 14, 0, 0)
            });

            createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Autumn's sweepstake",
                Description = "The annual autumn draw.",
                DrawDate = new DateTime(2021, 3, 20, 14, 0, 0)
            });

            createService.Create(new SweepstakeCreateDTO()
            {
                Name = "Spring's sweepstake",
                Description = "The annual spring draw.",
                DrawDate = new DateTime(2021, 9, 22, 14, 0, 0)
            });

            IEnumerable<SweepstakeListDTO> items = listService.GetAll();

            var enumerator = items.GetEnumerator();

            Assert.IsTrue(enumerator.MoveNext(), "Sweepstake not found.");
            
            Assert.IsNotNull(enumerator.Current.Id);
            Assert.AreEqual("Sumer's sweepstake", enumerator.Current.Name);
            Assert.AreEqual("The annual sumer draw.", enumerator.Current.Description);
            Assert.AreEqual(new DateTime(2021, 12, 21, 14, 0, 0), enumerator.Current.DrawDate);

            Assert.IsTrue(enumerator.MoveNext(), "Sweepstake not found.");

            Assert.IsNotNull(enumerator.Current.Id);
            Assert.AreEqual("Spring's sweepstake", enumerator.Current.Name);
            Assert.AreEqual("The annual spring draw.", enumerator.Current.Description);
            Assert.AreEqual(new DateTime(2021, 9, 22, 14, 0, 0), enumerator.Current.DrawDate);

            Assert.IsTrue(enumerator.MoveNext(), "Sweepstake not found.");

            Assert.IsNotNull(enumerator.Current.Id);
            Assert.AreEqual("Winter's sweepstake", enumerator.Current.Name);
            Assert.AreEqual("The annual winter draw.", enumerator.Current.Description);
            Assert.AreEqual(new DateTime(2021, 6, 21, 14, 0, 0), enumerator.Current.DrawDate);

            Assert.IsTrue(enumerator.MoveNext(), "Sweepstake not found.");

            Assert.IsNotNull(enumerator.Current.Id);
            Assert.AreEqual("Autumn's sweepstake", enumerator.Current.Name);
            Assert.AreEqual("The annual autumn draw.", enumerator.Current.Description);
            Assert.AreEqual(new DateTime(2021, 3, 20, 14, 0, 0), enumerator.Current.DrawDate);

            Assert.IsFalse(enumerator.MoveNext(), "Too many itens on the list.");
        }
    }
}
