using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicorEagle.Validation
{
    interface IValidator<T>
    { 
        bool Validate(T t);     
    }
}
