using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoyaPrelest.Models;
using MoyaPrelest.Mocks;
using System.Text.Json;
using System.Collections.Generic;

namespace MoyaPrelestTest
{
    [TestClass]
    public class UnitTest1
    {
        public static void Equality(object a, object b) =>
            Assert.AreEqual(
                JsonSerializer.Serialize(a),
                JsonSerializer.Serialize(b));
        public DogeMock dog = new DogeMock();

        [TestMethod]
        public void Test41()
        {
            var expect = dog.dogs.GetRange(0, 10);
            var reality = dog.BreedGrouping("Такса");

            Equality(expect, reality);
        }
        [TestMethod]
        public void Test42()
        {
            var expect = dog.dogs.GetRange(10, 10);
            expect.Reverse();
            var reality = dog.AgeRanking("Овчарка");
            Equality(expect, reality);
        }
        [TestMethod]
        public void Test43()
        {
            var expect = 3.5;
            var reality = dog.BreedAverageAge("Бульдог");
            Equality(expect, reality);
        }
    }
}
