using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class Staff : IUser
    {
        public string Username;

        public string GetUsername() => Username;

        public UserType GetUserType() => UserType.Staff;
    }
}
