﻿
//w3resource solution impelmentations of:
//Recursion #14 -- get the reverse of a string using recursion  *
//String #2 -- find the length of a string without using library function   *
//LINQ #9 -- create a list of numbers and display the numbers greater than 80 as output *
//Also messed around with the .foreach() extension and associated Action<> creation *
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int length = 0;
            List<int> numbers = new List<int> { 10, 23, 42, 17, 39, 100, 75, 84, 66, 175, 31, 200 };
            Action<int> action = new Action<int>((n => Console.WriteLine(n * n)));

            var over80 = numbers.FindAll(n => n > 80 ? true : false);
            numbers.ForEach(action);

            foreach(int i in numbers)
            {
                Console.Write($"{i}, ");
            }

            foreach(int i in over80)
            {
                Console.Write($"{i}, ");
            }


            while (true)
            {
                Console.Write("\nPlease enter a string: ");
                input = Console.ReadLine();
                if (input.Length > 0)
                    break;
                else
                    Console.WriteLine("That is not a valid entry!");
            }

            input = Reverse(input);

            Console.WriteLine($"The reverse of the string that you entered is: {input}");

            foreach(char c in input)
            {
                length++;
            }

            Console.WriteLine($"The length of the string that you entered is: {length}");

            Console.ReadKey();
        }

        public static string Reverse(string input)
        {
            if (input.Length > 0)
                return input[input.Length - 1] + Reverse(input.Substring(0, input.Length - 1));
            else
                return input;
        }
    }
}


