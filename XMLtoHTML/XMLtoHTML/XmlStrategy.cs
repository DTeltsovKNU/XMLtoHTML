﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLtoHTML
{
        interface IXmlStrategy
        {
            List<Students> search(Students st);
        }
}
