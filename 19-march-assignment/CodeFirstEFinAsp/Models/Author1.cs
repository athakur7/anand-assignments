namespace CodeFirstEFinAsp.Models
{
    public class Author1
    {
        public string Id { get; set; }
        public string Name { get; set; }    
        public IList<Course1> Courses { get; set; }

    }
}
