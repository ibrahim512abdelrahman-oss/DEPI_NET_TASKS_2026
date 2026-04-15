namespace LibraryAPI.Dtos
{
    public class BorrowerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }
    }
    
    public class CreateBorrowerDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }
    }
    
    public class UpdateBorrowerDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime MembershipDate { get; set; }
    }
}