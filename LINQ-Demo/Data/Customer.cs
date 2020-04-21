using System;

namespace LINQ_Demo.Data
{
    public class Customer : IEquatable<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Equals(Customer other)
        {
            //Check of the de andere niet null is
            if (other is null) return false;

            //Check of de andere niet naar hetzelfde object wijst
            if (ReferenceEquals(this, other)) return true;

            //Check of klanten id en naam overeen komen
            return Id.Equals(other.Id) && Name.Equals(other.Name);
        }
    }
}