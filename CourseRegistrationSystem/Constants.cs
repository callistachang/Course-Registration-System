using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistrationSystem.Model;

namespace CourseRegistrationSystem
{
    public class Constants
    {
        public static Dictionary<int, string> ErrorMessages = new Dictionary<int, string>();

        public static string GetMessage(int messageId)
        {
            if (ErrorMessages.ContainsKey(messageId))
                return ErrorMessages[messageId];
            else
                return null;
        }

        public static bool IsValidStudyYear(int studyYear)
        {
            return studyYear >= 1 && studyYear <= 7;
        }

        public static bool IsCourseSlotType(SlotType slotType)
        {
            return slotType == SlotType.Lecture || slotType == SlotType.Test;
        }

        public static bool IsClassSlotType(SlotType slotType)
        {
            return slotType == SlotType.Tutorial || slotType == SlotType.Laboratory;
        }
    }
}
