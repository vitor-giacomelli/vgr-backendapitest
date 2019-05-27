using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VacationRental.Contact.Api.Models;
using VacationRental.Contact.Api.Models.DataRepository;

namespace VacationRental.Contact.Api.Tests
{
    public class FakeContactService : IDataRepository<ContactViewModel>
    {
        private readonly List<ContactViewModel> _contacts;
        public FakeContactService()
        {
            _contacts = new List<ContactViewModel>()
            {
                new ContactViewModel(){Id=1, AboutMe ="Aboutme", Forename="Smith", NativeLanguage="English", OtherSpokenLanguages="None", Phone="55544433", Surname="William" },
                new ContactViewModel(){Id=2, AboutMe ="Aboutme", Forename="Wilkinson", NativeLanguage="Portuguese", OtherSpokenLanguages="English, Italian", Phone="55544433", Surname="Wilson" },
                new ContactViewModel(){Id=3, AboutMe ="Aboutme", Forename="Smolley", NativeLanguage="Spanish", OtherSpokenLanguages="German", Phone="55544433", Surname="Dondre" }
            };
        }

        public IActionResult Add(ContactViewModel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ContactViewModel entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactViewModel> GetAll()
        {
            return _contacts;
        }

        public ContactViewModel GetById(long id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ContactViewModel dbEntity, ContactViewModel entity)
        {
            throw new NotImplementedException();
        }

        void IDataRepository<ContactViewModel>.Add(ContactViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
