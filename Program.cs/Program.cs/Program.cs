using System;
using System.Runtime.Serialization;

namespace Program.cs
{
    internal class Program
    {
        static void StartSequence()
        {
            try
            {
                int size;
                Console.Write("Please enter a number greater than zero:\n");
                size = Convert.ToInt32(Console.ReadLine()); // user input indicate array size, Convert user input to an integer 
                int[] arr = new int[size];
                int[] array = Populate(arr);
                int sum = GetSum(array);
                int product = GetProduct(arr, sum);
                decimal quotient = GetQuotient(product);
                Console.WriteLine("your array size is: \n" + arr.Length);
                Console.WriteLine("The numbers in the array are:");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine("\nthe sum of the array is: \n" + GetSum(arr));
                Console.WriteLine($"{sum} * {(product / sum)} = {product}");
                Console.WriteLine($"{product} / {product / quotient} = {quotient}");
            }
            catch (FormatException ex) // if user enter non-number
            {
                Console.Write("Not a valid number. Please try again.", ex);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Error caught: {0}", e);
            }
         
        }
        static int[] Populate(int[] arr)
        {
            int i;
            for (i = 0; i < arr.Length; i++)
            {
                Console.Write("please enter number: {0} ", i + 1 + " out of "+ arr.Length + "\n");
                arr[i] = Convert.ToInt32(Console.ReadLine()); // fill array with user inputs, Convert user input to an integer, and add the number to the array
            }

            return arr;
        }
        static int GetSum(int [] arr)
        {
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum+= arr[i];
            }
            //if the sum is less than 20, throw an exception
            if (sum < 20)
            {
                throw new Exception($"Value of ${sum} is too low");
            }
            return sum;
        }
        static int GetProduct(int []arr,int sum)
        {
            Console.Write("Please select a random number between 1 and" +  arr.Length +": \n");
            int random = Int32.Parse(Console.ReadLine()); // user selected index 
           
                if (random < 1 || random > arr.Length)
                {
                    throw new IndexOutOfRangeException("index outside the range of a collection has been referenced.");
                }

                int product= sum * arr[random-1]; 
            return product; 
        }
        static decimal GetQuotient(int product)
        {
            Console.Write("Please enter a number to divide your product "+product +"  by: \n");
            decimal quotient;
            decimal divide = Convert.ToDecimal(Console.ReadLine());
            try
            {
                 quotient = Decimal.Divide(product, divide);

            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Cannot divide on Zero!");
                return 0;
            }

            return quotient;
        }
        static void Main(string[] args)
        {
            try {
            StartSequence();
            } catch {
                Console.WriteLine("Something wrong happened ");

            }
               finally
            {
                Console.WriteLine("Program is complete.");
            }
        }
    }
}
// additional custom exception code
public class EmployeeListNotFoundException : Exception
{
    public EmployeeListNotFoundException()
    {
    }

    public EmployeeListNotFoundException(string message)
        : base(message)
    {
    }

    public EmployeeListNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
