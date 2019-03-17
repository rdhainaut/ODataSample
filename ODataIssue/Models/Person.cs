using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ODataIssue.Models
{
    public class Person : BaseEntity
    {
        public Person()
        {
            Hobbies = new HashSet<Hobby>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public ICollection<Hobby> Hobbies { get; set; }
    }
}
