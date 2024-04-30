namespace Smarti.Models
{
    public class JsonModel
    {
        public class Priorities
        {
            public List<string> tz { get; set; }
            public List<string> name { get; set; }
            public List<string> age { get; set; }
            public Address address { get; set; }
        }

        public class Address
        {
            public List<string> city { get; set; }
            public List<string> region { get; set; }
        }

        public class JsonData
        {
            public string entityType { get; set; }
            public Priorities priorities { get; set; }
        }
    }
}