/*
//Array #4 -- copy the elements one array into another array    *
//String #1 -- input a string and print it  *
//String #2 -- find the length of a string without using library function   *
//Function #8 -- create a function to display the n number Fibonacci sequence. *
//Recursion #14 --  get the reverse of a string using recursion *
//LINQ #9 -- create a list of numbers and display the numbers greater than 80 as output *
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int fibCount = 0;
            int[] fibArray;
            int[] fibArray2;
            int fibThreshold = 80;

            while (input.Length < 1)
            {
                Console.Write("Please enter a string: ");
                input = Console.ReadLine();
            }

            Console.WriteLine($"The string that you enterd contains - {Count(input)} - characters.");            
            Console.WriteLine($"\nThe reverse of the string that you entered is: \n\n");
            Reverse(input);



            while (true)
            {
                try
                {
                    Console.Write("\n\n\nPlease enter the number of Fibonacci numbers that you would like to see: ");
                    fibCount = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("That was not a valid entry!");
                }
            }

            fibArray = new int[fibCount];
            Fibonacci(fibCount, ref fibArray);

            Console.WriteLine($"The numbers stored in fibArray are: {string.Join(", ", fibArray)}");
            fibArray2 = fibArray;   //copies number set from fib1 to fib2
            Console.WriteLine("FibArray has been copied to fibArray2.");
            fibArray = null; //purges fib2 to demonstrate data transfer
            Console.WriteLine("FibArray has been purged.");

            Console.WriteLine($"The numbers stored in fibArray2 are: {string.Join(", ", fibArray2)}");
            try
            {
                Console.WriteLine($"The numbers stored in fibArray are: {string.Join(", ", fibArray)}");
            }
            catch
            {
                Console.WriteLine("fibArray could not be displayed due to null exception.");
            }


            var fibsOver80 = from fibs in fibArray2 where fibs > fibThreshold select fibs;

            Console.WriteLine($"The fibonacci numbers greater than {fibThreshold} are: ");
            foreach(var v in fibsOver80)
            {
                Console.WriteLine(v);
            }

            Console.ReadKey();
        }

        public static int Count(string input)
        {
            int count = 0;
            while (input != null && input != input.Substring(0, 1))
            {
                input = input.Remove(0, 1);
                ++count;
            }
            return ++count;
        }

        public static void Reverse(string input)
        {
            if (Count(input) > 1)
            {
                Reverse(input.Remove(0, 1));
                Console.Write($"{input.Substring(0, 1)}");
            }
            else
                Console.Write(input);
        }

        public static void Fibonacci(int count, ref int[] fibArray, int fib1 = 0, int fib2 = 1 )
        {
            if(count > 0)
            {
                Console.WriteLine(fib1);
                fibArray[fibArray.Length - count] = fib1;
                Fibonacci(--count, ref fibArray, fib2, fib1 + fib2 );
            }
        }
    }
}



/*
//File Handling #5 -- create a file with text and read the file
//Function #7 -- create a function to calculate the result of raising an integer number to another
//Struct #8 --  demonstrates struct initialization without using the new operator
//Recursion #13 -- convert a decimal number to binary using recursion

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Threading;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Squared number;
            int binaryNum = 0;
            string fileName = @"test text.txt";

            Console.Write("Please enter a number: ");
            number.root = Convert.ToInt32(Console.ReadLine());
            number.square = Square(number.root);

            using (StreamWriter sw = new StreamWriter(File.Open(fileName, FileMode.Append, FileAccess.Write,FileShare.ReadWrite)))
            {
                sw.WriteLine($"The square of the number {number.root} is: {number.square}");
                sw.WriteLine($"The number {number.root} in binary is: {ToBinary(number.root, ref binaryNum)}");
            }

            Console.WriteLine(Directory.GetCurrentDirectory());

            using (StreamReader sr = File.OpenText(fileName))
            {
                Console.WriteLine(sr.ReadLine());
                Console.WriteLine(sr.ReadLine());
            }            
           
            Console.ReadKey();
        }

        public struct Squared
        {
            public int root;
            public int square;

            public Squared (int num)
            {
                root = num;
                square = Square(num);
            }
        }

        public static int Square (int num)
        {
            return num * num;
        }

        public static int ToBinary (int num, ref int bin)
        {
            if (num > 0)
                bin += num % 2 + 10 * ToBinary(num / 2, ref bin);
            return bin;
        }
    }
}



/*
//Function #6 -- create a function to swap the values of two integer numbers
//File Handling #4 -- create a file and add some text
//Struct #7 -- demonstrates struct initialization using both default and parameterized constructors.
//LINQ #8 --  find the string which starts and ends with a specific character

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Word> wordList = new List<Word>();
            int wordCount;

            wordCount = GetCount();

            FillList(wordList, wordCount);


            string filePath = @"C:\Users\rloyd\source\repos\w3Resource Exercises\w3Resource Exercises\wordList.txt";
            Stream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.Read);
            StreamWriter sw = new StreamWriter(fs);
            
            foreach (Word w in wordList)
            {
                sw.WriteLine(w.ToString());
            }

            sw.Close();
            fs.Close();

            char starts = 'a';
            char ends = 'e';

            var thisWord = from word in wordList where word.startsWith == starts && word.endsWith == ends select word;
                        
            foreach(var v in thisWord)
            {
                Console.WriteLine(v.ToString());
            }

            Console.Write("Please enter a number: ");
            int numInp1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter a number: ");
            int numInp2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"First num: {numInp1}  second num: {numInp2}");

            Swap(ref numInp1, ref numInp2);

            Console.WriteLine($"First num: {numInp1}  second num: {numInp2}");

            Console.ReadKey();
        }

        public struct Word
        {
            public string theWord;
            public char startsWith;
            public char endsWith;

            public Word(char start = '-', char end = '-')
            {
                this.startsWith = start;
                this.endsWith = end;
                this.theWord = "--";
            }

            public Word  (string word)
            {
                this.startsWith = word[0];
                this.endsWith = word[word.Length - 1];
                this.theWord = word;
            }

            public override string ToString()
            {
                return ($"\"{this.theWord}\" begins with \'{this.startsWith}\' and ends with \'{this.endsWith}\'");
            }
        }

        public static int GetCount()
        {
            int Count = 0;
            while (true)
            {
                try
                {
                    Console.Write("Please enter the number of words (between 1 and 10) that you would like to log: ");
                    Count = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That's not a valid entry!");
                }
                if (Count < 1 || Count > 10)
                    Console.WriteLine("The number must be between 1 and 10!");
                else
                    return Count;
            }
        }

        public static void FillList(List<Word> list, int count)
        {
            for (var i = count; i > 0; i--)
            {
                try
                {
                    Console.Write($"Please enter word number {i}: ");
                    list.Add(new Word (Console.ReadLine()));
                }
                catch
                {
                    Console.WriteLine("That's not a valid entry!");
                    ++i;
                }
            }
        }

        public static void Swap(ref int num1, ref int num2)
        {
            Console.WriteLine($"Before swap the first number is: {num1}  and the second number is: {num2}");

            num1 = num1 * num2;
            num2 = num1 / num2;
            num1 = num1 / num2;

            Console.WriteLine($"After swap the first number is: {num1}  and the second number is: {num2}");
        }
    }
}


/*
//Function #5 --  calculate the sum of elements in an array
//Recursion #12 -- find the LCM and GCD of two numbers using recursion.
//LINQ #7 -- display numbers, multiplication of number with frequency and frequency of a number of giving array.
using System;
using System.Collections;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1;
            int[] nums2;
            int sum1;
            int sum2;

            Console.Write("Please enter the number of integers to store in each array: ");
            nums1 = new int[Convert.ToInt32(Console.ReadLine())];
            nums2 = new int[nums1.Length];
            Console.Clear();

            GetNums(nums1, "1st");
            Console.Clear();
            GetNums(nums2, "2nd");
            Console.Clear();

            sum1 = Sum(nums1, "1st");
            sum2 = Sum(nums2, "2nd");
                        
            LCM(sum1, sum2, GCD(sum1, sum2));

            Frequency(nums1, "1st");
            Frequency(nums2, "2nd");

            Console.ReadKey();
        }

        public static void GetNums(int[] nums, string place)
        {
            for(var i = 0; i < nums.Length; i++)
            {
                Console.WriteLine($"Okay, let's populate the {place} array!");
                try
                {
                    Console.Write($"Please enter the value for element {i} of the array: ");
                    nums[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That's not a valid entry!");
                    i--;
                }
            }
        }

        public static int Sum(int[] nums, string place)
        {
            int sum = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            Console.WriteLine($"The sum of the numbers in the {place} array is: {sum}");
            return sum;
        }

        public static int GCD(int num1, int num2, int numGCD = 1, int factor = 1)
        {
            if (num1 % factor == 0 && num2 % factor == 0)
                numGCD = factor;
            if (factor < num1 && factor < num2)
                return GCD(num1, num2, numGCD, factor + 1);
            else
                Console.WriteLine($"The GCD of {num1} and {num2} is: {numGCD}");
            return numGCD;
        }

        public static int[] Multiples(int num)
        {
            ArrayList multiples = new ArrayList();
            for(var i = 1; i <= num/2; i++)
            {
                if (num % i == 0)
                    multiples.Add(i);
            }
            multiples.Add(num);
            
            Console.WriteLine($"The multiples of {num} are: " + string.Join(", ", multiples.ToArray()));
            return (int[])multiples.ToArray(typeof(int));
        }

        public static void LCM(int num1, int num2, int GCD)
        {
            Multiples(num1);
            Multiples(num2);

            Console.WriteLine($"The LCM of {num1} and {num2} is: {(num1*num2)/GCD}");
        }

        public static void Frequency(int[] nums, string place)
        {
            var numSet = from n in nums group n by n into y select y;

            Console.WriteLine($"{place} Array:");
            Console.WriteLine($"Number\t   |\tFrequency\t|\tNumber*Frequency");
            foreach(var v in numSet)
            {
                Console.WriteLine($"   {v.Key}\t\t   {v.Count()}\t\t\t\t{v.Sum()}");
            }
        }
    }
}


/*
//Function #4 -- create a function to input a string and count number of spaces are in the string
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a string: ");
            string input = Console.ReadLine();

            Console.WriteLine($"The string that you entered contains {SpaceCount(input)} spaces.");

            Console.ReadKey();
        }

        public static int SpaceCount(string str)
        {
            int count = 0;
            for(var i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                    ++count;
            }
            return count;
        }
    }
}


/*
//Function #3 -- create a function for the sum of two numbers
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 0, num2 = 0;

            num1 = GetNum(num1);
            num2 = GetNum(num2);

            Console.WriteLine(Add(ref num1, ref num2));

            Console.ReadKey();
        }

        public static int GetNum(int num)
        {
            while(num == 0)
            {
                try
                {
                    Console.Write("Please enter a number: ");
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That's not a valid entry!");
                }
            }
            return num;
        }

        public static T Add<T>(ref T param1, ref T param2)
        {
            var x = Expression.Parameter(typeof(T), "param1");
            var y = Expression.Parameter(typeof(T), "param2");

            BinaryExpression expression = Expression.Add(x, y);

            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(expression, x, y).Compile();

            return add(param1, param2);
        }

    }
}



/*
//Recursion #11 --  generate all possible permutations of an array using recursion.
//LINQ #6 -- display the name of the days of a week.
//Date Time #11 --  add a number of whole and fractional values to a date and time.
//Function #2 -- create a user define function with parameters.
using System;
using System.Collections;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] DaysOfWeek = { "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "staurday" };
            ArrayList arrayList = new ArrayList();
            int[] nums = { 1, 2, 3, 4 };
            TimeSpan timeSpan = new TimeSpan(864000000000);
            DateTime[] Dates = new DateTime[7];

            for(var i = 0; i < Dates.Length; i++)
            {
                Dates[i] = DateTime.Now + MultiplyTime(i, timeSpan);
            }

            var weekdays = from days in Dates select days.DayOfWeek;

            string[] stringDays = new string[Dates.Length];
            int counts = 0;

            foreach (var v in weekdays)
            {
                Console.WriteLine(v);
                stringDays[counts] = v.ToString();
                ++counts; 
            }

            Permute(ref nums, nums.Length-1, 6, 1, arrayList);

            Console.WriteLine();

            Console.WriteLine(arrayList.ToArray().Count());

            var perms = arrayList.ToArray().Distinct(); //checks for unique permutations
            int uniques = 0; //unique counter
            foreach(var v in perms)
            {
                Console.WriteLine(v); ;
                ++uniques;
            }
            Console.WriteLine(perms.Count()); //result indicates that algorithm does not work for sets larger than 3.

            Console.WriteLine($"\nTotal unique permutations: {uniques}");

            Console.ReadKey();
        }

        public static TimeSpan MultiplyTime (int multiplier, TimeSpan timeSpan)
        {
            long product = 0;
            for(var i = 0; i < multiplier; i++)
            {
                product += Convert.ToInt64(timeSpan.Ticks); //increments timespan by timespan as int64
            }

            TimeSpan timeSpanProduct = new TimeSpan(product);
          
            return timeSpanProduct;
        }

        public static void Permute<T>(ref T[] array, int index, int permutations, int count, ArrayList arrayList)
        {
            T temp = array[index];
            if (index + 1 == array.Length) //swaps last with first if swap position is at end of array
            {
                array[index] = array[0];
                array[0] = temp;
            }
            else //swaps position with next, resulting in moving first backward through array
            {
                array[index] = array[index + 1];
                array[index + 1] = temp;
            }
            Console.WriteLine();
            Console.Write(count + " - ");
            foreach (var v in array)
            {
                Console.Write(v + ", ");
            }
            arrayList.Add(string.Join(", ",array));
            count++; //for confirming the number of permutations
            if (index == 0) //resets index to end to continue permutations
            {
                --permutations;
                index = array.Length;
            }
            if (permutations > 0 && index > -1)
                Permute(ref array, index-1, permutations, count, arrayList);
        }
    }
}


/*
//Function #1 -- create a user define function.
//Structure #6 --  declares a struct with a property, a method, and a private field.
//File Handling #3 --  create a blank file in the disk if the same file already exists
//File Handling #2 -- remove a file from the disk
using System;
using System.IO;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            User[] users = new User[10];
            User user = new User();

            Console.Write("Please enter your name: ");

            user.Name = Console.ReadLine();
            user.Hashthis(user.Name);

            Greet(user.Name);
            user.GetBirthday();

            users[user.Hashthis(user.Name)] = user;

            string filepath = @"C:\Users\rloyd\source\repos\w3Resource Exercises\w3Resource Exercises\";
            try
            {
                Stream fs = new FileStream(filepath + "userList.txt", FileMode.CreateNew, FileAccess.Write, FileShare.None);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(user.ToString());
                sw.Close();
                fs.Close();
            }
            catch
            {
                Stream fs = new FileStream(filepath + "blank.txt", FileMode.Create, FileAccess.Write, FileShare.None);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(user.ToString());
                sw.Close();
                fs.Close();
                File.Delete(filepath + "userList.txt");
            }



            Console.WriteLine(user.ToString());

            Console.ReadKey();
        }

        public struct User
        {
            public string Name;
            public DateTime Birthday;
            public int Age;
            private int ID;
            
            public int Hashthis(string name)
            {
                int sum = 0;
                foreach (char c in name)
                {
                    sum += Convert.ToInt32(c);
                }
                ID = (sum) % 9;
                return ID;
            }

            public void GetBirthday()
            {
                int year;
                int month;
                int day;
                Console.WriteLine($"Okay, {Name}, let's get your birthday in here!");

                Console.Write("Please enter the year of your birth ^^: ");
                year = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please enter the month of your birth ^^: ");
                month = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please enter the day of your birth ^^: ");
                day = Convert.ToInt32(Console.ReadLine());

                this.Birthday = new DateTime(year, month, day);

                TimeSpan age = DateTime.Now - Birthday;

                Age = Convert.ToInt32((age.TotalDays-age.TotalDays%365)/365);
            }

            public override string ToString()
            {
                return ($"Username: {Name} \nBirthday: {Birthday.ToShortDateString()} \nAge: {Age} \nID: {ID}");
            }
        }

        static void Greet(string name)
        {
            Console.WriteLine($"Hello {name}!");
        }        
    }
}


/*
//Date Time #10 -- determine the day of the week 40 days after the current date.
using System;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            DateTime today = DateTime.Now;
            TimeSpan daysFromToday = new TimeSpan(40, 0, 0, 0);

            DateTime later = today.Add(daysFromToday);

            Console.WriteLine("Today is: {0:dddd}", today);
            Console.WriteLine("40 days from today is: {0:dddd}", later);

            Console.ReadKey();
        }
    }
}


/*
//Date Time #9 -- calculate what day of the week is 40 days from this moment.
using System;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            int days = 40;
            Console.WriteLine($"Today's date is: {DateTime.Now.ToLongDateString()}");
            Console.WriteLine($"{days} days from now it will be: {DateTime.Now.AddDays(days).DayOfWeek}");

            DateTime now = DateTime.Now;
            TimeSpan daysFromNow = new TimeSpan(40, 0, 0, 0);
            DateTime then = now.Add(daysFromNow);

            Console.WriteLine($"{daysFromNow.Days} days from today it will be: {then.DayOfWeek}");
            Console.WriteLine("{0:dd} days from today it will be: {1:dddd}", daysFromNow, then);


            Console.ReadKey();
        }
    }
}


/*
//Date Time #8 -- retrieve the current date.
using System;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine($"General format {DateTime.Now.ToString()}");
            Console.WriteLine("Display the date in a variety of formats:");
            Console.WriteLine($"\n{DateTime.Now.ToShortDateString()}");
            Console.WriteLine($"{DateTime.Now.ToLongDateString()}");
            Console.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");

            Console.ReadKey();
        }
    }
}


/*
//Date Time #7 -- get the time of day from a given array of date time values
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime[] dateTimes =
            {DateTime.Now,
            new DateTime(2016, 08, 16, 09, 28, 0),
            new DateTime(2011, 05, 28, 10, 35, 0),
            new DateTime(1979, 12, 25, 14, 30, 0)
            };

            foreach(DateTime d in dateTimes)
            {
                Console.WriteLine($"Day: {d.ToShortDateString()} Time: {d.TimeOfDay}");
                Console.WriteLine($"Day: {d.ToShortDateString()} Time: {d.ToShortTimeString()}");
            }

            Console.ReadKey();
        }
    }
}


/*
//Date Time #6 -- display the number of ticks that have elapsed since the beginning of the twenty-first century 
//and to instantiate a TimeSpan object using the Ticks property.
using System;
using System.Globalization;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            DateTime now = DateTime.Now;

            DateTime then = new DateTime(2001, 01, 01, 00, 00, 00);

            TimeSpan timeSpan = new TimeSpan();
            timeSpan = now - then;
                        
            Console.WriteLine(now.Ticks);
            Console.WriteLine(then.Ticks);

            Console.WriteLine(timeSpan.Ticks +"\n");

            String[] cultures = { "en-JM", "en-NZ", "fr-BE", "de-CH", "nl-NL" };

            foreach(string s in cultures)
            {
                var culture = new CultureInfo(s);
                Console.WriteLine($"{culture.EnglishName}");
                Console.WriteLine($"Local date and time: {now.ToString(culture)}");
                Console.WriteLine($"UTC date and time: {now.ToUniversalTime()}\n");
            }

            Console.WriteLine(timeSpan.ToString());
            Console.WriteLine($"{timeSpan.Days} days {timeSpan.Hours} hours {timeSpan.Minutes} minutes and {timeSpan.Seconds} seconds");

            timeSpan -= (now - then);

            Console.WriteLine(timeSpan.ToString());

            Console.ReadKey();
        }
    }
}


/*
//Structure #5 -- show what happen when a struct and a class instance is passed to a method.
//Demonstrates that structs are passed as values and changes made to them within a function are made only to 
//the values of the instance that were passed to the function, not to the original struct unless the method is
//of the same return type as the struct that was passed into it and then only if the method is assigned to the
//original struct in the program body.
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            RectangleS rectangleS = new RectangleS
            {
                Length = 10,
                Width = 15
            };

            RectangleC rectangleC = new RectangleC(10, 15);

            Resize(rectangleS, 20, 25);

            Resize(rectangleC, 20, 25);

            Console.WriteLine(rectangleS.ToString());
            Console.WriteLine(rectangleC.ToString());

            rectangleS = ResizeS(rectangleS, 20, 25);

            Console.WriteLine(rectangleS.ToString());

            Console.ReadKey();
        }

        public struct RectangleS
        {
            public int Length;
            public int Width;

            public override string ToString()
            {
                return ($"Struct Rectangle:     Length: {Length}    Width:{Width}");
            }
        }

        public class RectangleC
        {
            public int Length;
            public int Width;

            public RectangleC()
            {
                this.Length = 1;
                this.Width = 1;
            }

            public RectangleC(int width, int length)
            {
                this.Length = length;
                this.Width = width;
            }

            public override string ToString()
            {
                return ($"Class Rectangle:      Length:{Length}  Width:{Width}");
            }
        }

        public static void Resize(RectangleC rectangle, int length, int width)
        {
            rectangle.Length = length;
            rectangle.Width = width;
        }

        public static void Resize(RectangleS rectangle, int length, int width)
        {
            rectangle.Length = length;
            rectangle.Width = width;
        }

        public static RectangleS ResizeS(RectangleS rectangle, int length, int width)
        {
            rectangle.Length = length;
            rectangle.Width = width;
            return rectangle;
        }
    }
}


/*
//Structure #4 -- create a structure and Assign the Value and call it.
//supposed to create a structure and a class, initilize their values, copy them each to new struct and new class
//then change the values of the original and print the values from the copies to witness the differences.

using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            NumStruct numStruct = new NumStruct();
            numStruct.X = 75;
            numStruct.Y = 95;
            NumStruct numStruct2 = numStruct;
            numStruct.X = 750;
            numStruct.Y = 950;
            Console.WriteLine($"Assigned in Structure:  X:{numStruct2.X}    Y:{numStruct2.Y}");

            NumClass numClass = new NumClass();
            numClass.X = 750;
            numClass.Y = 950;
            NumClass numClass2 = numClass;
            numClass.X = 7500;
            numClass.Y = 9500;
            Console.WriteLine($"Assigned in Class:  X:{numClass2.X} Y:{numClass2.Y}");

            Console.ReadKey();
        }
        public struct NumStruct
        {
            public int X;
            public int Y;
        }
        public class NumClass
        {
            public int X;
            public int Y;
        }
    }
}


/*
//Structure #3 -- create a nested struct to store two data for an employee in an array.
using System;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            Employee[] Employees;
            int numberToAdd = 0;

            Console.Write($"Hello, how many employees would you like to add? ");

            while(numberToAdd == 0)
            {
                try
                {
                    numberToAdd = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("The number you have entered is invalid. " +
                        "Please enter the number of employees you would like to add: ");
                }
            }
            
            Employees = new Employee[numberToAdd];

            for (var i = 0; i < Employees.Length; i++)
            {
                Employees[i] = new Employee();
                Console.Write($"Please enter the name of Employee #{i + 1}: ");
                Employees[i].Name = Console.ReadLine();

                Employees[i].Birthdate = new DoB();

                Employees[i].Birthdate.Read(Employees[i].Name, ref Employees[i].Birthdate.year, "year");
                Employees[i].Birthdate.Read(Employees[i].Name, ref Employees[i].Birthdate.month, "month");
                Employees[i].Birthdate.Read(Employees[i].Name, ref Employees[i].Birthdate.day, "day");              
                
            }

            foreach(Employee e in Employees)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();
        }

        

        public struct Employee
        {
            public string Name;
            public DoB Birthdate;

            public override string ToString()
            {
                return ($"Employee: {this.Name} " +
                    $"\nDay of Birth: {this.Birthdate.day} " +
                    $"\nMonth of Birth: {this.Birthdate.month}" +
                    $"\nYear of Birth: {this.Birthdate.year}");
            }
        }

        public struct DoB
        {
            public int day;
            public int month;
            public int year;

            public void Read(string name, ref int param, string unit)
            {
                while (param == 0)
                {
                    Console.Write($"Please enter the {unit} of birth of {name} as a two digit number: ");
                    try
                    {
                        param = Convert.ToInt32(Console.ReadLine());
                        if ((unit == "month" && (param > 12 || param < 1)) || (unit == "day" && (param > 31 || param < 1)))
                        {
                            param = 0;
                            Console.WriteLine("Your entry was invalid.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Your entry was invalid.");
                    }
                }
            }
        }
    }
}



/*
//Structure #2 --  declare a simple structure and use of static fields inside a struct
using System;
using System.Collections.Generic;

namespace cFun
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine($"The sum of {xAndy.x} and {xAndy.y} is {xAndy.Sum()}.");

            Console.ReadKey();
        }

        public struct xAndy
        {
            public static int x = 15;
            public static int y = 25;

            static xAndy() { }

            public static int Sum()
            {
                return x + y;
            }

        }      
    }
}


/*
//DateTime #5 -- get a DateTime value that represents the current date and time on the local computer.
//this tutorial actually focuses on Globalization & CultureInfo
//implemented the WriteText function from my earlier IO exercise to dump all the language info to a text file.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            DateTime dateLocal = DateTime.Now;
            DateTime dateUtc = DateTime.UtcNow;

            var cultureList = CultureInfo.GetCultures(CultureTypes.AllCultures);

            Stream fs = new FileStream(@"C:\Users\rloyd\source\repos\w3Resource Exercises\culture_list.txt", FileMode.Create, FileAccess.Write, FileShare.None);
            StreamWriter sw = new StreamWriter(fs);

            foreach(var v in cultureList)
            {
                Console.WriteLine(v);
                var culture = new CultureInfo(v.ToString());

                WriteText("", sw);
                WriteText($"{culture.NativeName}", sw);
                WriteText($"{culture.EnglishName}", sw);
                WriteText($"Local date and time: {dateLocal.ToString(culture)}", sw);
                WriteText($"UTC date and time: {dateUtc.ToString(culture)}", sw);
            }

            sw.Close();
            fs.Close();

            Console.ReadKey();
        }

        static void WriteText(string input, StreamWriter sw)
        {
            Console.WriteLine(input);
            sw.WriteLine(input);
        }
    }
}


/*
//DateTime #4 -- display the number of days of the year between two specified years. Second run with additional features.
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime { };
            DateTime date2 = new DateTime { };

            date1 = GetYear(date1, "first");

            date2 = GetYear(date2, "second");

            Console.WriteLine($"There are {CalcDuration(date1, date2)} days between dates within those two years.");

            Console.ReadKey();
        }
        
        //gets year from user
        static DateTime GetYear(DateTime date, string number)
        {
            while (true)
            {
                Console.WriteLine($"Please enter the {number} year: ");
                try
                {
                    int Year = Convert.ToInt32(Console.ReadLine());
                    date = new DateTime( Year, 12, 31, 1, 1, 1);
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid entry.");
                }
            }
            return date;
        }
        //calculates number of days between dates in each year
        static int CalcDuration(DateTime date1, DateTime date2)
        {
            int sum = 0;
            for(var i = 0; i <= Math.Abs(date1.Year - date2.Year); i++)
            {
                DateTime date3 = new DateTime((date1.Year) + i, date1.Month, date1.Day, date1.Hour, date1.Minute, date1.Second);
                Console.WriteLine($"{date3} contains {date3.DayOfYear} days");
                sum += date3.DayOfYear;
            }
            return sum;
        }
    }
}


/*
//DateTime #4 --  display the number of days of the year between two specified years.
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2018, 06, 25, 14, 33, 25);
            DateTime date2 = new DateTime(2015, 6, 30, 15, 27, 45);

            Console.WriteLine($"{date1} : The year {date1.Year} {(DateTime.IsLeapYear(date1.Year) ? "is" : "is not")} a leap year and contains {(DateTime.IsLeapYear(date1.Year) ? 366 : 365)} days");
        
            Console.ReadKey();
        }
    }
}


/*
//DateTime #3 -- get the day of the week for a specified date
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2018, 06, 24, 9, 27, 44);

            Console.WriteLine(date.DayOfWeek);
            Console.ReadKey();
        }
    }
}


/*
//DateTime #2 -- display the Day properties (year, month, day, hour, minute, second, millisecond etc.
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2018, 06, 24, 9, 18, 33);

            Console.WriteLine($"\n{date}\n");

            Console.WriteLine($"year = {date.Year}");
            Console.WriteLine($"month = {date.Month}");
            Console.WriteLine($"day = {date.Day}");
            Console.WriteLine($"hour = {date.Hour}");
            Console.WriteLine($"minute = {date.Minute}");
            Console.WriteLine($"second = {date.Second}");

            Console.ReadKey();
        }
    }
}


/*
//DateTime #1 -- extract the Date property and display the DateTime value in the formatted output. 
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date = new DateTime(2018,12,24,18,30,00);

            Console.WriteLine(date.ToUniversalTime());
            Console.WriteLine(date.ToLongDateString());
            Console.WriteLine(date.ToLongTimeString());
            Console.WriteLine(date.ToShortDateString());
            Console.WriteLine(date.ToShortTimeString());


            Console.WriteLine(date.ToString("MM/dd/yy HH:mm"));

            Console.ReadKey();
        }
    }
}


/*
//File Handling -- Practice with Stream, StreamWriter, DateTime and StreamReader 
//to create time-stamped log files and then read them.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Stream fsw = new FileStream(@"C:\Users\rloyd\source\repos\w3Resource Exercises\textfile.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(fsw);

            WriteText("Hello, what is your name?", sw);
            string name = ReadText(sw);
            WriteText($"Hello, {name}! How are you today?",sw);
            ReadText(sw);
            WriteText($"Would you like to see a transcript of our conversation so far, {name}?", sw);
            while (true)
            {
                if (ReadText(sw) == "yes")
                {
                    break;
                }
                else WriteText($"{name}! that's not the answer I am looking for!", sw);
            }
            
            sw.Close();
            fsw.Close();

            Stream fsr = new FileStream(@"C:\Users\rloyd\source\repos\w3Resource Exercises\textfile.txt", FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader sr = new StreamReader(fsr);

            Console.WriteLine(sr.ReadToEnd());

            sr.Close();
            fsr.Close();

            Console.ReadKey();
        }

        static void WriteText(string text, StreamWriter sw)
        {
            Console.WriteLine(text);
            sw.WriteLine($"[{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")}] {text}");
        }

        static string ReadText(StreamWriter sw)
        {
            string text = Console.ReadLine();
            sw.WriteLine($"[{DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss")}] {text}");
            return text;
        }
    }
}


/*
//File Handling #1 -- create a blank file in the disk newly
using System;
using System.IO;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileInfo filepath = new FileInfo(@"C:\Users\rloyd\source\repos\w3Resource Exercises\file.txt");
            //filepath.Create();

            Stream fs = new FileStream(@"C:\Users\rloyd\source\repos\w3Resource Exercises\file.txt", FileMode.Open, FileAccess.Write, FileShare.None);

            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine("Text file opened.");
            Console.WriteLine("Text file opened.");
            sw.WriteLine("Text file ammended.");
            Console.WriteLine("Text file ammended.");
            sw.WriteLine("Text file closing...");
            Console.WriteLine("Text file closing...");

            sw.Close();
            fs.Close();

            Console.ReadKey();
        }
    }
}


/*
//Array #3 --  find the sum of all elements of the array
using System;
using System.Diagnostics.CodeAnalysis;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[CreateArray()];

            for (var i = 0; i < array.Length; i++)
            {
                Console.Write($"Please enter the value for element {i+1}: ");
                try
                {
                    array[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That is not a valid entry.");
                    i--;
                }
            }

            Console.WriteLine($"The sum of the array values is: {Sum(array)}");

            Console.ReadKey();
        }

        static int CreateArray()
        {
            int n = 0;
            while(n == 0)
            {
                Console.Write("Please enter the number of elments you would like to store in the array: ");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That is not a valid entry.");
                }
            }
            return n;
        }

        static int Sum(int[] nums)
        {
            int sum = 0;
            for(var i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }
            return sum;
        }
    }
}


/*
//Array #2 -- read n number of values in an array and display it in reverse order.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[CreateArray()];

            for (int i = 0; i < array.Length; i++)
            {
                try
                {
                    Console.Write($"Please enter element {i+1}: ");
                   array[i] = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That is an invalid entry.");
                    i--;
                }
            }

            Console.WriteLine("\nThank you! Now I will display the contents of this array in reverse order.");
            for (int i = array.Length-1; i > -1; i--)
            {
                Console.WriteLine($"element {i+1} : {array[i]}");
            }

            Console.ReadKey();
        }

        static int CreateArray()
        {
            int n = 0;
            while (n == 0)
            {
                Console.Write("Please enter the number of elements to store in the array: ");
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("That is an invalid entry.");
                }
            }
            return n;
        }
    }
}



/*
//Array #1 -- store elements in an array and print it.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[10];

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write($"enter element {i+1}: ");
                input[i] = Convert.ToInt32(Console.ReadLine());
            }

           for(int i = 0; i < input.Length; i++)
            {
                Console.WriteLine($"element {i+1} : {input[i]}");
            }

            Console.ReadKey();
        }
    }
}


/*
//For Loop #6 --  display the multiplication table of a given integer
using System;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter an integer and I will display a multiplication table for it: ");
            long input = Convert.ToInt64(Console.ReadLine());

            MultTable(input);

            Console.ReadKey();
        }

        static void MultTable(long num)
        {
            for (int i = 1; i < Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    Console.WriteLine($"{i} x {num / i} = {num}");
            }
        }
    }
}


/*
//Conditionals #6 -- read the value of an integer m and display the value of n is 1 
//when m is larger than 0, 0 when m is 0 and -1 when m is less than 0.
using System;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter an integer: ");
            int m = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(evalSign(m));

            Console.ReadKey();
        }

        static int evalSign(int num)
        {
            if (num > 0)
                return 1;
            if (num < 0)
                return -1;
            return 0;
        }
    }
}



/*
//File Handling #1 -- create a blank file in the disk newly.
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string path = @"C:\Users\rloyd\source\repos\w3Resource Exercises\textfiles";
        FileInfo textfile = new FileInfo(path + "\\textfile.txt");
        textfile.Directory.Create();
        FileStream fs = textfile.Create();

        Console.WriteLine($"A new text file as been created at {path}");

         fs.Close();

        Console.ReadKey();
    }
}


/*
//Searching and Sorting #1 -- sort a list of elements using Shell sort.
using System;

class Program
{
    static void Main()
    {
        int[] numarray = new[] { 2, 17, 3, 5, 1, 4, 20, 9, 15, 8, 13, 14, 7, 19, 18, 6 };
        ShellSort(numarray, numarray.Length);

        foreach (var num in numarray)
        {
            Console.Write($"{ num}, ");
        }

        Console.ReadKey();
    }
    static void ShellSort(int[] nums, int length)
    {
        int inc = 3;
        while(inc > 0)
        {
            for (int i = 0; i < length; i++)
            {
                int j = i;
                int temp = nums[i];
                while ((j >= inc) && (nums[j - inc] > temp))
                {
                    nums[j] = nums[j - inc];
                    j = j - inc;
                }
                nums[j] = temp;
            }
            if (inc / 2 != 0)
                inc = inc / 2;
            else if (inc == 1)
                inc = 0;
            else
                inc = 1;
        }

    }
}


/*
//Structure #1 -- declare a simple structure.
using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        Console.Write("Please enter a number: ");
        int inp1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Please enter a number: ");
        int inp2 = Convert.ToInt32(Console.ReadLine());
        Simple inpSum = new Simple (inp1, inp2);
        Console.WriteLine($"The sum of {inp1} and {inp2} is {inpSum.Sum()}");
        Console.ReadKey();
    }
    struct Simple
    {
        public int x;
        public int y;

        public Simple(int inX, int inY)
        {
            x = inX;
            y = inY;
        }

        public int Sum ()
        {
            return x + y;
        }
    }
}


/*
//For Loop #5 -- display the cube of the number upto given an integer.
using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter the number of cubes you would like: ");
        int input = Convert.ToInt32(Console.ReadLine());
        for(int i = 1; i < input +1; i++)
        {
            Console.WriteLine($"Number is: {i} and the cube of {i} is: {cube(i)}");
        }
        Console.ReadKey();
    }
    static int cube(int num)
    {
        return num * num * num;
    }
}


/*
//For Loop #4 -- read 10 numbers from keyboard and find their sum and average.
using System;

class Program
{
    static void Main()
    {
        int input = 0;
        double avg = 0;
        for (int i = 1; i < 11; i++)
        {
            Console.Write("\nPlease enter a number: ");
            input = Convert.ToInt32(Console.ReadLine());
            avg = ((avg * (i - 1)) + input) / i;
            Console.WriteLine("\nThe sum of the numbers entered is {0} and the average is {1}.", avg*i, avg);
        }
        Console.ReadKey();
    }
}


/*
//For Loop #3 -- display n terms of natural number and their sum.
using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter the number of numbers you would like to see: ");
        int input = Convert.ToInt32(Console.ReadLine());
        numSumCount(input);
        Console.ReadKey();
    }
    static void numSumCount(int nums)
    {
        int sum = 0;
        Console.Write("The first {0} natural numbers are: ", nums);
        for (int i = 1; i <= nums; i++)
        {
            Console.Write(i + ", ");
            sum += i;
        }
        Console.WriteLine("\nThe sum of these numbers is: " + sum);
    }
}


/*
//For Loop #2 -- find the sum of first 10 natural numbers
using System;

class Program
{
    static void Main()
    {
        sumNums(10);
        Console.ReadKey();
    }
    static void sumNums (int count)
    {
        int sum = 0;
        for(int i = 1; i <= count; i++)
        {
            sum += i;
        }
        Console.WriteLine(sum);
    }
}


/*
//For Loop #1 -- display the first 10 natural numbers.
using System;

class Program
{
    static void Main()
    {
        writeNums(10);
        Console.ReadKey();
    }
    static void writeNums(int count)
    {
        for(int i = 0; i < 11; ++i)
        {
            Console.Write(i + " ");
        }
    }
}


/*
//Conditionals #5 --  read the age of a candidate and determine whether it is eligible for casting his/her own vote.
using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter your age: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("{0}", QualifyAge(input));
        Console.ReadKey();
    }
    static string QualifyAge(int age)
    {
        if (age >= 18)
            return "Congratulations! You are eligible to vote!";
        return "We are very sorry, but you are not eligible to vote :c";
    }
}


/*
//Conditionals #4 -- find whether a given year is a leap year or not
using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter a year and I will determine whether it is a leap year or not: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.Write("The year {0} {1} a leap year.", input, isLeap(input) == true? "is" : "is not");
        Console.ReadKey();
    }
    static bool isLeap(int year)
    {
        if (year % 4 == 0)
            return true;
        return false;
    }
}


/*
//Conditionals #3 -- check whether a given number is positive or negative.
using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter a number and I will tell you whether it is positive or negative: ");
        int input = Convert.ToInt32(Console.ReadLine());
        isPos(input);
        Console.ReadKey();
    }
    static void isPos (int num)
    {
        if ( num == 0)
            Console.WriteLine($"{0} is neither positive nor negative.");
        else if (num > 0)
            Console.WriteLine($"The number {num} is positive.");
        else if (num < 0)
            Console.WriteLine($"The number {num} is negative.");
    }
}


/*
//Conditionals #2 -- check whether a given number is even or odd.
using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter an integer and I will tell you whether it is even or odd: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if(num % 2 == 0)
            Console.WriteLine($"The number {num} is even.");
        else Console.WriteLine($"The number {num} is odd.");
        Console.ReadKey();
    }
}


/*
//Conditionals #1 -- accept two integers and check whether they are equal or not.
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a number: ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter another number: ");
        int input2 = Convert.ToInt32(Console.ReadLine());
        if (input == input2)
            Console.WriteLine("These numbers are equal.");
        else { Console.WriteLine("These numbers are not equal."); }
        Console.ReadKey();
    }
}


/*
//LINQ #5 -- display the characters and frequency of character from giving string.
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a string:" );
        string input = Console.ReadLine();
        var letters = from l in input orderby l group l by l into g select g;
        foreach(var v in letters)
        {
            Console.WriteLine($"\"{v.Key}\" occurs {v.Count()} times.");
        }
        Console.ReadKey();
    }
}


/*
//LINQ #4 -- display the number and frequency of number from giving array. Grouping with a query into var allows
// data to be manipulated like a dictionary, or list, or array apparently.
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = new[] { 8, 3, 2, 5, 1, 9, 6, 4, 3, 5, 2, 9, 1, 2, 8 };
        var numSets = from n in nums orderby n group n by n into g select g;
        foreach (var num in numSets)
        {
            Console.WriteLine($"{num.Key} appears {num.Count()} times");
        }
        Console.ReadKey();
    }
}


/*
//LINQ #3 -- find the number of an array and the square of each number.
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var sqr20plus = from n in nums where n * n > 20 orderby -n select n;
        foreach(int i in sqr20plus)
        {
            Console.WriteLine($"Number = {i}, Square = {i*i}");
        }
        Console.ReadKey();
    }
}


/*
//LINQ #2 -- find the +ve numbers from a list of numbers using two where conditions in LINQ Query.
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] nums = new[] { -5, 1, -3, -2, 3, 9, -8, 10, -14, 6 };
        var posNums = from i in nums where i > 0 where i < 12 orderby i select i;
        foreach(int i in posNums)
        {
            Console.Write($"{i} ");
        }
        Console.ReadKey();
    }
}


/*
//LINQ #1 -- shows how the three parts of a query operation execute.
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        //first comes data
        int[] nums = new[] {1,2,3,4,5,6,7,8,9, };
        //then comes LINQ
        var evens = from i in nums where i % 2 == 0 select i;
        //then comes output
        foreach(int i in evens)
        {
            Console.Write($"{i} ");
        }
        Console.ReadKey();
    }
}


/*
//Recursion #10 -- find the Fibonacci numbers for a n numbers of series using recursion.
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter the number of Fibonacci numbers that you would like to see: ");
        int num = Convert.ToInt32(Console.ReadLine());
        Fibs(num, 0, 1);
        Console.ReadKey();
    }
    static void Fibs (int count, int fib1, int fib2)
    {
        if (count < 1)
            return;
        Console.WriteLine(fib1);
        Fibs(--count, fib2, fib1 + fib2);
    }
}


/*
//Recursion #9 -- find the factorial of a given number using recursion.
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine(Factorial(5,1));
        Console.ReadKey();
    }
    static int Factorial(int num, int prod)
    {
        if (num < 1)
            return prod;
        return num * Factorial(num - 1, prod);
    }
}


/*
//Recursion #8 -- Check whether a given String is Palindrome or not using recursion.
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a string and I will tell you if it is a palindrome: ");
        string input = Console.ReadLine();
        Console.WriteLine(isPal(input, 0));
        Console.ReadKey();
    }
    static bool isPal (string input, int ctr)
    {
        if (ctr > input.Length - ctr)
            return true;
        if (input[input.Length - 1 - ctr] != input[0 + ctr])
            return false;
        return isPal(input, ++ctr);        
    }
}


/*
//Recursion #7 -- check whether a number is prime or not using recursion.
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter a number and I will tell you if it is a prime: ");
        int input = Convert.ToInt32(Console.ReadLine());
        int divisor = Convert.ToInt32(Math.Sqrt(input));
        Console.WriteLine(isPrime(input, divisor));
        Console.ReadKey();
    }
    static bool isPrime (int num, int div)
    {
       if (div < 2)
            return true;
       if (num % div == 0)
            return false;
       return isPrime(num, div - 1);
    }
}


/*
//Recursion #6 -- print even or odd numbers in a given range using recursion - solution allows for user choice of even or odd
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        PrintNums(21, true);
        Console.ReadKey();
    }
    static void PrintNums(int range, bool even)
    {
        if(range > 0)
        {
            if (even == true && range % 2 == 0)
            {
                PrintNums(range - 2, even);
                Console.WriteLine(range);
            }
            if (even == true & range % 2 != 0)
            {
                PrintNums(range - 1, even);
            }
            if (even == false && range % 2 != 0)
            {
                PrintNums(range - 2, even);
                Console.WriteLine(range);
            }
            if (even == false && range % 2 == 0)
            {
                PrintNums(range - 1, even);
            }
        }
    }
}


/*
//Recursion #5 -- count the number of digits in a number using recursion.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine(Count(12345, 0));
        Console.ReadKey();
    }
    static int Count(int num, int digs)
    {
        if (num < 1)    
            return digs;
        digs++;
        return Count(num / 10, digs);
    }
}


/*
//Recursion #4 -- display the individual digits of a given number using recursion
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        PrintDigs(12345);
        Console.ReadKey();
    }
    static void PrintDigs (int num)
    {
        if (num < 10)
        {
            Console.Write(num);
            return;
        }
        PrintDigs(num / 10);
        Console.Write(" {0}", (num % 10));
    }
}


/*
//Recursion #3 -- find the sum of first n natural numbers using recursion.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine(SumNums(-10));
        Console.ReadKey();
    }
    static int SumNums(int input)
    {
        if (input > 0)
            input += SumNums(input - 1);
        return input;
    }
}


/*
//Recursion #2 -- print numbers from n to 1 using recursion
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    static void Main()
    {
        PrintNums(10);
        Console.ReadKey();
    }
    static void PrintNums(int input)
    {
        if (input > 0)
        {
            Console.WriteLine(input);
            PrintNums(input - 1);
        }
    }
}


 /*
//Recursion #1 -- print the first n natural number using recursion-Revised solution since learning that code
//following the recursive call, will execute back down the stack once the if condition returns false.
//previously I had thought this would be unreachable code. This solution was subsequently shared by someone  else.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class Program
{
    public static void Main()
    {
        PrintNums(10);
        Console.ReadKey();
    }
    static void PrintNums(int input)
    {
        if(input > 0)
        {
            PrintNums(input - 1);
            Console.WriteLine(input);
        }
    }
}


/*
//Recursion #4 sample code from site. Learned from it that code following the recursive method will still
//be executed before the return call is executed because it is all on the stack. In this case, it is
//the n % 10 call. exciting stuff!
using System;
public class RecExercise4
{
    static void Main()
    {

        Console.Write("\n\n Recursion : Display the individual digits of a given number :\n");
        Console.Write("------------------------------------------------------------------\n");
        Console.Write(" Input any number : ");
        int num = Convert.ToInt32(Console.ReadLine());
        Console.Write(" The digits in the number {0} are : ", num);
        separateDigits(num);
        Console.Write("\n\n");
        Console.ReadKey();
    }

    static void separateDigits(int n)
    {
        if (n < 10)
        {
            Console.Write("{0}  ", n);
            return;
        }
        separateDigits(n / 10);
        Console.Write(" {0} ", n % 10);
    }
}

/*
//Recursion #4 -- display the individual digits of a given number using recursion
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter a number:");
        int input = Convert.ToInt32(Console.ReadLine());
        printDigit(input);
        Console.ReadKey();
    }
    static void printDigit(int num)
    {
        Console.Write("{0}, ", num.ToString()[0]);
        if (num < 10)
            return;
        string chars = num.ToString().Remove(0, 1);
        printDigit(Convert.ToInt32(chars));
    }
}

/*
//Recursion #3 -- find the sum of the first n natural numbers using recursion
using System;
    class Program
    {
        static void Main()
        {
        Console.Write("How many numbers would you like to sum? ");
        int input = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The sum of numbers 0 through {0} is: {1}", input, sumNums(input));
        Console.ReadKey();
        }
        static int sumNums(int length)
        {
            if (length < 1)
                return length;
            return length + sumNums(length - 1);
        }
    }


/*
//Recursion #3 -- find the sum of first n natural numbers using recursion
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            Sum(25);
            Console.ReadKey();
        }

        public static void Sum(int length)
        {
            Stack<int> numStack = new Stack<int>();
            SumNumStack(numStack, length);
        }
        private static void SumNumStack(Stack<int> stackIn, int length)
        {
            stackIn.Push(length);
            if(length < 1)
            {
                while(stackIn.Count() > 0)
                {
                    length += stackIn.Pop();
                }
                Console.WriteLine(length);
                return;
            }
            SumNumStack(stackIn, length - 1);
        }
    }
}


/*
//Recursion #2 -- print numbers from n to 1 using recursion
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            CountDown(20);
            Console.ReadKey();
        }

        public static void CountDown (int length)
        {
            Console.WriteLine(length);
            if (length < 1)
            {
                return;
            }
            CountDown(length - 1);
        }
    }
}


/*
//Recursion #1 -- print the first n natural number using recursion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        public static Stack numStack = new Stack();

        static void Main()
        {
            PrintNums(10);
            Console.ReadKey();
        }
        
        public static void PrintNums (int length)
        {
            if (length < 1)
            {
                while(numStack.Count > 0)
                {
                    Console.WriteLine(numStack.Pop());
                }
                return;
            }
            numStack.Push(length);
            PrintNums(length - 1);
        }
    }
}


/*
//Basic Exercise #62 -- reverse the strings contained in each pair of matching parentheses in a given string
//and also remove the parentheses within the given string.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(RemRev("ab(cd(ef)gh)ij"));

            Console.ReadKey();
        }

        public static string RemRev(string str)
        {
            int lastOp = str.LastIndexOf('(');
            if(lastOp == -1)
            {
                return str;
            }
            int firstCl = str.IndexOf(')', lastOp);
            return RemRev(str.Substring(0, lastOp) + new string(str.Substring(lastOp + 1, firstCl - lastOp-1).Reverse().ToArray()) + str.Substring(firstCl + 1));
        }
    }
}



/*
//Basic Exercise #61 -- sort the integers in ascending order without moving the number -5.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using System.Data.SqlTypes;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 1, 8, 2, -5, 4, 9, 7, 6 };
            Console.WriteLine(string.Join(",", sort(nums)));

            Console.ReadKey();
        }

        public static int[] sort(int[] num)
        {
            int[] outs = num.Where(x => x != -5).OrderBy(x => x).ToArray();
            int c = 0;
            return num.Select(x => x != -5 ? outs[c++] : -5).ToArray();
        }
    }
}

/*
//Basic Exervise #18 -- check two given integers and return true if one is negative and one is positive.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter an integer: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a second integer: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 < 0 ^ num2 < 0);

            Console.ReadKey();
        }
    }
}

/*
//Basic Exercise #62 -- reverse the strings contained in each pair of matching parentheses in a given string 
//and also remove the parentheses within the given string.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("enter a string: ");
            string input = Console.ReadLine();
            Console.WriteLine(swap(input));

            Console.ReadKey();
        }
        
        public static string swap(string phrase)
        {
            int dex1 = phrase.IndexOf("(");
            int dex2 = phrase.IndexOf(")");
            string sOut1 = phrase.Substring(dex1, dex2-dex1+1);
            phrase = phrase.Remove(dex1, dex2-dex1+1);
            Console.WriteLine(phrase);
            int dex3 = phrase.IndexOf("(");
            int dex4 = phrase.IndexOf(")");
            string sOut2 = phrase.Substring(dex3, dex4 - dex3 +1);
            phrase = phrase.Insert(dex1, sOut2);
            phrase = phrase.Remove(phrase.IndexOf("("), 1);
            phrase = phrase.Remove(phrase.IndexOf(")"), 1);
            dex3 = phrase.IndexOf("(");
            dex4 = phrase.IndexOf(")");
            phrase = phrase.Remove(phrase.IndexOf("("), sOut2.Length);
            phrase = phrase.Insert(dex3, sOut1);
            phrase = phrase.Remove(phrase.IndexOf("("), 1);
            phrase = phrase.Remove(phrase.IndexOf(")"), 1);

            return phrase;
        }
    }
}


/*
//Basic Exercise #61 -- sort the integers in ascending order without moving the number -5.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            int[] tests = new int[] { 3, 8, 2, 4, -5, 7, 6, 9, 1 };
            Console.WriteLine(string.Join(", ", sort(tests)));

            Console.ReadKey();
        }

        public static int[] sort(int[] ints)
        {
            int[] outs = ints.Where(v => v != -5).OrderBy(v => v).ToArray();
            int c = 0;
            return ints.Select(x => x != -5 ? outs[c++] : -5).ToArray();
        }
    }
}

//Baisc Exerise #61 -- This was my first go before I learned this can be addressed much more elegantly with lambda and LINQ!
/*
namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tests = new[] { 3, 8, 2, 4, -5, 7, 6, 9, 1 };
            sort(tests);

            Console.ReadKey();
        }

        public static void sort (int[] ints)
        {
            int[] outs1st = new int[] { };
            int[] outs2nd = new int[] { };
            List<int> outsAll = new List<int>();

            Array.Resize(ref outs1st, Array.IndexOf(ints, -5) + 1);
            Array.Copy(ints, outs1st, Array.IndexOf(ints, -5));

            Array.Resize(ref outs2nd, ints.Length - Array.IndexOf(ints, -5) - 1);
            Array.Copy(ints, Array.IndexOf(ints, -5) + 1, outs2nd, 0, ints.Length - Array.IndexOf(ints, -5)-1);

            Array.Sort(outs1st);
            Array.Sort(outs2nd);

            outsAll.AddRange(outs1st);
            outsAll.Add(-5);
            outsAll.AddRange(outs2nd);

            Console.WriteLine(string.Join(",", outsAll));
        }
    }
}




/*
//Basic Exercise #60 -- calculate the sum of all the intgers of a rectangular matrix except those integers which are located below an intger of value 0.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace cFun
{
    class Program
    {
        //Example code from site. The 'for' loop works because it sums vertically and fails to continue on the first
        //occurence of a 0 in the column due to the " && my_matrix[j][i] > 0" condition.
        public static int sum_matrix_elements(int[][] my_matrix)
        {
            int x = 0;
            for (int i = 0; i < my_matrix[0].Length; i++)
                for (int j = 0; j < my_matrix.Length && my_matrix[j][i] > 0; j++)
                    x += my_matrix[j][i];

            return x;
        }

        public static void Main()
        {
            Console.WriteLine(sum_matrix_elements(
                new int[][] {
                    new int[]{0, 2, 3, 2},
                    new int[]{0, 6, 0, 1},
                    new int[]{4, 0, 3, 0}
                }));
            Console.WriteLine(sum_matrix_elements(
                new int[][] {
                    new int[]{1, 2, 1, 0 },
                    new int[]{0, 5, 0, 0},
                    new int[]{1, 1, 3, 10 }
                }));
            Console.WriteLine(sum_matrix_elements(
                new int[][] {
                    new int[]{1, 1},
                    new int[]{2, 2},
                    new int[]{3, 3},
                    new int[]{4, 4}
                }));

            Console.ReadKey();
        }
    }
}
        /*
        static void Main()
        {
            int[,] nums = new[,] { {0, 2, 3, 2 },
                                   {0, 6, 0, 1 },
                                   {4, 0, 3, 0 } };

            Console.WriteLine(noZero(nums));
            Console.ReadKey();

        }
        //calculate sum of numbers in a matrix which do not fall beneath a 0.
        public static int noZero(int[,] numbers)
        {
            var sum = 0;
            for (var v = 0; v < numbers.GetLength(0); v++)
            {
                for (var w = 0; w <numbers.GetLength(1); w++)
                {
                    if(v == 0)
                    {
                        sum += numbers[v,w];
                        continue;
                    }
                    for (var x = v-1; x >= 0; x--)
                    {
                        if (numbers[x,w] == 0)
                        {
                            break;
                        }
                        sum += numbers[v,w];
                    }
                }
            }
            return sum;
            }
    }
}


/*
//Basic Exercise #59 -- check whether it is possible to create a strictly increasing sequence from a given sequence of integers as an array.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            int[] strIn = new[] {1,3,4,5 };
            Console.WriteLine(allUnique(new int [] { 1, 3, 4, 5 }));
            Console.WriteLine(allUnique(new int[] { 4, 3, 2, 5 }));
            Console.ReadKey();
        }
        //checks if elements of an array may be arranged in a strictly increasing order.
        public static bool allUnique (int[] arrIn)
        {
            Array.Sort(arrIn);
            return (arrIn.Last() - arrIn.First() +1 == arrIn.Length);
        }
    }
}


/*
//Basic Exercise #58 -- Write a C# program which will accept a list of integers and checks how many integers are needed to complete the range
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            int[] strIn = new[] { 1, 3, 4, 7, 9 };
            Console.WriteLine(missInts(strIn));
            Console.ReadKey();
        }
        
        public static int missInts (int[] ints)
        {
            int count = 0;
            Array.Sort(ints);
            for (var v = 0; v < ints.Length-1; v++)
            {
                count += ints[v + 1] - ints[v] - 1;
            }
            return count;
        }
    }
}


/*
//Basic Exercise #57 -- find the pair of adjacent elements that has the highest product of an given array of integers.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            int[] iArr = new[] { 1, 2, 3, 4, 8, 1, 9, 3, 5, 2 };
            int prod = 0;
            for (var i = 0; i < iArr.Length - 1; i++)
            {
                prod = Math.Max(iArr[i] * iArr[i + 1], prod);
            }
            Console.WriteLine(prod);
            Console.ReadKey();
        }
    }
}


/*
//Basic Exercise #56 -- check if a given string is a palindrome or not
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main()
        {
            string input;
            Console.Write("Please enter a string and I will tell you whether it is a palindrome or not: ");
            input = Console.ReadLine();
            Console.WriteLine(string.Join("", input.ToCharArray().Reverse()));
            Console.WriteLine(input == string.Join("", input.ToCharArray().Reverse()));
            Console.WriteLine(isPalindrome(input));
            Console.ReadKey();
        }

        public static bool isPalindrome (string str)
        {
            for(var i = 0; i <str.Length; i++)
            {
                if(str[i] != str[str.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}


/*
//Basic Exercise #55 -- find the pair of adjacent elements that has the largest product of an given array.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace cFun
{
    class Program
    {
        static void Main (string[] args)
        {
            int[] iAr = new[] { 1, 2, 4, 1, 3, 5, 0, 1 };
            Console.WriteLine(LP(iAr));
            Console.ReadKey();
        }

        public static int LP (int[] array)
        {
            int LProd = 0;
            for (var i = 0; i < array.Length - 1; i++) 
            {
                LProd = (array[i] * array[i + 1]) > LProd ? array[i] * array[i + 1] : LProd;
            }
            return LProd;
        }
    }
}


/*
//Basic Exercise #54 -- get the century from a year
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a year and I will tell you the century in which it falls: ");
            int year = Convert.ToInt32(Console.ReadLine());
            int century = year / 100 + (year % 100 == 0? 0:1);
            Console.WriteLine(century);
            Console.ReadKey();
        }
    }
}


/*
//Basic Exercise #53 --  check if an array contains an odd number
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace cFun
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iAr = new[] { 2, 4, 7, 8, 6 };
            for (var i = 0; i < iAr.Length; i++)
            {
                if (iAr[i] % 2 != 0)
                {
                    Console.WriteLine(iAr.Contains(iAr[i]));
                    break;
                }
            }   
            Console.ReadKey();
        }
    }
}


/*
//Basic Exercise #52 -- create a new array of length containing the middle elements of three arrays (each length 3) of integers.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iAr1 = new[] { 1, 2, 5 };
            int[] iAr2 = new[] { 0, 3, 8 };
            int[] iAr3 = new[] { -1, 0, 2 };
            int[] iAr4 = new[] { iAr1[1], iAr2[1], iAr3[1] };
            foreach (int i in iAr4) { Console.Write($"{i}, "); }
            Console.ReadKey();
        }
    }
}


/*
//Basic Exerise #51 -- get the larger value between first and last element of an array (length 3) of integers.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArr = new[] { 1, 2, 5, 7, 8 };
            var high = 0;
            for (var i = 0; i < iArr.Length; i++)
            {
                if (iArr[i] > high) { high = iArr[i]; }
            }
            Console.WriteLine(high);
            if (iArr.First() > iArr.Last())
            {
                Console.WriteLine(iArr.First());
            }
            else { Console.WriteLine(iArr.Last()); }
            Console.ReadKey();
        }
    }
}


/*
//Basic Exervise #50 -- Write a C# program to rotate an array (length 3) of integers in left direction
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArr = new[] { 1, 2, 8 };
            iArr[0] += iArr[1]; iArr[1] += iArr[2];
            iArr[2] -= (iArr[1] - iArr[0]); iArr[0] -= iArr[2]; iArr[1] -= iArr[0];
            Console.WriteLine(string.Join(", ", iArr));
            Console.ReadKey();
        }
    }
}


/*
// Basic Exercise #49 -- Write a C# program to check if the first element or the last element of the two arrays ( length 1 or more) are equal.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main (string[] args)
        {
            int[] iArr1 = new[] { 1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 1 };
            int[] iArr2 = new[] { 1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 5 };
            Console.WriteLine((iArr1.First() == iArr2.First()) || (iArr1.Last() == iArr2.Last()));
            Console.ReadKey();
        }
    }
}


/*
///Basic Exercise #48 -- Write a C# program to check if the first element and the last element are equal of an array of integers and the length is 1 or more.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main (string[] args)
        {
            int[] iArr = new[] { 1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 1 };
            Console.WriteLine((iArr.First() == iArr.Last()) && iArr.Length > 1);
            Console.ReadKey();
        }
    }
}


/*
//Basic Exercise #47 -- Write a C# program to compute the sum of all the elements of an array of integers.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArr = new[] { 1, 2, 2, 3, 3, 4, 5, 6, 5, 7, 7, 7, 8, 8, 1 };
            Console.WriteLine(iArr.Aggregate((a, b) => a +b));
            Console.ReadKey();
        }
    }
}


/*
//Basic Exercise #46 -- Write a C# program to check if a number appears as either the first or last element of an array of integers and the length is 1 or more.
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercise
{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Enter an integer: ");
            int input = Convert.ToInt32(Console.ReadLine());
            int[] iArray = new[] { 1, 3, 5, 7, 3, 5, 42, 13, 46, 15 };
            Console.WriteLine(lastOrFirst(input, iArray));
            Console.WriteLine((iArray.First() == input) || (iArray.Last() == input));

            Console.ReadKey();
        }

        static public bool lastOrFirst(int inp, int[] iArr)
        {
            if (inp == iArr.First() || inp == iArr.Last())
            {
                return true;
            }
            return false;
        }
    }
}

/*
//Basic Exercise #45
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main (string[] args)
        {
            List<int> intArray = new List<int> ();
            Random rnd = new Random();
            int input;


            //populate list
            for (int i = 0; i < 100; i++)
            {
                intArray.Add(i % 5 + rnd.Next(7));
            }

            //populate array
            Console.Write("Stored array: {0}", string.Join(", ", intArray));
            Console.WriteLine();

            Console.Write("Please enter a an integer and I will count the number of times it appears in the stored array: ");
            input = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The number {0} occurs {1} times in the stored array.", input, intArray.Count(i => i == input));


            Console.ReadKey();

        }
    }
}


/*
//Basic Exercise #44
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string [] args)
        {
            Console.WriteLine("Enter a string and I will make a new one from ever other character:");
            string input = Console.ReadLine();

            var output = from c in input where input.IndexOf(c) % 2 != 0 select c;

            Console.WriteLine(string.Join("", output));

            Console.ReadKey();
        }
    }
}

/*
//Basic Exercise #43
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Console.WriteLine("please enter a string and I will tell you if it begins with a 'w' and is immediately followed by two sets of 'ww': ");
            input = Console.ReadLine();
            Console.WriteLine(Checker(input));
            Console.ReadKey();
        }

        public static bool Checker(string inputString)
        {
            if (inputString.Length > 4 && inputString.StartsWith("w") && inputString.Substring(1,2) == "ww" && inputString.Substring(3,2) == "ww")
            {
                return true;
            }
            return false;
        }
    }
}

/*
//Basic Exercise #42
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<char> output = new List<char>();

            Console.WriteLine("Please enter a string: ");
            input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (i < 4)
                {
                    output.Add(char.ToUpper(input[i]));
                }
                else { output.Add(input[i]); }
            }
            foreach(char c in output)
            {
                Console.Write(c);
            }
            Console.ReadKey();            
        }
    }
}

/*
//Basic Exerise #41
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main (string[] args)
        {
            string input;
            char w = 'w';

            Console.WriteLine($"Please enter a string of characters and I will detremine if it contains the character {w} between 1 and 3 times: " );
            input = Console.ReadLine();

            
            //if (input.Contains('w'))
            //{
            //    var ws = from c in input where c == w select c;
            //    Console.WriteLine($"The character '{w}' occurs {ws.Count()} times in the string that you entered.");
            //}
            //else { Console.WriteLine("The string that you entered does not contain a 'w'"); }
            

            var ws = from c in input where c == w select w;

            if (ws.Count() < 4 && ws.Count() > 0)
            {
                Console.WriteLine("The string that you entered contains a 'w' between 1 and 3 times.");
            }
            else { Console.WriteLine("The string that you entered does not contain a 'w' between 1 and 3 times."); }

            Console.ReadKey();
        }
    }
}
    
/*
//Basic Exercise #40
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int cntrl = 20;
            int inp1;
            int inp2;

            Console.WriteLine("Please enter an integer: ");
            inp1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter another integer and I will determine which is closer to 20: ");
            inp2 = Convert.ToInt32(Console.ReadLine());

            if (Math.Abs(cntrl-inp1) > Math.Abs(cntrl - inp2))
            {
                Console.WriteLine($"{inp2} is closer to {cntrl} than {inp1}.");
            }
            else { Console.WriteLine($"{inp1} is closer to {cntrl} than {inp2}."); }

            Console.ReadKey();
        }
    }
}

/*
//basic exercise # 39
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;

namespace w3Reasource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[3];
            Queue intQueye = new Queue();
            List<int> intList = new List<int>();

            for(int i = 0; i <3; i++)
            {
                Console.WriteLine("Please enter an integer:");
                intList.Add(Convert.ToInt32(Console.ReadLine()));
            }

            Console.WriteLine("Unsorted intList: {0}", string.Join(", ", intList));
            intList.Sort();
            Console.WriteLine("Sorted intList: {0}", string.Join(", ", intList));

            Console.WriteLine($"Largest number {intList[2]}, Smallest number: {intList[0]}");

            Console.ReadKey();
        }
    }
}


/*
//Basic Exercise # 38
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main (string[] args)
        {
            string input = "PHP";
            Console.WriteLine(input);

            if (input.StartsWith("PH"))
            {
                string output = input.Substring(0, 2);
                Console.WriteLine(output);
            }

            Console.ReadKey();
        }
    }
}

/*
//Basic Exercise # 37
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w3Resource_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string aString = "PHP Tutorial";
            Console.WriteLine(aString);

            //if(Convert.ToString(aString[1]) == "H" && Convert.ToString(aString[2]) == "P")
            if(aString.Contains("HP") && aString.IndexOf("HP") == 1)
            {
                aString = aString.Remove(1, 2);
                Console.WriteLine(aString);

                Console.ReadKey();
            }

        }
    }
}
*/

