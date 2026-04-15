namespace LibraryAPI.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
    
    public class CreateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
    
    public class UpdateAuthorDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}