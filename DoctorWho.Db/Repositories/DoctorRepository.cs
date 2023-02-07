using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public void AddDoctor()
        {
            Doctor doctor = new Doctor()
            {
                DoctorName = "Ms Julie",
                DoctorNumber = 4,
                BirthDate = new DateTime(1989, 6, 8),
                FirstEpisodeDate = new DateTime(2006, 5, 8),
                LastEpisodeDate = new DateTime(2006, 11, 6)
            };
            var result = context.Doctors.Add(doctor);
            context.SaveChanges();
        }
        public void DeleteDoctor(int id)
        {
            var result = context.Doctors.FromSqlInterpolated($"DELETE FROM Doctors WHERE DoctorId={id}");
            context.SaveChanges();

        }
        public Doctor GetDoctor(int id)
        {
            var doctor = context.Doctors.Find(id);
            if (doctor != null)
                return doctor;
            throw new Exception("Not Found");
        }
        public HashSet<Doctor> GetAllDoctors()
        {
            HashSet<Doctor> doctors = new HashSet<Doctor>();
            doctors = context.Doctors.FromSqlRaw("SELECT * FROM Doctors").ToHashSet();

            return doctors;
        }
    }
}
