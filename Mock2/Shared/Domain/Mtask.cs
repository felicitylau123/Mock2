using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock2.Shared.Domain
{
    public class Mtask
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
