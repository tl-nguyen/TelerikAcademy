﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceAndPolymorphism
{
    public class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string name, string teacher, IList<string> students)
            : base(name, teacher, students)
        {
            this.Lab = null;
        }

        public LocalCourse(string name)
            : base(name)
        {
            this.Lab = null;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("LocalCourse { Name = ");
            result.Append(base.ToString());
            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }
            result.Append(" }");

            return result.ToString();
        }
    }
}
