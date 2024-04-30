namespace Smarti.Entites
{
    public class PersonEntity
    {

        public int tz { get; set; }
        public string name { get; set; }

        public int age { get; set; }
        public AddressEntity address { get; set; }

    }

    public class AddressEntity
    {
        public string city { get; set; }
        public string region { get; set; }
    }
}
