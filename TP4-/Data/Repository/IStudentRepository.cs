using TP4_.Models;

namespace TP4_.Data.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int StudentID);
        IEnumerable<Student> GetByCourse(string Course);
        IEnumerable<String> GetCourses();

        void Insert(Student Student);
        void Update(Student Student);
        void Delete(int StudentID);
        void Save();

    }
}
