using System;
using System.Globalization;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate = GetBirthDate(this);
            DateTime secondDate = GetBirthDate(other);

            return firstDate > secondDate;
        }

        private DateTime GetBirthDate(Student student)
        {
            DateTime birthDate;
            string birthDateString = ExtractBirthDate(student.OtherInfo);
            string format = "dd.MM.yyyy";

            if (DateTime.TryParseExact(birthDateString,
                                                format,
                                                CultureInfo.InvariantCulture,
                                                DateTimeStyles.None,
                                                out birthDate))
            {
                return birthDate;
            }
            else
            {
                throw new ArgumentException("Invalid date format");
            }
            
        }

        private string ExtractBirthDate(string studentInfo)
        {
            string birthDate = studentInfo.Substring(studentInfo.Length - 10);

            return birthDate.Trim();
        }
    }
}
