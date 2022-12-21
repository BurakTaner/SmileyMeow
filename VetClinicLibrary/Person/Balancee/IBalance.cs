using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetClinicLibrary.Person;

namespace VetClinicLibrary.Person;

public interface IBalance
{
    int BalanceId { get; set; }
    decimal PersonBalance { get; set; }
}
