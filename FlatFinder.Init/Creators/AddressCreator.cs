using System;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Init.Creators
{
    internal class AddressCreator: BaseCreator
    {
        public static Address Address1;
        public static Address Address2;
        public static Address Address3;

        public override void Initialize(IFlatFinderUow flatFinderUow)
        {
            Console.WriteLine("Address creation started...");

            try
            {
                base.Initialize(flatFinderUow);

                Address1 = CreateAddress("Минск", "Маяковского", 10, 5, DistrictCreator.Leninsky);
                Address2 = CreateAddress("Минск", "Гинтовта", 72, 65, DistrictCreator.Soviet);
                Address3 = CreateAddress("Минск", "Кульман", 9, 515, DistrictCreator.Centralny);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured during entities creation. Details: {0}", ex.Message);
            }

            Console.WriteLine("Address creation completed.");
        }

        private Address CreateAddress(string city, string street, decimal house, decimal flat, District district)
        {
            var newItem = new Address
            {
                City = city,
                Street = street,
                House = house,
                Flat = flat,
                District = district
            };

            Uow.Addresses.Insert(newItem);
            Uow.Commit();
            return newItem;
        }
    }
}
