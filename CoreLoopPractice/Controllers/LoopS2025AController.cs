using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace CoreLoopPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoopS2025AController : ControllerBase
    {

        /// <summary>
        /// counts from 0 to {ceiling} by 3s
        /// </summary>
        /// <returns>
        /// An output string with numbers separated (delimited) by a comma, counting from 1 to {limit} by {step}
        /// </returns>
        /// <param name="limit">The number to count to</param>
        /// <param name="step">How many to count by</param>
        /// <example>
        /// GET: api/LoopS2025A/WhileExample?limit=15&step=3 -> 0,3,6,9,12,15
        /// </example>
        /// <example>
        /// GET: api/LoopS2025A/WhileExample?limit=14&step=3 -> 0,3,6,9,12
        /// </example>
        /// <example>
        /// GET: api/LoopS2025A/WhileExample?limit=14&step=4 -> 0,4,8,12
        /// </example>
        [HttpGet]
        [Route(template: "WhileExample")]
        public string WhileExample(int limit, int step)
        {
            // analagous to console.log in JS
            Debug.WriteLine($"I want to count from 0 to {limit}");
            Debug.WriteLine($"I have received a value of {step}");

            string message = "";
            string delimiter = ",";
            int iterator = 0;

            // todo: make sure you never run into an infinite loop given {limit} and {step}

            while (iterator <= limit)
            {
                // actions that happen while the loop is running
                // iterative instructions
                // if we are at the last step
                if ((iterator + step) > limit)
                {
                    delimiter = "";
                }
                message = message + iterator.ToString() + delimiter;

                Debug.WriteLine($"iterator:{iterator}");

                // iterative step
                iterator = iterator + step;
            }

            return message;
        }


        /// <summary>
        /// count from {start} to {limit} by {step}
        /// </summary>
        /// <param name="start">The number to start by</param>
        /// <param name="limit">The number to count to</param>
        /// <param name="step">The amount to count by</param>
        /// <returns></returns>
        /// <example>
        /// POST : api/LoopS2025A/ForExample
        /// Header: application/x-www-form-urlencoded
        /// Data: start=1&limit=5&step=1
        /// -> 1,2,3,4,5
        /// </example>
        /// <example>
        /// POST : api/LoopS2025A/ForExample
        /// Header: application/x-www-form-urlencoded
        /// Data: start=0&limit=-3&step=-1
        /// -> 0,-1,-2,-3
        /// </example>
        /// <example>
        /// POST : api/LoopS2025A/ForExample
        /// Header: application/x-www-form-urlencoded
        /// Data: start=100&limit=95&step=2
        /// -> Invalid Combination of start, limit, and step
        /// </example>
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [Route(template: "ForExample")]
        public string ForExample([FromForm] int start, [FromForm] int limit, [FromForm] int step)
        {
            Debug.WriteLine($"I want to count from {start} to {limit} to limit by {step}");
            // todo: validate the start, limit and step values


            string message = "";

            bool isAscending = true;
            if ((start > limit) && step < 0)
            {
                isAscending = false;
            }
            else if ((start <= limit) && step > 0)
            {
                isAscending = true;
            }
            else
            {
                return "Invalid";
            }

            //three main ingredients for the loop
            // (i)nitial start value // (i)ncrementor value
            // !(exit condition) <> (iterating condition)
            // iterating step
            if (isAscending)
            {
                for (int i = start; i <= limit; i += step)
                {
                    message = message + i + ",";
                }

            }
            else // descending condition
            {
                for (int i = start; i >= limit; i += step)
                {
                    message = message + i + ",";
                }
            }


            return message;
        }

        /// <summary>
        /// returns all favorite animals at the zoo
        /// </summary>
        /// <returns>
        /// A list of comma separated zoo animals, when referring to an animal that starts with a vowel, we use "an" rather than "a"
        /// </returns>
        /// <example>
        /// GET : api/S2025A/ZooAnimals -> At the zoo I saw a Rhino, At the zoo I saw an Elephant, At the zoo I saw a Bear, at the zoo I saw a Turtle
        /// </example>
        [HttpGet]
        [Route(template: "ZooAnimals")]
        public string ZooAnimals()
        {
            // wanted to sort the animals by name?
            // add / remove animals?
            // change delimiter
            //var Animals = ["Tiger", "Bear", "Turtle"]; // in JS
            List<string> Animals = new List<string>() {"Rhino", "Elephant"};
            Animals.Add("Tiger");
            Animals.Add("Bear");
            Animals.Add("Turtle");
            Animals.Add("Zebra");
            Animals.Add("Aardvark");
            // Animals.append("Tiger") // in JS
            string diary = "";

            List<string> Vowels = new List<string>() {"A","E","I","O","U"};
            
            // go from Animals[0] to Animals[4] -> counting from 0 to 4 by 1s
            // enumerable set of information -> information that can be labelled from 1..n
            foreach(string Animal in Animals)
            {
                string glue = "a";
                // if the animal starts with a vowel
                // change 'glue' variable to "an"

                string StartsWith = Animal[0].ToString();
                Debug.WriteLine("The first letter of our animal is " + StartsWith);
                if (Vowels.Contains(StartsWith)) // A E I O U contains U?
                {
                    glue = "an";
                }
                diary += $"At the zoo I saw {glue} "+Animal+"! ";
            }

            return diary; 
        }

    }
}
