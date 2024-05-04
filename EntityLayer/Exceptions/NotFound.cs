﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Exceptions
{
    public abstract class NotFound : Exception
    {
        protected NotFound(string message): base(message)
        {
                
        }


    }
}
