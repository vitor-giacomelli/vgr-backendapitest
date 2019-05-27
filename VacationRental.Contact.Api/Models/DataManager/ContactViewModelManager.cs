using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VacationRental.Contact.Api.Models.DataRepository;

namespace VacationRental.Contact.Api.Models.DataManager
{
    public class ContactViewModelManager : IDataRepository<ContactViewModel>
    {
        readonly ContactViewModelContext _contactViewModelContext;

        public ContactViewModelManager(ContactViewModelContext context)
        {
            _contactViewModelContext = context;
        }
        public void Add(ContactViewModel entity)
        {
            _contactViewModelContext.Contacts.Add(entity);
            _contactViewModelContext.SaveChanges();
        }

        public void Delete(ContactViewModel entity)
        {
            _contactViewModelContext.Contacts.Remove(entity);
            _contactViewModelContext.SaveChanges();
        }

        public IEnumerable<ContactViewModel> GetAll()
        {
            return _contactViewModelContext.Contacts.ToList();
        }

        public ContactViewModel GetById(long id)
        {
            return _contactViewModelContext.Contacts
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(ContactViewModel dbEntity, ContactViewModel entity)
        {
            dbEntity.Forename = entity.Forename;
            dbEntity.AboutMe = entity.AboutMe;
            dbEntity.NativeLanguage = entity.NativeLanguage;
            dbEntity.Phone = entity.Phone;
            dbEntity.Surname = entity.Surname;
            dbEntity.OtherSpokenLanguages = entity.OtherSpokenLanguages;
            _contactViewModelContext.SaveChanges();

        }
    }
}
