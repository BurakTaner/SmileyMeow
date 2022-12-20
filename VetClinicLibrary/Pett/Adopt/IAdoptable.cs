using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetClinicLibrary.Pett.Adopt;

public interface IAdoptable
{
    bool IsAdoptable { get; set; }
}
