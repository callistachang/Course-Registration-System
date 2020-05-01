using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public interface IUser
    {
        public string GetUniqueId();
        public UserType GetUserType();
    }
}
