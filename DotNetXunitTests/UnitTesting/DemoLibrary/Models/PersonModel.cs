namespace DemoLibrary.Models
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string FullName => $"{ FirstName } { LastName }";

    }
}
