using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XbankQuery.Domain.Models.InputModels
{
    public class StatementInputModel
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public DateTime InitialDate { get; set; }
        [Required]
        public DateTime FinalDate { get; set; }
    }
}
