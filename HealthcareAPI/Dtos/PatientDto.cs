namespace HealthcareAPI.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
    
    public class CreatePatientDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
    
    public class UpdatePatientDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
    }
}