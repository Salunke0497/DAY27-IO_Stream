using day27addressbook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Runtime.CompilerServices;
using static System.Net.WebRequestMethods;

namespace day27addressbook
{
    public class AddressLogic
    {
        List<DataOfPerson> person1 = new List<DataOfPerson>();
        Dictionary<string, List<DataOfPerson>> addressBook = new Dictionary<string, List<DataOfPerson>>();

        //UC1-UC2-AddContact details
        public void addcontact()
        {
            DataOfPerson person = new DataOfPerson();
            Console.Write("Enter First Name: ");
            person.FirstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            person.LastName = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            person.PhoneNum = Console.ReadLine();
            Console.Write("Enter Address : ");
            person.Address = Console.ReadLine();
            Console.Write("Enter city : ");
            person.City = Console.ReadLine();
            Console.Write("Enter pinCode : ");
            person.ZipCode = Console.ReadLine();
            Console.Write("Enter EmailId : ");
            person.Email = Console.ReadLine();
            //person1.Add(person);
            CheckDuplicateName(person1, person);
        }
        //UC3 EditContact
        public void editcontact()
        {
            DataOfPerson person = new DataOfPerson();
            Console.WriteLine("Enter first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine();
            foreach (var contact in person1)
                if (person.FirstName == firstName && person.LastName == lastName)
                {
                    Console.WriteLine("edit phone number");
                    Console.WriteLine("enter new phone number");
                    person.PhoneNum = Console.ReadLine();
                    person1.Add(person);
                }
            Console.WriteLine("Contact sucessfully update");


        }
        //UC4 Remove contact
        public void removecontact()

        {
            DataOfPerson person = new DataOfPerson();
            Console.WriteLine("Enter the first name.");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter the last name.");
            string lastName = Console.ReadLine();
            foreach (var contact in person1)
                if (person.FirstName == firstName && person.LastName == lastName)
                {
                    person1.Remove(person);
                }
            Console.WriteLine("Contact is succesfully Removed");

        }
        // display the list
        public void Display()
        {
            foreach (var person in person1)
            {
                Console.WriteLine("Contact Details:" + "\n" + "FirstName: " + person.FirstName + "\n" + "LastName: " + person.LastName + "\n" + "Address: " + person.Address + "\n" + "City: " + person.City + "\n" + "PhoneNumber: " + person.PhoneNum + "\n" + "Email: " + person.Email);
            }

        }
        //uc5
        // add multiple data of person

        public void CreateDictionary()
        {
            Console.WriteLine("Enter with what name you want to add in dictionary");
            string name = Console.ReadLine();
            addressBook.Add(name, person1);
            person1 = new List<DataOfPerson>();
        }

        // UC6
        // display dictionary which is base on key value
        public void DisplayDictionary()
        {
            foreach (var data in addressBook)
            {
                Console.WriteLine(data.Key);         //printing dictionary keys
                foreach (var person in data.Value)   // checking values inside keys
                {
                    Console.WriteLine("Contact Details:" + "\n" + "FirstName: " + person.FirstName + "\n" + "LastName: " + person.LastName + "\n" + "Address: " + person.Address + "\n" + "City: " + person.City + "\n" + "PhoneNumber: " + person.PhoneNum + "\n" + "Email: " + person.Email);
                }
            }
        }


        //UC7 
        //Duplicate data of person (collection demo) & (LAMBADA)
        public void CheckDuplicateName(List<DataOfPerson> person1, DataOfPerson person)
        {
            if (person1.Exists(e => e.FirstName == person.FirstName && e.LastName == person.LastName))
            {
                Console.WriteLine("The person name is already exits");
            }
            else
            {
                Console.WriteLine("The person name is not already exits then add to the list");
                person1.Add(person);
                Display();
            }
        }

        //UC8-UC10.....
        public void GroupOfSameCityLiveAndState(List<DataOfPerson> person1, string Method)
        {

            if (Method.Equals("city"))
            {
                Console.WriteLine("Enter the name of city");
                string cityname = Console.ReadLine();
                Console.WriteLine(" CITY :" + cityname);
                var AddressBookCityData = person1.FindAll(e => e.City == cityname);

                foreach (var data in AddressBookCityData)
                {
                    Console.WriteLine("Name " + data.FirstName + " " + data.LastName);
                }

                // Count of person Uc10 in city
                Console.WriteLine(" Total perosn present in City {0} is {1} ", cityname, AddressBookCityData.Count());
            }
            else if (Method.Equals("state"))
            {
                // To sort the details list

                Console.WriteLine("Enter the name of state");
                string statename = Console.ReadLine();
                Console.WriteLine(" STATE :" + statename);
                var addressBookStateData = person1.FindAll(e => e.State == statename);
                foreach (var data in addressBookStateData)
                {
                    Console.WriteLine("Name " + data.FirstName + " " + data.LastName);
                }
                // Count of person Uc10 in state
                Console.WriteLine(" Total perosn present in State {0} is {1} ", statename, addressBookStateData.Count());
            }
            else
            {
                Console.WriteLine("Invalid method");
            }
        }

        // Uc9Display METHOD FOR lAMBDA EXPRESSION

        public void ViewLambdaExpression()
        {
            Console.WriteLine("Enter the serach location City/State");
            string method = Console.ReadLine().ToLower(); ;
            GroupOfSameCityLiveAndState(person1, method);
        }

        // Uc11 Sort the data of Address book by Alphabate of FirstName
        public void SortAddressBookData()
        {
            Console.WriteLine("Hint 1. List of AddressBook Sort");
            int num = Convert.ToInt16(Console.ReadLine());
            if (num == 1)
            {
                person1.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
                Display();
                return;
            }
        }
        // Uc12 Search the data by City State and Zip;     
        public void SortByCity_State_Zip()
        {
            Console.WriteLine("Hint 1.Sorted by city \n 2.Sorted by State \n 3.Sorted by Zip");
            int num = Convert.ToInt16(Console.ReadLine());
            if (num == 1)
            {
                person1.Sort((x, y) => string.Compare(x.State, y.State));
                DisplayList();
                return;
            }
            else if (num == 2)
            {
                person1.Sort((x, y) => string.Compare(x.City, y.City));
                DisplayList();
            }
            else if (num == 3)
            {
                person1.Sort((x, y) => string.Compare(x.Zip, y.Zip));
                DisplayList();
            }
        }
        //Display For State ,Zip,City list
        public void DisplayList()
        {
            foreach (var data in person1)
            {
                Console.WriteLine("Name " + data.FirstName + " " + data.LastName);
            }

        }
    }
}