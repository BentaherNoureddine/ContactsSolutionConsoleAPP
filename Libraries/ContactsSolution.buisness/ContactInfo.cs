using ContactsSolution.Data;
using System;



namespace ContactsSolution.buisness
{
    public class ContactInfo
    {

        private enum enMode
        {
            Insert,
            Update,
            Delete
        }


        private ContactInfo(int id, string firstName, string lastName, string email, string phoneNumber, string address, DateTime dateOfBirth, int countryId, string imagePath)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.dateOfBirth = dateOfBirth;
            this.countryId = countryId;
            this.imagePath = imagePath;
            this.Mode = enMode.Update;

        }

        public ContactInfo()
        {
            this.id = -1;
            this.firstName = "";
            this.lastName = "";
            this.email = "";
            this.phoneNumber = "";
            this.address = "";
            this.dateOfBirth = DateTime.Now;
            this.countryId = 0;
            this.imagePath = "";
            this.Mode = enMode.Insert;
        }



        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int countryId { get; set; }
        public string imagePath { get; set; }



        private enMode Mode;




        private bool _create()
        {
            this.id = clsDataAccess.Create(this.firstName, this.lastName, this.email, this.phoneNumber, this.address, this.dateOfBirth, this.countryId, this.imagePath);

            return this.id != -1;
        }


        public static ContactInfo Find(int id)
        {
            int contactId = id;
            int countryId = 0;
            string firstName = "";
            string lastName = "";
            string email = "";
            string phoneNumber = "";
            string address = "";
            DateTime dateOfBirth = DateTime.Now;
            string imagePath = "";



            if (clsDataAccess.GetContactInfoByID(contactId, ref firstName, ref lastName, ref email, ref phoneNumber, ref address, ref dateOfBirth, ref countryId, ref imagePath))
            {
                return new ContactInfo(contactId, firstName, lastName, email, phoneNumber, address, dateOfBirth, countryId, imagePath);
            }
            else
            {
                return null;
            }
        }


        private bool _update()
        {
            return clsDataAccess.Update(this.id, this.firstName, this.lastName, this.email, this.phoneNumber, this.address, this.dateOfBirth, this.countryId, this.imagePath);
        }


        public bool save()
        {

            switch (this.Mode)
            {
                case enMode.Insert:
                    this.Mode = enMode.Update;
                    return _create();

                case enMode.Update:
                    return _update();
  

                default:
                    return false;


            }
        }

        public  bool Create()
        {
            this.id  = clsDataAccess.Create(this.firstName, this.lastName, this.email, this.phoneNumber, this.address, this.dateOfBirth, this.countryId, this.imagePath);

            if (this.id != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Delete(int id)
        {
            return clsDataAccess.Delete(id);
        }



    }
}
