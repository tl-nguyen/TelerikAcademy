using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudenNP
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { set; get; }
        public string MiddleName { set; get; }
        public string LastName { set; get; }
        public string Ssn { set; get; }
        public string Address { set; get; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public int Course { set; get; }
        public string Specialty { set; get; }
        public string University { set; get; }
        public string Faculty { set; get; }

        public Student(string firstName, string middleName, string lastName, 
                        string ssn, string address = "", string mobile = "", string email = "", 
                        int course = 1, string specialty = "", string university = "", string faculty = "")
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.Address = address;
            this.Mobile = mobile;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public static bool operator ==(Student a, Student b) 
        {
            return a.FirstName == b.FirstName && a.MiddleName == b.MiddleName && a.LastName == b.LastName && 
                    a.Ssn == b.Ssn && a.Address == b.Address && a.Mobile == b.Mobile && a.Email == b.Email && 
                    a.Course == b.Course && a.Specialty == b.Specialty && a.University == b.University && a.Faculty == b.Faculty;
        }

        public static bool operator !=(Student a, Student b)
        {
            return !(a == b);
        }

        public override bool Equals(object other)
        {
            return this == (other as Student);
        }

        public override string ToString()
        {
            return 
                String.Format("{0} {1} {2} \n- SSN : {3} \n- Address : {4} \n- Mobile : {5} \n- Email : {6} \n- Course : {7} \n- Specialty : {8} \n- University : {9} \n- Faculty : {10} \n",
                                    this.FirstName, this.MiddleName, this.LastName, 
                                    this.Ssn, this.Address, this.Mobile, this.Email, 
                                    this.Course, this.Specialty, this.University, this.Faculty);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, 
                                this.Ssn, this.Address, this.Mobile, this.Email, 
                                this.Course, this.Specialty, this.University, this.Faculty);
        }

        public int CompareTo(Student other)
        {
            if (this.Equals(other)) return 0;

            var oderedStudents = (new Student[] { this, other })
                                           .OrderBy(st => st.FirstName)
                                           .ThenBy(st => st.MiddleName)
                                           .ThenBy(st => st.LastName)
                                           .ThenBy(st => st.Ssn);
            return this == oderedStudents.ToList()[0] ? 1 : -1;
        }
    }
}
