namespace StudentApplication1.Models
{
    public class MarkDto
    {
        public Guid Id { get; set; }
        public int Mark1 { get; set; }
        public int Mark2 { get; set; }
        public int Mark3 { get; set; }
        public int Mark4 { get; set; }
        public int Mark5 { get; set; }
        public int Mark6 { get; set; }
        public Guid StudentId { get; set; }

        public StudentDto Student { get; set; }

    }
}
