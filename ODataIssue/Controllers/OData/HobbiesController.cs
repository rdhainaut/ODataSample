using Microsoft.AspNet.OData;
using ODataIssue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataIssue.Controllers.OData
{
    public class HobbiesController
    {
        public static List<Hobby> data = new List<Hobby>()
        {
            new Hobby() { Label = "3D printing" },
            new Hobby() { Label = "Acting" },
            new Hobby() { Label = "Beatboxing" },
            new Hobby() { Label = "Calligraphy" },
            new Hobby() { Label = "Computer programming" },
            new Hobby() { Label = "Cooking" },
            new Hobby() { Label = "Drawing" },
            new Hobby() { Label = "Electronics" },
            new Hobby() { Label = "Juggling" },
            new Hobby() { Label = "Lego building" },
            new Hobby() { Label = "Magic" },
            new Hobby() { Label = "Puzzles" },
            new Hobby() { Label = "Yoga" }
        };

        [EnableQuery]
        public IQueryable<Hobby> Get()
        {
            return data.AsQueryable();
        }
    }
}
