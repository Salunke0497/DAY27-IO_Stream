using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day27addressbook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressLogic addressLogic = new AddressLogic();
            bool choice = true;
            while (choice)
            {
                Console.WriteLine("enter\n1.add person\n2.edit person details\n3.remove person\n4.Display\n5.CreateDitionary\n6.DispalayDictionary\n7.ViewLambdaExpression\n8.Sort The Address book list\n9.SortByCity_State_Zip\n10.exit");
                Console.WriteLine("please choose any one");
                int num = Convert.ToInt32(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        addressLogic.addcontact();
                        break;

                    case 2:
                        addressLogic.editcontact();
                        break;

                    case 3:
                        addressLogic.removecontact();
                        break;

                    case 4:
                        addressLogic.Display();
                        break;

                    case 5:
                        addressLogic.CreateDictionary();
                        break;
                    case 6:
                        addressLogic.DisplayDictionary();
                        break;
                    case 7:
                        addressLogic.ViewLambdaExpression();
                        break;
                    case 8:
                        addressLogic.SortAddressBookData();
                        break;
                    case 9:
                        addressLogic.SortByCity_State_Zip();
                        break;
                    case 10:
                        choice = false;
                        break;

                    default:
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}