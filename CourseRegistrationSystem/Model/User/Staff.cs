using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class Staff : IModel
    {
        private string _id;

        #region Instance Variables
        public readonly UserType userType = UserType.Staff;
        public string Id
        {
            get => GetId();
            private set => _id = value;
        }
        public List<Course> CoordinatorCourses { get; set; }
        public Account Account { get; set; }
        #endregion

        public Staff()
        {
            Id = Utils.GenerateGuid();
            CoordinatorCourses = new List<Course>();
            Account = null;
        }

        public string GetId()
        {
            return _id;
        }
    }
}
