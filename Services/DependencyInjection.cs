using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Smart_ELearning.Services.Interfaces;

namespace Smart_ELearning.Services
{
    public static class DependencyInjection
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IQuestionService, QuestionSerive>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ISubmissionService, SubmissionService>();
            services.AddTransient<IAttendanceService, AttendanceService>();
            services.AddTransient<IIpService, IpService>();
        }
    }
}