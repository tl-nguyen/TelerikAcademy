//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _01.EmployeesInfo
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHoursLog
    {
        public int WorkHoursLogID { get; set; }
        public int WorkHourID { get; set; }
        public int EmployeeID { get; set; }
        public System.DateTime Date { get; set; }
        public string Task { get; set; }
        public int Hours { get; set; }
        public string Comments { get; set; }
        public string Command { get; set; }
        public string Status { get; set; }
    }
}
