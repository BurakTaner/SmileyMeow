using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Person;

public class Balance : IBalance
{
    public int PersonId { get; set; }
    public decimal PersonBalance { get; set; }
}
