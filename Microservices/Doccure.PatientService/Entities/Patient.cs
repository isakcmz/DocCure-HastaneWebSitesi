namespace Doccure.PatientService.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcKimlikNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string BloodType { get; set; }
        public string InsuranceType { get; set; }
        public string CurrentDiagnosis { get; set; }
        public bool IsActiveTreatment { get; set; }
        public bool IsCritical { get; set; }
        public DateTime? LastVisitDate { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<PatientVisit> PatientVisits { get; set; }
    }
}
