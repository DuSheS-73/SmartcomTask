﻿using SmartcomTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartcomTask.Domain.Repositories.Abstract
{
    public interface IOrderElementRepository
    {
        IQueryable<OrderElement> GetOrderElements();
        void SaveOrderElement();
        void DeleteOrderElement();
    }
}
