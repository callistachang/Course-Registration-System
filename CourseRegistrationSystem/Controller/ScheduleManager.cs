using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationSystem.Controller
{
    public class ScheduleManager
    {
        public readonly DbSet<CourseSlot> Slots;

        public ScheduleManager(DbSet<CourseSlot> slots)
        {
            Slots = slots;
        }
    }
}
