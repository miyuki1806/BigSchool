﻿using BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BigSchool.Controllers
{
    
    public class AttendancesController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Attend (Course attendanceDto) 
        {
            var userID = User.Identity.GetUserId();
            BigSchoolContext context = new BigSchoolContext();
            if(context.Attendances.Any(P => P.Attendee ==userID && P.CourseId == attendanceDto.Id))
            {
                return BadRequest("The attendance already exists");
            }
            var attendance = new Attendance() { CourseId = attendanceDto.Id, Attendee = User.Identity.GetUserId() };
            context.Attendances.Add(attendance);
            context.SaveChanges();
            return Ok();
        }
        
    }
}
