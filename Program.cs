using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ContactsBusinessLayer;

namespace ContactConsoleApp_PresentationLayer
{
    internal class Program
    {



        static void testFindContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if(Contact1 !=null)
            {
                Console.WriteLine(Contact1.FirstName + " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);

            }else
            {
                 Console.WriteLine("Contact"+"["+ID+"]"+"Not Found");
            }




        }

        static void testAddNewContact()
        {

            clsContact Contact1 = new clsContact();
            Contact1.FirstName = "Ammar";
            Contact1.LastName = "salem";
            Contact1.Email = "zxc@gmail.com";
            Contact1.Phone = "12341";
            Contact1.Address = "0229 n41z";
            Contact1.DateOfBirth = new DateTime(2001, 11, 6,10,30,0);
            Contact1.CountryID = 2;
            Contact1.ImagePath = "";
            if (Contact1.Save())
            {

                Console.WriteLine("Contact Addedd Successfully with ID" +"[ "+ Contact1.ID +" ]" );

            }

        }
        
        static void testUpdateContact(int ID)
        {

            clsContact Contact1 = clsContact.Find(ID);
              
            if(Contact1 != null)
            {

                Contact1.FirstName = "mira";
                Contact1.LastName = "malek";
                Contact1.Email = "ammar@gmail.com";
                Contact1.Phone = "079652325";
                Contact1.Address = "arigatoo 0912";
                Contact1.DateOfBirth = new DateTime(2004, 11, 6, 10, 30, 0);
                Contact1.CountryID = 1;
                Contact1.ImagePath = "";


            }


            if(Contact1.Save())
            {

                Console.WriteLine("Contact Updated Successfully");

            }


        }



        static void testDeleteContact(int ID)
        {

            if (clsContact.DeleteContact(ID))
            {
                Console.WriteLine("Contact Deleted Succecfully");
               
            }else
            {
                Console.WriteLine("Contact NOT Found ");
            }



        }


        static void ListAllContacts()
        {
            
            DataTable dataTable = clsContact.GetAllContacts();


            Console.WriteLine("Contacts Data :");


            foreach (DataRow row in dataTable.Rows)
            {

                Console.WriteLine($"{row["ContactID"]} , {row["FirstName"]} , {row["LastName"]}");
                Console.WriteLine();
            }


           


        }




        static bool IsContactExist(int ID)
        {

            return clsContact.IsContactExist(ID);

        }


        static void FindCountryByID(int ID)
        {
            clsCountries Country = clsCountries.Find(ID);
           if (Country != null)
            {
                Console.WriteLine(Country.CountryName);
            }else
            {
                Console.WriteLine("Conutry Not Found ");
            }




           

        }



        static bool CheckCountryNameExistance(string CountryName)
        {
            return clsCountries.CheckCountryNameExistance(CountryName);
        }

        

        static void Main(string[] args)
        {
            for(int i = 0; i < 14; i++) { }

            //testFindContact(1);
           
            // testAddNewContact();

            //testUpdateContact(15);


            //testDeleteContact(15);

            // ListAllContacts();


            //if(IsContactExist(1))
            //{
            //    Console.WriteLine("IS EXIST");
            //}else
            //{
            //    Console.WriteLine("NOT EXIST");
            //}


             // FindCountryByID(1);


            //if(CheckCountryNameExistance("germany"))
            //{
            //    Console.Write("EXISTS");
            //}
            //else
            //{
            //    Console.Write("NOT EXISTS");
            //}

           





        }
    }
}
