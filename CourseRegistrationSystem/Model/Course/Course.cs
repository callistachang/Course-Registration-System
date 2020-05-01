using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Controller;

namespace CourseRegistrationSystem.Model
{
    public class Course
    {
        private string CourseCode;
        private string Name;
        private string Description;
        /// <summary>
        /// The year that this course is to be taken in the recommended schedule.
        /// E.g. This course is typically taken in Year 2.
        /// </summary>
        private int YearTaught;
        private Staff Coordinator;
        private School School;
        private SlotManager LectureSchedule;
        private SlotManager TestSchedule;

        private ClassManager ClassManager;

        public Course()
        {
            ClassManager = new ClassManager();
        }
    }
}
