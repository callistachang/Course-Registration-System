using System;
using CourseRegistrationSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationSystem.Controller
{
    public class ScheduleManager
    {
        public readonly DbSet<Slot> Slots;
        public readonly DbSet<CourseSlot> CourseSlots;
        public readonly DbSet<ClassSlot> ClassSlots;

        public ScheduleManager(DbSet<Slot> slots, DbSet<CourseSlot> courseSlots, DbSet<ClassSlot> classSlots)
        {
            Slots = slots;
            CourseSlots = courseSlots;
            ClassSlots = classSlots;
        }

        public CourseSlot CreateClassSlot(Course course, string venue, Model.DayOfWeek dayOfWeek, int startHour, int startMinute, int endHour, int endMinute)
        {
            Slot slot = CreateSlot(venue, dayOfWeek, startHour, startMinute, endHour, endMinute);
            CourseSlot courseSlot = new CourseSlot(course, slot);
            CourseSlots.Add(courseSlot);
            System.Instance.Database.Save();
            return courseSlot;
        }

        public ClassSlot CreateClassSlot(Class @class, string venue, Model.DayOfWeek dayOfWeek, int startHour, int startMinute, int endHour, int endMinute)
        {
            Slot slot = CreateSlot(venue, dayOfWeek, startHour, startMinute, endHour, endMinute);
            ClassSlot classSlot = new ClassSlot(@class, slot);
            ClassSlots.Add(classSlot);
            System.Instance.Database.Save();
            return classSlot;
        }

        private Slot CreateSlot(string venue, Model.DayOfWeek dayOfWeek, int startHour, int startMinute, int endHour, int endMinute)
        {
            Slot slot = new Slot(venue, dayOfWeek, new TimeSpan(startHour, startMinute, 0), new TimeSpan(endHour, endMinute, 0));
            Slots.Add(slot);
            System.Instance.Database.Save();
            return slot;
        }
    }
}
