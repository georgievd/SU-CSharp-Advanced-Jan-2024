namespace SoftUniParking
{
    internal class Dog
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }

        public Dog(string name, Gender gender)
        {
            Name = name;
            Gender = gender;
        }
    }

    public enum Gender
    {
        Male,
        Female,
    }
}
