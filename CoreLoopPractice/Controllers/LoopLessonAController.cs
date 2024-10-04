using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreLoopPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoopLessonAController : ControllerBase
    {
        /// <summary>
        /// Will output the numbers 0 to 15
        /// </summary>
        /// <returns>a sequence of numbers representing the integers 0 to 15</returns>
        /// <example>
        /// GET api/LoopLessonA/ZeroToFifteen -> 0123456789101112131415
        /// </example>
        [HttpGet(template:"ZeroToFifteen")]
        public string ZeroToFifteen()
        {
            int incrementor = 0;
            string message = "";
            int ceiling = 15;
            while(incrementor <= ceiling)
            {
                message = message + incrementor.ToString();
                incrementor = incrementor + 1;
            }
            return message;
        }

        /// <summary>
        /// count from 100 down to {floor} by 1s
        /// </summary>
        /// <param name="floor">The number to count down towards. Should be < 100 </param>
        /// <returns>
        /// a sequence of numbers representing the integers 100 to {floor}
        /// </returns>
        /// <example>
        /// GET : api/LoopLessonA/HundredToFloor/97 ->
        /// 100,99,98,97,
        /// </example>
        /// <example>
        /// GET : api/LoopLessonA/HundredToFloor/100 ->
        /// 100,
        /// </example>
        /// <example>
        /// GET : api/LoopLessonA/HundredToFloor/110 ->
        /// ""
        /// </example>
        [HttpGet(template:"HundredToFloor/{floor}")]
        public string HundredToFloor(int floor)
        {
            string message = "";
            int incrementor = 100;

            // continue while incrementor is above the floor
            while (incrementor >= floor)
            {
                message = message + incrementor.ToString();
                message = message + ",";
                incrementor = incrementor - 1;
            }
            return message;
        }

        /// <summary>
        /// count from {start} to {end}
        /// </summary>
        /// <param name="start">the value to start from</param>
        /// <param name="end">the value to end at</param>
        /// <returns></returns>
        /// <example>
        /// POST : api/LoopLessonA/ValueToValue
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: start=5&end=10
        /// -> 5,6,6,8,9,10
        /// </example>
        /// <example>
        /// POST : api/LoopLessonA/ValueToValue
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// POST DATA: start=-2&end=4
        /// -> -2,-1,0,1,2,3,4
        /// </example>
        [HttpPost(template: "ValueToValue")]
        [Consumes("application/x-www-form-urlencoded")]
        public string ValueToValue([FromForm]int start, [FromForm]int end)
        {
            int incrementor = start;
            string message = "";
            bool isIncreasing = start < end;
            string delimiter = ",";

            if (isIncreasing)
            {
                // increasing towards the end ceiling
                while (incrementor <= end)
                {
                    //if we are at the end, no comma
                    if(incrementor == end)
                    {
                        delimiter = "";
                    }
                    message = message + incrementor.ToString() + delimiter;
                    incrementor = incrementor + 1;
                }
            }
            else
            {
                // decreasing towards the end floor
                while (incrementor >= end)
                {
                    //if we are at the end, no comma
                    if (incrementor == end)
                    {
                        delimiter = "";
                    }
                    message = message + incrementor.ToString() + delimiter;
                    incrementor = incrementor - 1;
                }
            }
            return message;
        }

        /// <summary>
        /// count from {start} to {end} by {step}
        /// </summary>
        /// <returns>
        /// counting from {start} to {end} by {step} with a for loop
        /// </returns>
        /// <example>
        /// GET : api/ForLoopExample?start=1&end=10&step=3 ->
        /// 1-4-7-10
        /// </example>
        /// <example>
        /// GET : api/ForLoopExample?start=2&end=11&step=5 ->
        /// 2-7
        /// </example>
        /// <example>
        /// GET : api/ForLoopExample?start=2&end=11&step=-5 ->
        /// "Invalid"
        /// </example>
        
        [HttpGet(template:"ForLoopExample")]
        public string ForLoopExample(int start, int end, int step)
        {
            // (if we are increasing and step is less than 0) OR
            // (start is greater than end)
            if ((step<=0 && start <= end) || (start >= end ))
            {
                return "Invalid";
            }
         
            string message = "";
            char delimiter = '-';
            //increase to the ceiling
            for (int i = start; i <= end; i = i + step)
            {
                message = message + i.ToString()+delimiter;              
            }
            message = message.Trim(delimiter);

            return message;
        }

        /// <summary>
        /// returns a list of favorite desserts with the for each loop
        /// </summary>
        /// <returns>a sequence of strings each separated by a comma with a dessert</returns>
        /// <example>
        /// GET: api/LoopLessonA/FavoriteDesserts -> "Cake * Ice Cream * Pudding * Chocolate"
        /// </example>
        [HttpGet(template:"FavoriteDesserts")]
        public string FavoriteDesserts()
        {
            // in JS: var Desserts = [];
            List<string> Desserts = new List<string>();
            // in JS: Desserts.push("Cake");
            Desserts.Add("Cake");     //0
            Desserts.Add("Ice Cream");//1
            Desserts.Add("Pudding");  //2
            Desserts.Add("Chocolate");//3
            Desserts.Add("Pancakes"); //4
            // Desserts[8] => Error System.ArgumentOutOfRangeException

            string message = "";
            //can access each desert by refering its [i]th index
            foreach(string Dessert in Desserts)
            {
                message = message + Dessert + " * ";
            }

            
            return message;
        }

    }
}
