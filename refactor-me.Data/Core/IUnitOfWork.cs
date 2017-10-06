﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Core
{
    public interface IUnitOfWork
    {

         /// <summary>
         /// Save the changes to the DbContext.
         /// </summary>
         void Commit();
    }
}