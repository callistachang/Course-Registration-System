using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CourseRegistrationSystem.Controller;

namespace CourseRegistrationSystem.Model
{
    public class Class : IModel
    {
        #region Instance Variables
        private string _indexNumber;
        private Course _course;
        public string IndexNumber
        {
            get { return GetId(); }
            private set { _indexNumber = value; }
        }
        public int MaxStudentCount { get; set; }
        public List<ClassStudent> Students { get; set; }
        public Course Course { 
            get { return _course; }
            set 
            { 
                _course = value; 
                CourseCode = _course.CourseCode; 
            }
        }
        public string CourseCode { get; private set; }
        /// <summary>
        /// See <seealso cref="Constants.IsClassSlotType(SlotType)"/>.
        /// </summary>
        public List<ClassSlot> ClassSchedule { get; set; }
        #endregion

        public Class() { }

        public Class(string indexNumber, int maxStudentCount, Course course)
        {
            IndexNumber = indexNumber;
            MaxStudentCount = maxStudentCount;
            Students = new List<ClassStudent>();
            Course = course;
            ClassSchedule = new List<ClassSlot>();
        }

        public string GetId()
        {
            return _indexNumber;
        }
    }
}
