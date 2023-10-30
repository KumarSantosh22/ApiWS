using Pagination.Core;
using Sieve.Attributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pagination.Models
{
    [Table("Ticket", Schema = Constants.Schema)]
    public class Ticket
    {
        public int? Id { get; set; }


        [Sieve(CanFilter = true, CanSort = true)]
        public string? Category { get; set; }


        [Sieve(CanFilter = true, CanSort = true)]
        public string? Status { get; set; }


        [Sieve(CanFilter = true, CanSort = true, Name = "created")]
        public DateTime? CreatedAt { get; set; }

        public Guid? Guid { get; set; }

        public Ticket() { }
        public Ticket(string category, string status)
        {
            Category = category;
            Status = status;
            CreatedAt = DateTime.UtcNow;
            Guid = new Guid();
        }

    }
}
