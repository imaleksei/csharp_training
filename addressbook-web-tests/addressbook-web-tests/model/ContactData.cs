﻿

namespace WebAddressBookTests
{
    public class ContactData
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
        private string homeTwo = "";
        private string notes = "";
        private string bday = "-";
        private string bmonth = "-";
        private string byear = "";
        private string aday = "-";
        private string amonth = "-";
        private string ayear = "";
        private string photo = "C:\\xampp\\TestAdditions\\Capture.PNG";

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
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

        public string HomeTwo
        {
            get
            {
                return homeTwo;
            }
            set
            {
                homeTwo = value;
            }
        }

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
    }
}