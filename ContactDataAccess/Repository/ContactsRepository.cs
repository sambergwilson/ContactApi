using ContactDataAccess.Context;
using ContactDataAccess.Models;

namespace ContactDataAccess.Repository
{
    public class ContactsRepository
    {
        private readonly ContactsDbContext _context;
        
        public ContactsRepository()
        {
            _context = new ContactsDbContext();
        }

        public async Task<ContactsModel> CreateAsync(ContactsModel model)
        {
            await _context.Entities.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task<bool> DeleteAsync(ContactsModel isDeleted)
        {
            var existingContact = _context.Entities.Find(isDeleted.ID);

            if (existingContact is not null)
            {
                existingContact.IsDelete = true;
            }

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<ContactsModel> UpdateAsync(ContactsModel model)
        {
            var existingContact = _context.Entities.Find(model.ID);

            if (existingContact != null)
            {
                existingContact.FirstName = model.FirstName;
                existingContact.LastName = model.LastName;
                existingContact.Email = model.Email;
                existingContact.PhoneNumber = model.PhoneNumber;
                existingContact.IsDelete = model.IsDelete;

                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<IQueryable<ContactsModel>> IsDeleted(bool isDeleted)
        {
            var deletedContact = _context.Entities.Where(a => a.IsDelete == isDeleted);

            return deletedContact;
        }

        public async Task<ContactsModel> GetByIdAsync(int Id)
        {
            var contact = _context.Entities.Find(Id);

            return contact;
        }

        public async Task<List<ContactsModel>> GetAllAsync()
        {
            List<ContactsModel> result = _context.Entities.ToList();

            return result;
        }
    }
}
