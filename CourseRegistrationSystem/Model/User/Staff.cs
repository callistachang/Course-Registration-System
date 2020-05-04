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
        public string FullName { get; set; }
        public Sex Sex { get; set; }
        public List<Course> CoordinatorCourses { get; set; }
        public Account Account { get; set; }
        #endregion

        public Staff(string fullName, Sex sex)
        {
            Id = Utils.GenerateGuid();
            FullName = fullName;
            Sex = sex;
            CoordinatorCourses = new List<Course>();
            Account = null;
        }

        public string GetId()
        {
            return _id;
        }
    }
}
