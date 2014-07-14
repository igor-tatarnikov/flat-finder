using System;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.Ad;

namespace FlatFinder.Init.Creators
{
    internal class FlatInfoCreator : BaseCreator
    {
        public static FlatInfo FirstFlat;
        public static FlatInfo SecondFlat;
        public static FlatInfo ThirdFlat;

        public override void Initialize(IFlatFinderUow flatFinderUow)
        {
            Console.WriteLine("Flat Info creation started...");

            try
            {
                base.Initialize(flatFinderUow);

                FirstFlat = CreateFlatInfo("The cheapest flat ever!", AddressCreator.Address1, 4, 1);
                SecondFlat = CreateFlatInfo("The most comfortable flat ever!", AddressCreator.Address2, 3, 4);
                ThirdFlat = CreateFlatInfo("A standart flat. Take it for granted", AddressCreator.Address3, 1, 7);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured during entities creation. Details: {0}", ex.Message);
            }

            Console.WriteLine("Flat Info creation completed.");
        }

        private FlatInfo CreateFlatInfo(string description, Address address, int floor, int roomsCount)
        {
            var newItem = new FlatInfo
            {
                Description = description,
                Address = address,
                Floor = floor,
                RoomsCount = roomsCount
            };

            Uow.FlatInfos.Insert(newItem);
            Uow.Commit();
            return newItem;
        }
    }
}
