using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    /// <summary>
    /// Represents one specific person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// ID from SQL
        /// </summary>
        public int Id { get; set; } = 0;
        /// <summary>
        /// The user's first name
        /// </summary>
        public string FirstName { get; set; } = "";
        /// <summary>
        /// Couldn't you guess?
        /// </summary>
        public string LastName { get; set; } = "";
    }
}