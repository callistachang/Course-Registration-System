using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRegistrationSystem.Model
{
    public class ClassSlot
    {
        private Slot _slot;
        private Class _class;

        #region Getters and Setters
        public Slot Slot
        {
            get { return _slot; }
            set
            {
                _slot = value;
                SlotId = _slot.Id;
            }
        }
        public string SlotId { get; private set; }
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
