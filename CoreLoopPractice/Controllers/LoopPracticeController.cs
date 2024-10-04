using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreLoopPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoopPracticeController : ControllerBase
    {
        /// <summary>
        /// Counts from One to Value
        /// </summary>
        /// <param name="Value">Number to count to</param>
        /// <returns>string of numbers deliminated with "," which count from one to {Value}.</returns>
        /// <example>
        /// GET api/LoopPractice/OneToValue/4 ->
        /// "1,2,3,4"
        /// </example>
        /// <example>
        /// GET api/LoopPractice/OneToValue/8 ->
        /// "1,2,3,4,5,6,7,8"
        /// </example>
        [HttpGet(template:"OneToValue/{Value}")]
        public string OneToValue(int Value)
        {
            int counter = 1;
            string message = "";
            while (counter <= Value)
            {
                message = message + counter.ToString() + ",";
                counter = counter + 1;
            }
            // remove trailing ',' character.
            message = message.Trim(',');

            return message;
        }

        /// <summary>
        /// Counts from Ten to Thirty.
        /// </summary>
        /// <returns>A string of numbers deliminated by "," which count from Ten to Thirty.</returns>
        /// <example>
        /// GET : api/LoopPractice/TenToThirty
        /// "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30"
        /// </example>
        [HttpGet(template:"TenToThirty")]
        public string TenToThirty()
        {
            string message = "";

            for (int counter = 10; counter <= 30; counter = counter + 1)
            {
                message = message + counter + ",";
            }
            //remove trailing ',' character.
            message = message.Trim(',');

            return message;
        }

        /// <summary>
        /// Counts from {start} to {end}
        /// </summary>
        /// <param name="start">The starting number</param>
        /// <param name="end">The ending number</param>
        /// <returns>A string of numbers deliminated by ",". The numbers will count up if {start} is less than {end}, will count down if {start} is greater than {end}</returns>
        /// <example>
        /// GET : api/LoopPractice/ValueToValue/5/8 ->
        /// "5,6,7,8,"
        /// </example>
        /// <example>
        /// GET : api/LoopPractice/ValueToValue/8/5 ->
        /// "8,7,6,5,"
        /// </example>
        [HttpGet(template:"ValueToValue/{start}/{end}")]
        public string ValueToValue(int start, int end)
        {
            string message = "";
            //Counting up from {start} to {end}
            if (start < end)
            {
                while (start <= end)
                {
                    message = message + start + ",";
                    start = start + 1;
                }
            }
            //Count down from {start} to {end}
            else
            {
                while (start >= end)
                {
                    message = message + start + ",";
                    start = start - 1;
                }

            }
            //remove trailing ',' character.
            message = message.Trim(',');

            return message;

        }

        /// <summary>
        /// Prints a list of favorite snacks stored in a List<string>
        /// </summary>
        /// <returns>A string of snacks deliminated by ",".</returns>
        /// <example>
        /// GET : api/LoopPractice/FavoriteSnacks ->
        /// "Blackberries, Almonds, Sunflower Seeds, Strawberries, Chips,"
        /// </example>
        [HttpGet(template:"FavoriteSnacks")]
        public string FavoriteSnacks()
        {
            //Array of Strings
            List<string> Snacks = new List<string> { "Blackberries", "Almonds", "Sunflower Seeds" };

            Snacks.Add("Strawberries");
            Snacks.Add("Chips");

            string message = "";

            foreach (string Snack in Snacks)
            {
                message = message + Snack + ",";

            }
            //remove trailing ',' character.
            message = message.Trim(',');

            return message;
        }

        /// <summary>
        /// Counts from -5 to -20
        /// </summary>
        /// <returns>a string of comma deliminated values from -5 to -20</returns>
        /// <example>
        /// GET : api/LoopPractice/MinusFiveToMinusTwenty ->
        /// "-5,-6,-7,-8,-9,-10,-11,-12,-13,-14,-15,-16,-17,-18,-19,-20,"
        /// </example>
        [HttpGet(template:"MinusFiveToMinusTwenty")]
        public string MinusFiveToMinusTwenty()
        {
            string message = "";
            int counter = -5;

            while (counter >= -20)
            {
                message = message + counter.ToString();

                counter = counter - 1;
            }

            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});

            return message;
        }

        /// <summary>
        /// Prints a string of numbers from -10 to 10 counting by {step}
        /// </summary>
        /// <param name="step"></param>
        /// <returns>A string of numbers deliminated by ","</returns>
        /// <example>
        /// GET : api/LoopPractice/MinusTenToTen/3
        /// "-10,-7,-4,-1,2,5,8,"
        /// </example>
        /// <example>
        /// GET : api/LoopPractice/MinusTenToTen/2
        /// "-10,-8,-6,-4,-2,0,2,4,6,8,10,"
        /// </example>
        /// <example>
        /// GET : api/LoopPractice/MinusTenToTen/-5
        /// "Invalid Step. Must be greater than 0."
        /// </example>
        
        [HttpGet(template: "LoopPractice/MinusTenToTen/{step}")]
        public string MinusTenToTen(int step)
        {
            string message = "";
            //start off with 

            //how long do we want to stay in the loop?

            if (step >= 1)
            {
                for (int i = -10; i <= 10; i = i + step)
                {
                    message = message + i.ToString() + ",";
                }
            }
            else
            {
                message = "Invalid Step. Must be greater than 0.";
            }

            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});
            return message;
        }

        /// <summary>
        /// Prints a string of colors of Colors using a Colors array.
        /// </summary>
        /// <returns>A string of colors deliminated by ","</returns>
        /// <example>
        /// GET : api/LoopPractice/ListColors   ->
        /// "Green,Blue,Purple,"
        /// </example>
        [HttpGet(template:"api/LoopPractice/ListColors")]
        public string ListColors()
        {
            string message = "";
            string[] colors = new string[] { "Green", "Blue", "Purple" };



            foreach (string color in colors)
            {
                message = message + color + ",";

            }
            //Include below line to remove trailing ',' character.
            //message = message.Trim(new char[] {','});
            return message;
        }



        /// <summary>
        /// Splits a message string character by character 
        /// </summary>
        /// <param name="message">string message to split</param>
        /// <returns>A string of characters deliminated by ","</returns>
        /// <example>
        /// GET : api/LoopPractice/SplitString?message=Hello%20There  ->
        /// "H,e,l,l,o, ,T,h,e,r,e,"
        /// </example>
        [HttpGet(template:"SplitString/{message}")]
        public string SplitString(string message)
        {
            string output = "";
            //char is a data type for a single character.
            foreach (char m in message)
            {
                output = output + m + ",";
            }
            //Include below line to remove trailing ',' character.
            //output = output.Trim(new char[] {','});
            return output;
        }

        /// <summary>
        /// Counts from {start} to {step} by {limit}
        /// </summary>
        /// <param name="start">The starting position</param>
        /// <param name="limit">The limit, either upper limit or lower limit</param>
        /// <param name="step">The value to increment by per loop iteration</param>
        /// <returns>A list of integers which represent counting from {start} to {limit} by {step}</returns>
        /// <example>
        /// GET: api/LoopPractice/CounterList/0/4/1		->	[0,1,2,3,4]
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterList/-10/30/10		->	[-10,0,10,20,30]
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterList/-10/-17/2		->	[0]
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterList/-10/-17/-2	->	[-10,-12,-14,-16]
        /// </example>
        [HttpGet(template:"LoopPractice/Counter/{start}/{limit}/{step}")]
        public IEnumerable<int> CounterList(int start, int limit, int step)
        {
            bool isIncreasing = (start < limit) && (step > 0);
            bool isDecreasing = (start > limit) && (step < 0);

            List<int> Steps = new List<int>();

            //prevent an invalid loop.
            if (!isIncreasing || !isDecreasing)
            {
                Steps.Add(0);
            }
            else
            {
                for (int i = start; i <= limit; i += step)
                {
                    Steps.Add(i);
                }
            }
            return Steps;
        }

        /// <summary>
        /// Counts from {start} to {step} by {limit}
        /// </summary>
        /// <param name="start">The starting position</param>
        /// <param name="limit">The limit, either upper limit or lower limit</param>
        /// <param name="step">The value to increment by per loop iteration</param>
        /// <returns>A string of comma deliminated integers represent counting from {start} to {limit} by {step}</returns>
        /// <example>
        /// GET: api/LoopPractice/CounterString/0/4/1		->	"0,1,2,3,4,"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterString/-10/30/10		->	"-10,0,10,20,30,"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterString/-10/-17/2		->	"0"
        /// </example>
        /// <example>
        /// GET: api/LoopPractice/CounterString/-10/-17/-2	->	"-10,-12,-14,-16,"
        /// </example>
        [HttpGet(template:"LoopPractice/CounterString/{start}/{limit}/{step}")]
        public string CounterString(int start, int limit, int step)
        {
            bool isIncreasing = (start <= limit) && (step > 0);
            bool isDecreasing = (start >= limit) && (step < 0);

            string message = "";

            //prevent an invalid loop.
            if (!isIncreasing && !isDecreasing)
            {
                message = "0";
            }
            else
            {
                //begin at {start}; continue until {limit}; increment by {step}
                for (int i = start; i <= limit; i += step)
                {
                    message += i.ToString() + ",";
                }
            }
            //Include below line to remove trailing ',' character.
            message = message.Trim(',');
            return message;
        }

        
    }
}
