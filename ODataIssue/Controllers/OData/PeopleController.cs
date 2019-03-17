using Microsoft.AspNet.OData;
using ODataIssue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ODataIssue.Controllers.OData
{
    public class PeopleController
    {
        public static List<Person> data = new List<Person>()
        {
            new Person()
            {
                Firstname = "John",
                Hobbies = new List<Hobby>() { HobbiesController.data[0], HobbiesController.data[1] }
            },
            new Person()
            {
                Firstname = "Bob",
                Hobbies = new List<Hobby>() { HobbiesController.data[5], HobbiesController.data[8], HobbiesController.data[10] }
            },
            new Person()
            {
                Firstname = "Will",
                Hobbies = new List<Hobby>() { HobbiesController.data[0], HobbiesController.data[3] }
            }
        };

        [EnableQuery]
        public IQueryable<Person> Get()
        {
            return data.AsQueryable();
        }
    }
}
