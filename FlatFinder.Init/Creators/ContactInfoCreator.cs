using System;
using FlatFinder.Contracts;
using FlatFinder.Core.Domain.User;

namespace FlatFinder.Init.Creators
{
    internal class ContactInfoCreator: BaseCreator
    {
        public static ContactInfo FirstContact;
        public static ContactInfo SecondContact;

        public override void Initialize(IFlatFinderUow flatFinderUow)
        {
            Console.WriteLine("Contact Info creation started...");

            try
            {
                base.Initialize(flatFinderUow);

                FirstContact = CreateContactInfo("Dealer Bob", "bob@realt.com", "(029) 101-10-20", "(017) 101-10-20");
                SecondContact = CreateContactInfo("Dealer Kenny", "kenny@realt.com", "(029) 333-33-33", "(017) 333-33-33");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured during entities creation. Details: {0}", ex.Message);
            }

            Console.WriteLine("Contact creation completed.");
        }

        private ContactInfo CreateContactInfo(string contactName, string email, string primaryPhoneNumber, string secondaryPhoneNumber)
        {
            var newItem = new ContactInfo
                {
                    ContactName = contactName,
                    Email = email,
                    PrimaryPhoneNumber = primaryPhoneNumber,
                    SecondaryPhoneNumber = secondaryPhoneNumber
                };

            Uow.ContactInfos.Insert(newItem);
            Uow.Commit();
            return newItem;
        }
    }
}
