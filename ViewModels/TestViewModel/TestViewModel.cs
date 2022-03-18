using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Smart_ELearning.Models;

namespace Smart_ELearning.ViewModels
{
    public class TestViewModel
    {
        public TestModel TestModel { get; set; }
        public IEnumerable<SelectListItem> ScheduleListItems { get; set; }
    }
}