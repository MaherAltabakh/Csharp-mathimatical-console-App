using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*says whether it’s a leap year or not.
Note: To check if a year is a leap year, divide the year by 4. If it is fully divisible by 4, it is a leap year. For
example, the year 2016 is divisible 4, so it is a leap year, whereas, 2015 is not. However, Century years
like 300, 700, 1900, 2000 need to be divided by 400 to check whether they are leap years or not.
 */

namespace Homework5
{
    internal class Program
    {
        static void Greeting(string Name)
        {
            Console.WriteLine("Welcome friend " + Name + "!");
            Console.WriteLine("Have a nice day!");
        }

        static double Exponentfunction(double Base, double Power)
        {
            double Result = 1;
            for (int i = 0; i < Power; i++)
                Result = Result * Base;
            return Result;
        }

        enum MathOperation { ADD, SUBTRACT, MULTIPLY, DIVIDE, EXIT, NEW };

        static double SumXY(double X, double Y)
        {
            double Result = 0;
            Result = X + Y;
            return Result;
        }
        static double SubXY(double X, double Y)
        {
            double Result = 0;
            Result = X - Y;
            return Result;
        }

        static double MultiXY(double X, double Y)
        {
            double Result = 0;
            Result = X * Y;
            return Result;
        }

        static double DivXY(double X, double Y)
        {
            double Result = 0;
            Result = X / Y;
            return Result;
        }

        static Boolean LeapYear(int Year)
        {
            Boolean YearResult = false;
            if (Year % 4 == 0)
            {
                if (Year % 100 != 0)
                    YearResult = true;
                else
                    if (Year % 400 == 0)
                    YearResult = true;
            }
            return YearResult;
        }

        static void Main(string[] args)
        {
            string Name, Q;
            double Base, Power, X, Y;
            int Year;
            MathOperation option;
            do
            {
                do
                {
                    Console.Write("Please choose the option (number) from the following list: ");
                    Console.Write("1. Greeting.\n");
                    Console.WriteLine("                                                           2. Expo function.");
                    Console.WriteLine("                                                           3. Calculater operation.");
                    Console.WriteLine("                                                           4. Testing Leap year.");
                    Console.WriteLine("                                                           5. Testing range of years to see the Leap years among them.");
                    Console.Write("Or, type (Exit) to end the program: ");
                    Q = Console.ReadLine();
                    Q = Q.ToLower();
                    Console.Write("\n");
                } while (Q != "1" && Q != "2" && Q != "3" && Q != "4" && Q != "5" && Q != "exit");
            
                switch (Q)
                {
                    case "1":
                        {
                            Console.Write("Please input a name: ");
                            Name = Console.ReadLine();
                            Greeting(Name);
                            Console.Write("\n");
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Input Base number: ");
                            Base = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Input the Exponent: ");
                            Power = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("So, the number " + Base + " to the power of " + Power + " = " + Exponentfunction(Base, Power));
                            Console.Write("\n");
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Welcome to Math operations (calculater):");
                            do
                            {
                                Console.Write("Please enter X= ");
                                X = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Please enter Y= ");
                                Y = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Please choose the operation from the following list: [Add, Subtract, Multiply, Divide]: ");
                                option = (MathOperation)Enum.Parse(typeof(MathOperation), Console.ReadLine(), true);
                                Console.WriteLine("You chose: " + option.ToString());
                                do
                                {   switch (option)
                                    {
                                        case MathOperation.ADD:
                                            Console.WriteLine(X + " + " + Y + " = " + SumXY(X, Y));
                                            break;
                                        case MathOperation.SUBTRACT:
                                            {
                                                Console.WriteLine(X + " - " + Y + " = " + SubXY(X, Y));
                                                Console.WriteLine(Y + " - " + X + " = " + SubXY(Y, X));
                                                break;
                                            }
                                        case MathOperation.MULTIPLY:
                                            Console.WriteLine(X + " * " + Y + " = " + MultiXY(X, Y));
                                            break;
                                        case MathOperation.DIVIDE:
                                            {
                                                Console.WriteLine(X + " / " + Y + " = " + DivXY(X, Y));
                                                Console.WriteLine(Y + " / " + X + " = " + DivXY(Y, X));
                                            }
                                            break;
                                    }
                                    Console.Write("Please choose the operation from the following list: [Add, Subtract, Multiply, Divide]. ");
                                    Console.Write("Type (Exit) to end, or (New) for new entery: ");
                                    option = (MathOperation)Enum.Parse(typeof(MathOperation), Console.ReadLine(), true);
                                } while (option == MathOperation.ADD || option==MathOperation.SUBTRACT || option == MathOperation.MULTIPLY || option == MathOperation.DIVIDE);
                            } while (option != MathOperation.EXIT);
                            Console.Write("\n");
                            break;
                        }
                    case "4":
                        {
                            do
                            {
                                Console.Write("Please enter the year you want to check as a leap year. When you finish checking, please enter (0): ");
                                Year = Convert.ToInt32(Console.ReadLine());
                                if (LeapYear(Year))
                                    Console.WriteLine("The year " + Year + " is a Leap Year.");
                                else
                                    Console.WriteLine("The year " + Year + " is NOT a Leap Year.");
                            } while (Year != 0);
                            Console.Write("\n");
                            break;
                        }
                    case "5":
                        {
                            int BeginYear = 0, EndYear = 0, ctr = 0, TestedYear = 0;

                            Console.Write("Please enter the upper limit for the rage of years you want to check the leap years in it: ");
                            BeginYear = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Please enter the end limit for the rage of years you want to check the leap years in it: ");
                            EndYear = Convert.ToInt32(Console.ReadLine());

                            if (EndYear < BeginYear)
                            {
                                do
                                {
                                    Console.Write("Please enter the end limit for the rage of years Greater than the upper limit: ");
                                    EndYear = Convert.ToInt32(Console.ReadLine());
                                } while (EndYear < BeginYear);
                            }

                            int[] result = new int[EndYear - BeginYear];

                            TestedYear = BeginYear;

                            for (int i = 0; i <= (EndYear - BeginYear); i++)
                            {
                                if (LeapYear(TestedYear))
                                {
                                    result[ctr] = TestedYear;
                                    ctr++;
                                }
                                TestedYear++;
                            }

                            Console.Write("\nThe list for the leap years between " + BeginYear + " and " + EndYear + " is: \n");
                            for (int i = 1; i <= ctr; i++)
                            {
                                if (i != ctr)
                                    Console.Write(result[i - 1] + " , ");
                                if (i == ctr)
                                    Console.Write(result[i - 1]);
                                if (i % 10 == 0)
                                    Console.Write("\n");
                            }
                            Console.Write("\n");
                            Console.Write("\n");
                            break;
                        }
                    case "exit":
                        break;
                }
                if (Q != "exit")
                    do
                    {
                        Console.Write("If you want to choose from the main list again, please type (New). Otherwise type (Exit): ");
                        Q = Console.ReadLine();
                        Q = Q.ToLower();
                        Console.Write("\n");
                    }
                    while (Q != "exit" && Q != "new");
        } while (Q != "exit") ;

                Console.Write("Thanks");
                Console.ReadLine();
        }
    }
}