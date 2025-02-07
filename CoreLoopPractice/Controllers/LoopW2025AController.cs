using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace CoreLoopPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoopW2025AController : ControllerBase
    {

        /// <summary>
        /// This loop counts from 1 to {ceiling} and outputs a string
        /// </summary>
        /// <param name="ceiling">The number to count towards</param>
        /// <returns>a string of comma separated numbers from one to {ceiling}</returns>
        /// <example>
        /// GET: /api/LoopW2025A/WhileLoopExample?ceiling=20 ->
        /// 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
        /// GET: /api/LoopW2025A/WhileLoopExample?ceiling=4 ->
        /// 1,2,3,4
        /// </example>
        [HttpGet(template:"WhileLoopExample")]
        public string WhileLoopExample(int ceiling)
        {
            string message = "";
            int start = 1;
            int iterator = start;
            string delimiter = ",";
            // while the condition evaluates to true;
            while (iterator <= ceiling)
            {
                // run the set of instructions for each iterating step
                // no delimiter on the last step
                if (iterator == ceiling)
                {
                    delimiter = "";
                }
                message = message + iterator.ToString() + delimiter;
                // incrementing step
                iterator = iterator + 1;
            }

            return message;
        }


        /// <summary>
        /// This loop counts from 1 to {ceiling} and outputs a string
        /// </summary>
        /// <param name="ceiling">The number to count towards</param>
        /// <returns>a string of comma separated numbers from one to {ceiling}</returns>
        /// <example>
        /// POST: /api/LoopW2025A/ForLoopExample
        /// Content-Type: application/json
        /// FORM DATA: 20 ->
        /// 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
        /// </example>
        /// <example>
        /// POST: /api/LoopW2025A/ForLoopExample
        /// Content-Type: application/json
        /// FORM DATA: 20 ->
        /// 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
        /// </example>
        [HttpPost(template:"ForLoopExample")]
        public string ForLoopExample([FromBody]int ceiling)
        {
            string message = "";
            // count from 1 to ceiling using a for loop instead of a while loop
            // in a while loop, we specified:
            // the starting value of our (i)ncrementor
            // the "stay in" condition of our loop aka. (!break condition)
            // incrementing step

            //all the same (i=i+1, i++, i+=1)
            
            int start = 1;
            for (int i = start; i<=ceiling; i+=3)
            {
                message = message + i.ToString()+",";
            }
            return message;
        }

        /// <summary>
        /// This loop counts from {start} to {ceiling} by {step} and outputs a string
        /// </summary>
        /// <param name="start">The number to start from</param>
        /// <param name="ceiling">The number to count towards</param>
        /// <param name="step">The step value to increment by</param>
        /// <returns>a string of comma separated numbers from one to {ceiling}</returns>
        /// <example>
        /// POST: /api/LoopW2025A/StartToCeiling
        /// Content-Type: application/x-www-form-urlencoded
        /// FORM DATA: start=-4&ceiling=4,step=1 ->
        /// -4,-3,-2,-1,0,1,2,3,4,
        /// </example>
        /// <example>
        /// POST: /api/LoopW2025A/StartToCeiling
        /// Content-Type: application/x-www-form-urlencoded
        /// FORM DATA: start=3&ceiling=1,step=-1 ->
        /// 3,2,1,
        /// </example>
        [HttpPost(template: "StartToCeiling")]
        [Consumes("application/x-www-form-urlencoded")]
        public string StartToCeiling([FromForm] int ceiling, [FromForm] int start, [FromForm] int step)
        {
            string message = "";
            // similar to console.log(string) but from the server
            Debug.WriteLine($"I want to count from {start} to {ceiling} by {step}");

            // count from 1 to ceiling using a for loop instead of a while loop
            // in a while loop, we specified:
            // the starting value of our (i)ncrementor
            // the "stay in" condition of our loop aka. (!break condition)
            // incrementing step

            //all the same (i=i+1, i++, i+=1)
            
            
            for (int i = start; i <= ceiling; i += step)
            {
                message = message + i.ToString() + ",";
            }
            
            return message;
        }


        /// <summary>
        /// We want to output a list of favorite books, separated by ;
        /// </summary>
        /// <returns>
        /// A string representing our favorite books
        /// </returns>
        /// <example>
        /// GET api/LoopW2025A/FavouriteBooks -> "Flatland; The Design of EveryDay Things; The Hobbit; The Mathematical Universe; A Song of Ice and Fire"
        /// </example>
        [HttpGet(template:"FavouriteBooks")]
        public string FavouriteBooks()
        {
            // how can we go through each book one at a time? <>
            // How can we Enumerate through the books?
            
            List<string> books = new List<string>() { "Flatland", "The Design of EveryDay Things", "The Hobbit", "The Mathematical Universe", "A Song of Ice and Fire" };

            books.Add("The Universe in a Nutshell");

            string message = "";
            // in JS : books.length
            for (int i=0; i < books.Count(); i=i+1)
            {
                message = message + books[i] + "; ";
            }

            //convert the books list of strings into a single output string
            // what would this be in JS?
            return message;
        }


        /// <summary>
        /// Output favorite movies, and receiving one movie as well
        /// </summary>
        /// <returns>
        /// A string representing our favorite movies + the users favorite movie
        /// </returns>
        /// <example>
        /// GET api/LoopW2025A/FavoriteMovies?favmovie=The%20Enigma%20Machine -> "Endgame Avengers, The Matrix, Despicable Me, Get Out, The Enigma Machine"
        /// </example>
        [HttpGet(template: "FavouriteMovies")]
        public string FavouriteMovies(string favmovie)
        {
            // how can we go through each book one at a time? <>
            // How can we Enumerate through the books?

            List<string> movies = new List<string>() { };

            movies.Add("Endgame Avengers");
            movies.Add("The Matrix");
            movies.Add("Despicable Me");
            movies.Add("Get Out");
            movies.Add(favmovie);


            string message = "";
            // in JS : books.length
            foreach(string movie in movies)
            {
                message = message + movie + ", ";
            }

            //convert the books list of strings into a single output string
            // what would this be in JS?
            return message;
        }


        

    }
}
