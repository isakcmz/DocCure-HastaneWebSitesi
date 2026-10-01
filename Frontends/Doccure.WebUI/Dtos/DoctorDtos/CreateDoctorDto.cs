namespace Doccure.WebUI.Dtos.DoctorDtos
{
    public class CreateDoctorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BranchId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public int ExperienceYear { get; set; }
        public decimal PricePerHour { get; set; }
        public bool Status { get; set; }


        public List<EducationDto> Educations { get; set; } = new();
        public List<ExperienceDto> Experiences { get; set; } = new();
        public List<AwardDto> Awards { get; set; } = new();
        public List<LocationDto> Locations { get; set; } = new();
        public List<string> Services { get; set; } = new();
        public List<string> Specializations { get; set; } = new();
    }
}
