using System.Collections.Generic;
using System.Linq;
using System;

// Define a bank
public class Bank
{
    public string Symbol { get; set; }
    public string Name { get; set; }
}

// Define a customer
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}

public class GroupedMillionaires
{
    public string Bank { get; set; }
    public IEnumerable<string> Millionaires { get; set; }
}

namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO 1. Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            foreach (string fruit in Ex1(fruits))
            {
                Console.WriteLine(fruit);
            }

            //TODO  2. Which of the following numbers are multiples of 4 or 6
            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            
            foreach (int num in Ex2(mixedNumbers))
            {
                Console.WriteLine(num);
            }

            //TODO 3. Order the names by abc
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            foreach (string name in Ex3(names))
            {
                Console.WriteLine(name);
            }

            //TODO 4. Output how many numbers are in this list
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            Console.WriteLine(Ex4(numbers));


            //TODO 5. How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            Console.WriteLine(Ex5(purchases));

            //TODO 6. What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };

            Console.WriteLine(Ex6(prices));

            //TODO 7. Store each number in a List until a perfect square is detected.
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };

            foreach (int num in Ex7(wheresSquaredo))
            {
                Console.WriteLine(num);
            }


            //TODO 8. Display how many millionaires per bank.
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            foreach (GroupedMillionaires group in Ex8(customers))
            {
                Console.WriteLine(group.Bank + ": " + group.Millionaires.Count());
            }
        }

        public static List<string> Ex1(List<string> fruits)
        {
            return fruits.Where(fruit => fruit.StartsWith("L"));
        }

        public static List<int> Ex2(List<int> mixedNumbers)
        {
            return mixedNumbers.Where(num => num % 4 == 0 || num % 6 == 0);
        }

        public static List<string> Ex3(List<string> names)
        {
            return names.OrderBy(name => name);
        }

        public static int Ex4(List<int> numbers)
        {
            return numbers.Count();
        }

        public static double Ex5(List<double> purchases)
        {
            return purchases.Sum();
        }

        public static double Ex6(List<double> prices)
        {
            return prices.Max();
        }

        public static List<int> Ex7(List<int> wheresSquaredo)
        {
            return wheresSquaredo.TakeWhile(num =>
            {
                double squaredo = Math.Sqrt(num);
                return squaredo != int.Parse(squaredo);
            });
        }

        public static List<GroupedMillionaires> Ex8(List<Customer> customers)
        {
            return customers.GroupBy(customer => customer.Bank).Select(group =>
            {
                var millionaires = group.Where(customer => customer.Balance >= 1000000)
                                        .Select(customer => customer.Name);
                return new GroupedMillionaires() { Bank = group.Key, Millionaires = millionaires };
            });
        }
    }
}