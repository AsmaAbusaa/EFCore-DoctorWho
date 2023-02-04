using Microsoft.EntityFrameworkCore;
using DoctorWho.Db;
using DoctorWho.Db.DataModels;

using (DoctorWhoCoreDbContext doctorWhoCoreDbContext = new DoctorWhoCoreDbContext())
{
    doctorWhoCoreDbContext.Database.EnsureCreated();
}


////GetDoctors();

//void GetDoctors()
//{
//    using var context = new DoctorWhoCoreDbContext();
//    var episods = context.Doctors.ToList();
//    foreach (var e in episods)
//        Console.WriteLine(e.DoctorName);
//    var state = context.ChangeTracker.DebugView.ShortView;
//}

////AddDoctors();
//void AddDoctors()
//{
//    using var context=new DoctorWhoCoreDbContext();
//     context.Doctors.AddRange(
// new Doctor {  DoctorNumber = 1, DoctorName = "William Hartnell", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date },
// new Doctor { DoctorNumber = 2, DoctorName = "Peter Capaldi", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date },
// new Doctor { DoctorNumber = 3, DoctorName = "Jon Pertwee", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date },
// new Doctor { DoctorNumber = 4, DoctorName = "Patrick Troughton", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date },
// new Doctor {  DoctorNumber = 5, DoctorName = "Sylvester McCoy", BirthDate = DateTime.Now.Date, FirstEpisodeDate = DateTime.Now.Date, LastEpisodeDate = DateTime.Now.Date }
// );
//    context.SaveChanges();
//}
