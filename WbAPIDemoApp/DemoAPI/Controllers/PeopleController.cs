using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    /// <summary>
    /// This is where I give all the information about my peeps. Zoli: Ez egy sajat dokumentacio,
    /// 1. Properties --> Build --> Xml documetation file.
    /// 2. Areas/HelpPage/App_Start/HelpPageConfig: Uncomment: 
    /// config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/Documentation.xml")));
    /// </summary>
        
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person { FirstName = "Zoli", LastName = "Toth", Id = 1 });
            people.Add(new Person { FirstName = "Darth", LastName = "Vader", Id = 2 });
            people.Add(new Person { FirstName = "Luke", LastName = "Skywalker", Id = 3 });
        }

        // ### this xml comment will be shown in the browser ###
        /// <summary>
        /// Gets a list of the firstnames of all users
        /// </summary>
        /// <param name="userId">The unique identifier for this person.</param>
        /// <param name="age">We want to know how old they are.</param>
        /// <returns>A list of firstnames...duh</returns>
        [Route("api/People/GetFN/{userId:int}/{age:int}")] // Ezzel hivhato a bongeszobol. Tetszoleges utvonalstring adhato
        [HttpGet]
        public List<string> GetFirstNames(int userId, int age)
        {
            List<string> output = new List<string>();

            foreach (var p in people)
            {
                output.Add(p.FirstName);
            }

            return output;
        }

        // GET: api/People // kimegy az az applikacionkbol
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
            //return people.FirstOrDefault(x => x.Id == id); // Ez is jo
        }

        // POST: api/People // Bejon az applikacionkba
        // A postman app segitsegevel. A body-ba irjuk (beallitasok: raw es Json):
        // {
        //   Id: 4
        //   Firstname: 'Rege',
        //   LastName: 'Sugarka'
        //}
        // A body nem lathato https eseten.
    public void Post(Person val)
        {
            people.Add(val);
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
            // people.Remove(people.Where(x => x.Id == id).FirstOrDefault()); // Az en megoldasom, de lenyegtelen...
        }
    }
}