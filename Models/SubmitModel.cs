﻿namespace Smart_ELearning.Models
{
    public class SubmitModel
    {
        public int Id { get; set; }
        public int ScheduleId { get; set; }
        public string UserId { get; set; }
        public int TestId { get; set; }
        public int NumberOfCorrectAnswer { get; set; }
        public string ListAnswer { get; set; }
        public double TotalGrade { get; set; }
    }
}