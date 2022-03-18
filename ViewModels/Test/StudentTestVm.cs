using System.Collections.Generic;

namespace Smart_ELearning.ViewModels.Test
{
    public class StudentTestVm
    {
        public int ScheduleId { get; set; }
        public int TestId { get; set; }
        public string TestTitle { get; set; }
        public int NumberOfQuestion { get; set; }
        public string StudentIp { get; set; }

        public List<StudentQuestionVm> QuestionsResult { get; set; }
    }
}