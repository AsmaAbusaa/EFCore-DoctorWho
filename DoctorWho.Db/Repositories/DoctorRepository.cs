using DoctorWho.Db.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class DoctorRepository
    {
        DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext();
        public int AddDoctor(string doctorName,int doctorNumber,DateTime birthDate,DateTime firstEpisodeDate,DateTime lastEpisodeDate)
        {
            Doctor doctor = new Doctor()
            {
                DoctorName = doctorName,
                DoctorNumber = doctorNumber,
                BirthDate = birthDate,
                FirstEpisodeDate = firstEpisodeDate,
                LastEpisodeDate =lastEpisodeDate
            };
            var result = context.Doctors.Add(doctor);
           return context.SaveChanges();
        }
        public int DeleteDoctor(int id)
        {
            var result = context.Doctors.FromSqlInterpolated($"DELETE FROM Doctors WHERE DoctorId={id}");
           return context.SaveChanges();

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
