using System;
using System.Collections.Generic;


namespace constrained_generics.Services
{
    internal class CalculationService
    {
        public T Max<T>(List<T> list) where T : IComparable
        {

            if (list.Count == 0)
            {
                throw new ArgumentException("The list can not be empty");
            }
            T max = list[0];


            
        }


    }
}
