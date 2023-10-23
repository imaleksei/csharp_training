﻿using OpenQA.Selenium.DevTools.V116.Autofill;
using System;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

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
    }
}
