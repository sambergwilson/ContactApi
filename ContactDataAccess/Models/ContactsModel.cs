﻿

namespace ContactDataAccess.Models
{
    public class ContactsModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsDelete { get; set; } 

        public ContactsModel()
        {
            
        }
    }
}
