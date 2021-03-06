﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    class StringCalculator
    {
      

        public static int Add(string numbers)
        {
            var delims = ",\n";
            if(string.IsNullOrEmpty(numbers))
                return 0;
            if (numbers.Contains("//"))
            {
                delims += numbers[2];
                numbers = numbers.Substring(4, numbers.Length - 4);

            }
            
            
            int i; 
            List<int> intList = numbers.Split(' ').Select(s => int.TryParse(s, out i) ? i : -1).ToList();
            var results = intList.FindAll(x=> x > 1000);

            if (results.Any())
            {
                
            }
            
            
            var items = numbers.Split(delims.ToCharArray());
            if(items.Any(string.IsNullOrEmpty))
                throw new ArgumentException();

           
            var integers = items.Select(x => int.Parse(x));
            var negatives = integers.Where(x => x < 0);
            if (!negatives.Any()) return items.Select(x => int.Parse(x)).Sum();
            {
                var message = "Negative not allowed: {0}";
                throw new ArgumentOutOfRangeException(string.Format(message,string.Join(",", negatives.Select(x => x.ToString()).ToArray())));
            }
            
           


        }
    }
}