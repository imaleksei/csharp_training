using System;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressBookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string middleName = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string emailOne = "";
        private string emailTwo = "";
        private string emailThree = "";
        private string homepage = "";
        private string addressTwo = "";
        private string phoneTwo = "";
        private string notes = "";
        private string bday = "-";
        private string bmonth = "-";
        private string byear = "";
        private string aday = "-";
        private string amonth = "-";
        private string ayear = "";
        private string photo = "C:\\xampp\\TestAdditions\\Capture.PNG";
        
        public string allPhones;

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public ContactData()
        {

        }

        [Column(Name = "id"), PrimaryKey]
        public string Id
        {
            get; set;
        }

        [Column(Name = "firstname")]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        [Column(Name = "lastname")]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        [Column(Name = "middlename")]
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }

        [Column(Name = "nickname")]
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        [Column(Name = "title")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        [Column(Name = "company")]
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }

        [Column(Name = "address")]
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        [Column(Name = "home")]
        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }

        [Column(Name = "mobile")]
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

        [Column(Name = "work")]
        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }
        }

        [Column(Name = "fax")]
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }

        [Column(Name = "email")]
        public string EmailOne
        {
            get
            {
                return emailOne;
            }
            set
            {
                emailOne = value;
            }
        }

        [Column(Name = "email2")]
        public string EmailTwo
        {
            get
            {
                return emailTwo;
            }
            set
            {
                emailTwo = value;
            }
        }

        [Column(Name = "email3")]
        public string EmailThree
        {
            get
            {
                return emailThree;
            }
            set
            {
                emailThree = value;
            }
        }

        [Column(Name = "homepage")]
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }

        [Column(Name = "address2")]
        public string AddressTwo
        {
            get
            {
                return addressTwo;
            }
            set
            {
                addressTwo = value;
            }
        }

        [Column(Name = "phone2")]
        public string PhoneTwo
        {
            get
            {
                return phoneTwo;
            }
            set
            {
                phoneTwo = value;
            }
        }

        [Column(Name = "deprecated")]
        public string Deprecated
        { get; set; }

        [Column(Name = "notes")]
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        [Column(Name = "bday")]
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }

        [Column(Name = "bmonth")]
        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }

        [Column(Name = "byear")]
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }

        [Column(Name = "aday")]
        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }

        [Column(Name = "amonth")]
        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }

        [Column(Name = "ayear")]
        public string Ayear
        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }

        [Column(Name = "photo")]
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }

        public string AllPhones
        {
            get 
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work) + CleanUp(PhoneTwo)).Trim();
                }
            }
            set { allPhones = value; }
        }

        //---

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "firstname=" + FirstName + "\nlastname=" + LastName + "\nmiddlename=" + MiddleName;
        }

        public int CompareTo(ContactData other)
        {

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            else
            {
                return this.LastName.Equals(other.LastName) ? this.LastName.CompareTo(other.LastName) : this.FirstName.CompareTo(other.FirstName);
            }
        }

        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        //--

        public string allInfo = null;
        public string AllInfo
        {
            get
            {
                if (allInfo == null)
                {
                    if (FirstName != null && FirstName != "") allInfo += FirstName;
                    
                    if (MiddleName != null && MiddleName != "") allInfo += " " + MiddleName;
                    
                    if (LastName != null && LastName != "") allInfo += " " + LastName;

                    if (Nickname != null && Nickname != "") allInfo += "\r\n" + Nickname;

                    if (Title != null && Title != "") allInfo += "\r\n" + Title;

                    if (Company != null && Company != "") allInfo += "\r\n" + Company;

                    if (Address != null && Address != "") allInfo += "\r\n" + Address;

                    if (Home != null && Home != "") allInfo += "\r\n\r\n" + "H: " + Home;

                    if (Mobile != null && Mobile != "") allInfo += "\r\n" + "M: " + Mobile;

                    if (Work != null && Work != "") allInfo += "\r\n" + "W: " + Work;

                    if (Fax != null && Fax != "") allInfo += "\r\n" + "F: " + Fax;

                    if (EmailOne != null && EmailOne != "") allInfo += "\r\n\r\n" + EmailOne;

                    if (EmailTwo != null && EmailTwo != "") allInfo += "\r\n" + EmailTwo;

                    if (EmailThree != null && EmailThree != "") allInfo += "\r\n" + EmailThree;

                    if (Homepage != null && Homepage != "") allInfo += "\r\n" + "Homepage:\r\n" + Homepage;
                    
                    if (AddressTwo != null && AddressTwo != "") allInfo += "\r\n\r\n\r\n" + AddressTwo;
                    
                    if (PhoneTwo != null && PhoneTwo != "") allInfo += "\r\n\r\n" + "P: " + PhoneTwo;

                    if (Notes != null && Notes != "") allInfo += "\r\n\r\n" + Notes;

                    return allInfo;
                }
                return allInfo;
            }
            set
            {
                allInfo = value;
            }
        }

        //--

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
