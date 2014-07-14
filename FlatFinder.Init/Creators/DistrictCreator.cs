using System;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.Ad;
namespace FlatFinder.Init.Creators
{
    internal class DistrictCreator: BaseCreator
    {
        public static District Centralny;
        public static District Soviet;
        public static District Pervomaisky;
        public static District Partizansky;
        public static District Zavodskoy;
        public static District Leninsky;
        public static District October;
        public static District Moskovsky;
        public static District Frunzensky;

        public override void Initialize(IFlatFinderUow flatFinderUow)
        {
            Console.WriteLine("District creation started...");

            try
            {
                base.Initialize(flatFinderUow);

                Centralny = CreateDistrict("Центральный");
                Soviet = CreateDistrict("Советский");
                Pervomaisky = CreateDistrict("Первомайский");
                Partizansky = CreateDistrict("Партизанский");
                Zavodskoy = CreateDistrict("Заводской");
                Leninsky = CreateDistrict("Ленинский");
                October = CreateDistrict("Октябрьский");
                Moskovsky = CreateDistrict("Московский");
                Frunzensky = CreateDistrict("Фрунзенский");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured during entities creation. Details: {0}", ex.Message);
            }

            Console.WriteLine("District creation completed.");
        }

        private District CreateDistrict(string name)
        {
            var newItem = new District
            {
                Name = name
            };

            Uow.Districts.Insert(newItem);
            Uow.Commit();
            return newItem;
        }
    }
}
