using System;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.Ad;
using FlatFinder.Core.Domain.User;

namespace FlatFinder.Init.Creators
{
    internal class DetailedFlatAdCreator : BaseCreator
    {
        public static DetailedFlatAd FirstFlatAd;
        public static DetailedFlatAd SecondFlatAd;
        public static DetailedFlatAd ThirdFlatAd;

        public override void Initialize(IFlatFinderUow flatFinderUow)
        {
            Console.WriteLine("Flat Ad creation started...");

            try
            {
                base.Initialize(flatFinderUow);

                FirstFlatAd = CreateFlatAd(ContactInfoCreator.FirstContact, FlatInfoCreator.FirstFlat, 100, "Detailed description");
                SecondFlatAd = CreateFlatAd(ContactInfoCreator.FirstContact, FlatInfoCreator.SecondFlat, 580, "Detailed description");
                ThirdFlatAd = CreateFlatAd(ContactInfoCreator.SecondContact, FlatInfoCreator.ThirdFlat, 220, "Detailed description");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured during entities creation. Details: {0}", ex.Message);
            }

            Console.WriteLine("Flat Ad creation completed.");
        }

        private DetailedFlatAd CreateFlatAd(ContactInfo contactInfo, FlatInfo flatInfo, decimal price, string detailedDescription)
        {
            var newItem = new DetailedFlatAd
            {
                ContactInfo = contactInfo,
                ContactInfoId = contactInfo != null ? contactInfo.Id : (int?) null,
                FlatInfo = flatInfo,
                FlatInfoId = flatInfo != null ? flatInfo.Id : (int?) null,
                Price = price,
                DetailedDescription = detailedDescription
            };

            Uow.FlatAdRepository.Insert(newItem);
            Uow.Commit();
            return newItem;
        }
    }
}
