using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FoodCalories
{
    class Food 
    {
        public string FoodName { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int Calories { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            List<Food> foods = new List<Food>();

            int totalCalories = 0;

            string pattern = @"([#|])(?<food>[A-Za-z\s*]+)\1(?<date>[\d]{2})\/(?<month>[\d]{2})\/(?<year>[\d]{2})\1(?<cals>[\d]{1,5})\1";
            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(inputText);

            foreach (Match match in matches)
            {
                string food = match.Groups["food"].Value;
                string date = match.Groups["date"].Value;
                string month = match.Groups["month"].Value;
                string year = match.Groups["year"].Value;
                int calories = int.Parse(match.Groups["cals"].Value);

                totalCalories += calories;

                foods.Add(new Food
                {
                    FoodName = food,
                    Date = date,
                    Month = month,
                    Year = year,
                    Calories = calories
                });
            }  

            Console.WriteLine( $"You have food to last you for: {totalCalories / 2000} days!");

            foreach (var food in foods)
            {
                Console.Write($"Item: {food.FoodName}, Best before: {food.Date}/{food.Month}/{food.Year},");

                Console.WriteLine($" Nutrition: {food.Calories}");
            }            
        }
    }
}
