using System.ComponentModel.DataAnnotations;

namespace TP4_.Models
{
    public class Student
    {
       [Key] int id;
        string first_name;
        string last_name;
        string phone_number;
        string university;
        DateTime timestamp;
        string course;

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string University { get => university; set => university = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
        public string Course { get => course; set => course = value; }

        public Student(int id, string first_name, string last_name, string phone_number, string university, DateTime timestamp, string course)
        {
            this.id = id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.phone_number = phone_number;
            this.university = university;
            this.timestamp = timestamp;
            this.course = course;
        }

      
    }
}
