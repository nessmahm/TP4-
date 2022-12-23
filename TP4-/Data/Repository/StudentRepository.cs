using Microsoft.EntityFrameworkCore;
using TP4_.Models;
namespace TP4_.Data.Repository
{
    public class StudentRepository
    {
        private readonly UniversityContext _context;
        public StudentRepository()
        {
            _context = UniversityContext.Instantiate_UniversityContext();
        }
        public StudentRepository(UniversityContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetAll()
        {
            return _context.Student.ToList();
        }
        public Student GetById(int StudentID)
        {
            return _context.Student.Find(StudentID);
        }
        public void Insert(Student Student)
        {
            _context.Student.Add(Student);
        }
        public void Update(Student Student)
        {
            _context.Entry(Student).State = EntityState.Modified;
        }
        public void Delete(int StudentID)
        {
            Student Student = _context.Student.Find(StudentID);
            _context.Student.Remove(Student);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Student> GetByCourse(string Course)
        {
           return _context.Student.Where(s => s.Course.ToUpper() == Course.ToUpper()).ToList();


        }
        public IEnumerable<String> GetCourses()
        {
            return _context.Student.Select(x => x.Course).Distinct().ToList();
        }


    }
}
    