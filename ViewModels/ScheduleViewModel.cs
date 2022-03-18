using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart_ELearning.Models;

namespace Smart_ELearning.ViewModels
{
    public class ScheduleViewModel
    {
        public ScheduleModel ScheduleModel { get; set; }
        public IEnumerable<SelectListItem> ClassListItems { get; set; }
        public IEnumerable<SelectListItem> SubjectListItems { get; set; }
    }
}