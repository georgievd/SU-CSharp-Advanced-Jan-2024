namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get => name;
            private set => name = value;
        }
        public int Age
        {
            get => age;
            private set => age = value;
        }


        public int CompareTo(Person? other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }
            return result;
        }

        /// <summary>
        /// Provides a hashcode which represents current object
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        /// <summary>
        /// Determine if the passed obj is equal to the current one.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other == null)
            {
                return false;
            }
            return Name == other.Name && Age == other.Age;
        }
    }
}
