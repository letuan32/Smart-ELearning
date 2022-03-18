using System.Collections.Generic;
using System.Threading.Tasks;
using Smart_ELearning.ViewModels.AccountViewModels;

namespace Smart_ELearning.Services.Interfaces
{
    public interface IStudentService
    {
        Task<ICollection<StudentInClassVM>> GetStudentInClass(int classId);

        Task<int> AssignStudentToClass(AssignStudentToClassRequest request);

        Task<int> RemoveStudentInStudent(string studentId, int classId);
    }
}