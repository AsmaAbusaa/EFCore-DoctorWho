using Microsoft.EntityFrameworkCore;
using DoctorWho.Db;
using DoctorWho.Db.DataModels;
using System.Data;

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

