using Doccure.DoctorService.Entities;

namespace Doccure.DoctorService.Dtos.DoctorDtos
{
    public class GetDoctorByIdDto
    {
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BranchId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ImageUrl { get; set; }
        public string About { get; set; }
        public int ExperienceYear { get; set; }
        public decimal PricePerHour { get; set; }


        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }
        public List<Award> Awards { get; set; }
        public List<string> Services { get; set; }
        public List<string> Specializations { get; set; }
    }
}
