using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmileyMeow.Helpers;

public static class AgeCalculator
{
    public static int CalculateAge(DateTime DOB) {
        return DateTime.Now.Year - DOB.Year;
    }
}
