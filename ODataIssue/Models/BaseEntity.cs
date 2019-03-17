using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataIssue.Models
{
    public class BaseEntity
    {
        [NotMapped]
        public string UniqueIdentifier { get; set; } = Guid.NewGuid().ToString();
    }
}
