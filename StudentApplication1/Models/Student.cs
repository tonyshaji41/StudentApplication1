namespace StudentApplication1.Models
{
    public class Student
    {
        
        public Guid Id { get; set; }
            

        public string FullName { get; set; }
        public int Class { get; set; }
        public char Division { get; set; }

        public string ParentName { get; set; }

        public string Address { get; set; }

    }
}
