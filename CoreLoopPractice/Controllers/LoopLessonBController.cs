using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreLoopPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoopLessonBController : ControllerBase
    {

        /// <summary>
        /// Outputs the numbers from 1 to 20
        /// </summary>
        /// <returns>
        /// Returns the numbers one through twenty
        /// </returns>
        /// <example>
        /// GET: api/LoopLessonB/OneToTwenty -> "1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 "
        /// </example>
        [HttpGet(template: "OneToTwenty")]
        public string OneToTwenty()
        {
            int incrementor = 1;
            string message = "";
            while(incrementor <= 20)
            {
                //loop body
                message = message + incrementor.ToString() + " ";
                incrementor = incrementor + 1;
            }
            return message;
        }

        /// <summary>
        /// A while loop that counts from 1 to {ceiling}
        /// </summary>
        /// <returns>a comma separated list of numbers from 1 to {ceiling}</returns>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice?ceiling=100 -> 1,2,3,4,..100,
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice?ceiling=500 -> 1,2,3,4,..500,
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice?ceiling=1 -> 1,
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice?ceiling=-1 -> ""
        /// </example>
        [HttpGet(template:"WhilePractice")]
        public string WhilePractice(int ceiling)
        {
            int incrementor = 1;
            string message = "";

            while(incrementor <= ceiling)
            {
                message = message + incrementor.ToString() + ",";
                incrementor = incrementor + 1; // incrementor+=1; incrementor++;
            }

            return message;
        }

        /// <summary>
        /// counts from 0 to {limit} by {step}
        /// </summary>
        /// <param name="limit">the number to count towards</param>
        /// <param name="step">the number to count by</param>
        /// <returns>
        /// A comma separated sequence of characters from 0 to {limit} by {step}
        /// </returns>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice2/10/1 -> 0,1,2,3,4,5,6,7,8,9,10
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice2/-10/-1 -> 0,-1,-2,-3,-4,-5,-6,-7,-8,-9,-10
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice2/8/2 -> 0,2,4,6,8
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice2/11/3 -> 0,3,6,9,
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice2/-11/3 -> "Invalid"
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice2/10/-1 -> "Invalid"
        /// </example>
        /// <example>
        /// GET: api/LoopLessonB/WhilePractice2/10/0 -> "Invalid"
        /// </example>
        [HttpGet("WhilePractice2/{limit}/{step}")]
        public string WhilePractice2(int limit, int step)
        {
            int incrementor = 0;
            string message = "";

            bool isIncreasing = step > 0;
            bool isDecreasing = step < 0;

            // INVALID IF
            // Step is 0 OR
            // (isIncreasing AND limit is negative) OR
            // (isDecreasing AND limit is positive)

            if (step==0 || (isIncreasing && limit<0) || (isDecreasing && limit>0))
            {
                return "Invalid";
            }

            string delimiter = ",";

            if (isIncreasing)
            {
                //increasing incrementor towards limit
                while (incrementor <= limit)
                {
                    //at the last step = ?
                    if (incrementor + step > limit)
                    {
                        delimiter = "";
                    }

                    message = message + incrementor.ToString() + delimiter;
                    incrementor = incrementor + step;
                }
            }
            else
            {
                //increasing incrementor towards limit
                while (incrementor >= limit)
                {
                    //at the last step = ?
                    if (incrementor + step < limit)
                    {
                        delimiter = "";
                    }

                    message = message + incrementor.ToString() + delimiter;
                    incrementor = incrementor + step;
                }
            }
            

            return message;

        }

        /// <summary>
        /// count from 30 to {ceiling} by {step}. Assume ceiling >= 30 and step >= 1
        /// </summary>
        /// <returns>
        /// the numbers 30 up to {ceiling} by {step}. Not inclusive to {ceiling}
        /// </returns>
        /// <example>
        /// POST api/ForPractice1
        /// Header: Content-Type: application/x-wwww-urlencoded
        /// DATA: ceiling=35&step=1
        /// -> 30,31,32,33,34
        /// </example>
        [HttpPost(template:"ForPractice1")]
        [Consumes("application/x-www-form-urlencoded")]
        public string ForPractice1([FromForm]int ceiling, [FromForm]int step)
        {
            // A) incrementor = 30
            // B) incrementor < ceiling
            // C) incrementor = incrementor + step
            // for(A; B; C)
            string message = "";
            for(int i = 30; i < ceiling; i+=step)
            {
                message = message + i.ToString() + ",";
            }
            //removes the last trailing ','
            message = message.Trim(',');

            return message;
        }

        /// <summary>
        /// Output a list of favorite TV shows
        /// </summary>
        /// <returns>
        /// a comma separated list of tv shows
        /// </returns>
        /// <example>
        /// GET api/LoopLessonB/ForEachPractice -> Breaking Bad - BCS - GOT - The Wire - Shogun - Friends - Paw Patrol
        /// </example>
        [HttpGet("ForEachPractice")]
        public string ForEachPractice()
        {
            //in JS var TVShows = ["Breaking Bad", "BCS", "GOT"]
            List<string> TVShows = new List<string>();

            //in JS TVShows.push("TV SHOW")
            TVShows.Add("Breaking Bad"); //0
            TVShows.Add("BCS"); //1
            TVShows.Add("GOT"); //2
            TVShows.Add("The Wire"); //3
            TVShows.Add("Shogun"); //4
            TVShows.Add("Friends"); //5
            TVShows.Add("Paw Patrol"); //6
            TVShows.Add("Naruto"); //7

            //if you try to refer to TVShows[8] - System.ArgumentOutOfRangeException
            //if you try to refer to TVShows[-1] - System.ArgumentOutOfRangeException

            // build an output message for each tv show
            string message = "";
            // for each tv show
            // could be expressed with a for loop accessing i from 0 to TVShows.Count()
            foreach(string TVShow in TVShows)
            {
                message = message + TVShow + " - ";
            }

            return message;

        }


    }
}
