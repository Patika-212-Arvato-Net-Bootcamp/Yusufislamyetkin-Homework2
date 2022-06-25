using Bogus;
using HomeWork_Week2.Models;
using System.Collections.Generic;

namespace HomeWork_Week2.FakeData
{
    public static class FakeData
    {
        private static List<Bootcamp> _bootcampcs;

        public static List<Bootcamp> GetBootcamp(int number)  // Fake data oluşturmamıza imkan veren kod bloğu.
        {
            if (_bootcampcs == null)
            {
                _bootcampcs = new Faker<Bootcamp>()
            .RuleFor(x => x.BootcampID, f => f.IndexFaker + 1)
            .RuleFor(x => x.BootcampStatus, f => f.Random.Bool())
            .RuleFor(x => x.BootcampName, f => f.Name.FirstName())
            .Generate(number);
            }


            return _bootcampcs;

        }

    }
}
