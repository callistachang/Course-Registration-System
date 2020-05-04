using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class Slot : IModel
    {
        private string _id;

        #region Getters and Setters
        public string Id {
            get => GetId();
            private set => _id = value;
        }
        public string Venue { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        #endregion

        public Slot()
        {
        }

        public Slot(string venue, DayOfWeek dayOfWeek, TimeSpan startTime, TimeSpan endTime)
        {
            Id = Utils.GenerateGuid();
            Venue = venue;
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
        }

        public string GetId()
        {
            return _id;
        }
    }
}
