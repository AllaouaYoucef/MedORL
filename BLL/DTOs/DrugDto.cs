using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class DrugDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Dosage { get; set; }

    }
}
