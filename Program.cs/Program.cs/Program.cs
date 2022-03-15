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
                size = Convert.ToInt32(Console.ReadLine()); // user input indicate array size
                int[] arr = new int[size];
                int[] array = Populate(arr);
                int sum = GetSum(array);
                int product = GetProduct(arr, sum);
                GetQuotient(product);
                Console.WriteLine("your array size is: \n" + arr.Length);
                Console.WriteLine("The numbers in the array are:");
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
                Console.WriteLine("\nthe sum of the array is: \n" + GetSum(arr));
            }
            catch (FormatException ex)
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
                arr[i] = Convert.ToInt32(Console.ReadLine()); // fill array with user inputs
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
             if (sum < 20)
            {
                throw new Exception($"Value of ${sum} is too low");
            }
            return sum;
        }
        static int GetProduct(int []arr,int sum)
        {
            Console.Write("Please select a random number between 1 and 6: \n");
            int random = Int32.Parse(Console.ReadLine()); // user selected index 
            try
            {
                if (random < 1 || random > arr.Length)
                {
                    throw new IndexOutOfRange();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" index outside the range of a collection has been referenced." + e);
                }
                int product= sum * arr[random]; 
            Console.WriteLine($"{sum}*{arr[random]} = {product}");
            return product; 
        }
        static decimal GetQuotient(int product)
        {
            Console.Write("Please enter a number to divide your product "+product +"  by: \n");
           // try
           // {
                int divide = Int32.Parse(Console.ReadLine());
           // }
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine("Cannot divide on Zero!");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Something went wrong! " + e);
            //}
            decimal quotient = Decimal.Divide(product, divide);
                Console.WriteLine($"{product}/{divide} = {quotient}");
            return quotient;
        }
        static void Main(string[] args)
        {
            try {
            StartSequence();
            } catch (Exception e){
                            Console.WriteLine("Something wrong happened " + e);

            }
               finally
            {
                Console.WriteLine("Program is complete.");
            }
        }
    }

    [Serializable]
    internal class IndexOutOfRange : Exception
    {
        public IndexOutOfRange()
        {
        }

        public IndexOutOfRange(string message) : base(message)
        {
        }

        public IndexOutOfRange(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IndexOutOfRange(SerializationInfo info, StreamingContext context) : base(info, context)
        {
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
