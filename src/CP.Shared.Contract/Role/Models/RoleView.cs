using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.Role.Models
{
    public class RoleView : IViewWithId<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public static readonly Role[] Administrators = {Role.HumanResource, Role.PowerUser};
        public static readonly Role[] CompensationManagers = {Role.CompensationManager, Role.PowerUser};

        protected bool Equals(RoleView other)
        {
            return Id.Equals(other.Id) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((RoleView)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Id.GetHashCode() * 397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }

        public static bool operator ==(RoleView first, Role second)
        {
            if (ReferenceEquals(first, null))
            {
                return false;
            }

            return first.Name.Replace(" ", string.Empty) == second.ToString();
        }

        public static bool operator !=(RoleView first, Role second)
        {
            return !(first == second);
        }
    }
}