using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ODataIssue.Models
{
    public class Hobby: BaseEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
