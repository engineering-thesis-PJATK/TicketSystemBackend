﻿using System;

namespace OneBan_TMS.Models.DTOs.Employee
{
    using OneBan_TMS.Models;
    public class EmployeeDto
    {
        public string EmpName { get; set; }
        public string EmpSurname { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPhoneNumber { get; set; }
        public string EmpPassword { get; set; }
        public Employee GetEmployee()
        {
            return new Employee()
            {
                EmpEmail = this.EmpEmail,
                EmpLogin = this.EmpEmail,
                EmpSurname = this.EmpSurname,
                EmpName = this.EmpName,
                EmpPhoneNumber = EmpPhoneNumber,
                EmpCreatedAt = DateTime.Now
            };
        }
    }

}
