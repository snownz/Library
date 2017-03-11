﻿using Library.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Interface
{
    public interface ICompany : IDbCRUD<PublishingCompany>
    {        
    }
}