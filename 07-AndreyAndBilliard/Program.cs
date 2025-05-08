using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_AndreyAndBilliard
{
    class Program
    {
       class Customer
        {
            public string StudentName { get; set; }
            public Dictionary<string, int> Orders { get; set; } = new Dictionary<string, int>();
            public decimal Bill { get; set; } = 0;
         
        }
      
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> shop = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-');
                string product = input[0];
                decimal price = decimal.Parse(input[1]);

                shop[product] = price;
            }
            Dictionary<string, Customer> customers = new Dictionary<string, Customer>();

            while (true)
            {
                string inputLine = Console.ReadLine();
                if(inputLine == "end of clients")
                {
                    break;
                }
                string[] input = inputLine.Split(new[] { '-', ',' }).ToArray();
                string name = input[0];
                string product = input[1];
                int quantity = int.Parse(input[2]);
                if (!shop.ContainsKey(product))
                {
                    continue;
                }

                if (!customers.ContainsKey(name))
                {
                    customers[name] = new Customer { StudentName = name };
                }
                Customer customer = customers[name];


                if (!customer.Orders.ContainsKey(product))
                {
                    customer.Orders[product] = 0;
                }
                customer.Orders[product] += quantity;
                customer.Bill += quantity * shop[product];
            }
            decimal totalBill = 0;

            foreach (var customer in customers.Values.OrderBy(a =>a.StudentName))
            {
                Console.WriteLine(customer.StudentName);
                foreach (var item in customer.Orders)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine("Bill: {0.F2}", customer.Bill);
                totalBill += customer.Bill;
            }
            Console.WriteLine("Total bill: {0:F2}",totalBill);
        }
    }
           
}

       

   

        


       
  
