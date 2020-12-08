using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person { FirstName = "Zoli", LastName = "Toth", Id = 1 });
            people.Add(new Person { FirstName = "Darth", LastName = "Vader", Id = 2 });
            people.Add(new Person { FirstName = "Luke", LastName = "Skywalker", Id = 3 });
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

53:45
