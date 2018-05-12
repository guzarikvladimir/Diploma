using System;

namespace CP.Core.Contract.Permission.Models
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException()
            : base("You dont have permissions to do this action")
        {
        }
    }
}