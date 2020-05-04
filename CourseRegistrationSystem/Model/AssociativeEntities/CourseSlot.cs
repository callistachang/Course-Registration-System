using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class CourseSlot
    {
        private Slot _slot;
        private Course _course;

        #region Getters and Setters
        public Slot Slot
        {
            get { return _slot; }
            set
            {
                _slot = value;
                SlotId = _slot.Id;
            }
        }
        public string SlotId { get; private set; }
        public Course Course
        {
            get { return _course; }
            set
            {
                _course = value;
                CourseCode = _course.CourseCode;
            }
        }
        public string CourseCode { get; private set; }
        #endregion

        public CourseSlot() { }

        public CourseSlot(Course course, Slot slot)
        {
            _course = course;
            _slot = slot;
        }
    }
}
