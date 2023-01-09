using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalAPI.Helpers;

public static class RandomNumberGenerator
{
    public static int RandomNumberGenerate() {
        Random generator = new();

        return generator.Next(6,10);
    }    
}
