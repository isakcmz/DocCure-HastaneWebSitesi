using Doccure.PrescriptionService.Entities;

namespace Doccure.PrescriptionService.Dtos.PrescriptionDtos
{
    public class ResultPrescriptionDto
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<PrescriptionItem> PrescriptionItems { get; set; }
    }
}
