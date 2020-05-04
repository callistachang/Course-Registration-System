using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class ClassStudent
    {
        private Student _student;
        private Class _class;

        #region Getters and Setters
        public Student Student
        {
            get { return _student; }
            set
            {
                _student = value;
                MatricNumber = _student.MatricNumber;
            }
        }
        public string MatricNumber { get; private set; }
        public Class @Class
        {
            get { return _class; }
            set
            {
                _class = value;
                ClassIndex = _class.IndexNumber;
            }
        }
        public string ClassIndex { get; private set; }
        #endregion
    }
}
