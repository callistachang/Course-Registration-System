using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Controller
{
    public interface IDatabaseManager<T>
    {
        public bool Get(string identifier, out T obj);
    }
}
