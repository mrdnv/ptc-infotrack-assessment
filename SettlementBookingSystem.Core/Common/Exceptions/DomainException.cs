﻿using System;

namespace SettlementBookingSystem.Core.Common.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message)
        {

        }
    }
}
