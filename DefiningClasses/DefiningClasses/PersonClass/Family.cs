namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people = new List<Person>();

        public void AddMember(Person person)
        {
            people.Add(person);
        }

        public Person GetOldestMember()
        {
            // Option 1
            //int maxAge = people.Max(p => p.Age);
            //Person oldestPerson = people.FirstOrDefault(p => p.Age == maxAge);
            //return oldestPerson;

            // Option 2 
            //return people
            //    .FirstOrDefault(p => p.Age == people.Max(p1 => p1.Age));

           // Dimo's option
            return people.OrderByDescending(p => p.Age).FirstOrDefault();

        }
    }
}
