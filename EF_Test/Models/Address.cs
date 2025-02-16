using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Test.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        public string? AddressInfo { get; set; }

        public int PostCode { get; set; }

        [ForeignKey("student")]
        public int StudentId { get; set; }
        public Student student { get; set; }

    }
}
