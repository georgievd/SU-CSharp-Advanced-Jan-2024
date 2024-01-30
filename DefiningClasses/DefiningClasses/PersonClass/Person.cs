namespace DefiningClasses

{
    public class Person
    {
        // Fields
        private string name;
        private int age;

        // Properties to get and set field values
        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Age
        {
            get => age; 
            set => age = value;
        }

        // Constructors 
        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(int age) : this()
        {
            this.age = age;
        }

        public Person(string name, int age) 
        {
            this.name = name;
            this.age = age;
        }
    }
}
