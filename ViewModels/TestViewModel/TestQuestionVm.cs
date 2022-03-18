using System.Collections.Generic;
using Smart_ELearning.Models;

namespace Smart_ELearning.ViewModels
{
    public class TestQuestionVm
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<QuestionModel> question { get; set; }
    }
}