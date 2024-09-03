using System;

namespace Exceptions_Wixson_Hunter
{

    class Program
    {

        static void Main(string[] args)
        {
            // Declare two floats and initialize them with values
            float myFloat = 65.4f;
            float myOtherFloat = 0.0f;
            float result = 0f;

            //Create a Random object to generate random numbers
            Random rand = new Random();
            // Get a random number between 2,30
            int myInt = rand.Next(2, 30);

            // Try block to handle potential exceptions
            try
            {
                // Call the Divide function to perform the the division but it might throw an exception if the divisor is zero
                result = Divide(myFloat, myOtherFloat);
            }
            catch (Exception e)
            {
                // If there's an exception dividing by zero, write an error message
                Console.WriteLine(e.Message);  // Write the exception message
                Console.WriteLine("Please enter a number other than zero.");  // Ask the user for a new input

                // Read the user input and convert it to a float using Convert.ToDouble and casting to float
                myOtherFloat = (float)Convert.ToDouble(Console.ReadLine());

                try  // Inner try block to handle another potential exception
                {
                    // Read the user input again and convert it to a float
                   // myOtherFloat = (float)Convert.ToDouble(Console.ReadLine());
                    // Call the Divide function again with the new value from the user
                    result = Divide(myFloat, myOtherFloat);
                }
                catch (Exception e2)  // Catch block to handle any exception in the inner try block
                {
                    // Write an error message if there's another exception
                    Console.WriteLine(e2.Message);
                }
            }
            finally  // Finally block that always executes regardless of exceptions
            {
                // Write a message indicating the calculation is complete and the result
                Console.WriteLine("Calculation completed with a result of " + result);
            }

            try  // Outer try block to handle the CheckAge function potentially throwing an exception
            {
                // Call the CheckAge function to check the user's age
                CheckAge(myInt);
            }
            catch  // Catch block to handle ArgumentException thrown by CheckAge
            {
                // If there's an exception from CheckAge, tell the user their age and that they are not old enough
                Console.WriteLine($"You are {myInt} you are not old enough!");
            }
        }

        static float Divide(float x, float y)
        {
            if (y == 0)  // Check if the divisor (y) is zero
            {
                // If y is zero, throw a DivideByZeroException
                throw new DivideByZeroException();
            }
            else  // If y is not zero, perform the division and return the result
            {
                return x / y;
            }
        }

        static void CheckAge(int age)
        {
            if (age >= 17)  // Check if the age is greater than or equal to 17
            {
                // If age is 17 or over, tell the user they can play mature games
                Console.WriteLine($"You are {age}, you can play mature games!");
            }
            else  // If age is less than 17, throw an ArgumentException
            {
                throw new ArgumentException();
            }
        }
    }
}