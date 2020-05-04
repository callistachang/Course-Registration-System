using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Controller;

namespace CourseRegistrationSystem.Model
{
    public class Course : IModel
    {
        #region Instance Variables
        private string _courseCode;
        private int _yearTaught;
        private Staff _coordinator;

        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public School School { get; set; }
        /// <summary>
        /// The year that this course is to be taken in the recommended schedule.
        /// E.g. This course is typically taken in Year 2.
        /// </summary>
        public int YearTaught
        {
            get => _yearTaught;
            set
            {
                if (!Constants.IsValidStudyYear(value))
                {
                    Log.Error(5);
                    return;
                }
                _yearTaught = value;
            }
        }
        public Staff Coordinator
        {
            get { return _coordinator; }
            set
            {
                _coordinator = value;
                CoordinatorId = _coordinator.Id;
            }
        }
        public string CoordinatorId { get; private set; }
        /// <summary>
        /// Slots which can only be of type <seealso cref="Constants.CourseSlotTypes"/>.
        /// </summary>
        public List<CourseSlot> CourseSchedule { get; set; }
        public List<Class> Classes { get; set; }
        #endregion

        public Course() { }

        public Course(string courseCode, string name, string description, School school, int yearTaught, Staff coordinator, List<CourseSlot> courseSchedule, List<Class> classes)
        {
            CourseCode = courseCode;
            Name = name;
            Description = description;
            School = school;
            YearTaught = yearTaught;
            Coordinator = coordinator;
            CourseSchedule = courseSchedule;
            Classes = classes;
        }

        public string GetId()
        {
            return _courseCode;
        }
    }
}
