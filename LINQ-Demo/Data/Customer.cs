using System;

namespace LINQ_Demo.Data
{
    public class Customer : IEquatable<Customer>
    {
        public int id { get; set; }
        public string name { get; set; }

        public bool Equals(Customer other)
        {
            //Check of the de andere niet null is
            if (ReferenceEquals(other, null)) return false;

            //Check of de andere niet naar hetzelfde object wijst
            if (ReferenceEquals(this, other)) return true;

            //Check of klanten id en naam overeen komen
            return id.Equals(other.id) && name.Equals(other.name);
        }
    }
}