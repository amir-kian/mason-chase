﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IEventDispatcher
    {
        void Dispatch<TEvent>(TEvent @event) where TEvent : IDomainEvent;
    }
}
