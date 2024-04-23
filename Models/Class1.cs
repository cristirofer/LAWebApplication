using System.ComponentModel.DataAnnotations;

namespace LAWebApplication.Models
{
    public class Class1
    {
        public string Id { get; set; }
        public string password { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
    }
}
