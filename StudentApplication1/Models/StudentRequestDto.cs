namespace StudentApplication1.Models
{
    public class StudentRequestDto
    {
        public string FullName { get; set; }
        public int Class { get; set; }
        public char Division { get; set; }

        public string ParentName { get; set; }

        public string Address { get; set; }
    }
}
