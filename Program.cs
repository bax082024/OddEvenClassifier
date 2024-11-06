using System;

class Program 
{
  static void Main(string[] args)
  {
    // Test numbers
    var testNumbers = new int[] { 1, 2, 3, 13, 21, 15, 43, 34, 12 };
    
    Console.WriteLine("Predictions:");
    foreach (var number in testNumbers)
    {
      // Check if the number is even
      bool isEven = IsEven(number);
      Console.WriteLine($"Number: {number}, Prediction: {(isEven ? "Even" : "Odd")}");
    }
  }

  static bool IsEven(int number)
  {
    // A number is even if it can be divided by 2
    return number % 2 == 0;
  }
}
