﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fin
{
    public interface ISQLAzure
    {
        Task<bool> Authenticate();
    }
}
