namespace Doccure.AppointmentService.Entities
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string DoctorId { get; set; }     // Mongo'dan geliyor.
        public string PatientId { get; set; }     // Identity'den gelecek.
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }

        public AppointmentDetail AppointmentDetail { get; set; }
        public List<DoctorSchedule> DoctorSchedules { get; set; }

    }
}
