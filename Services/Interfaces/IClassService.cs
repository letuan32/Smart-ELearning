using System.Collections.Generic;
using System.Threading.Tasks;
using Smart_ELearning.Models;

namespace Smart_ELearning.Services.Interfaces
{
    public interface IClassService
    {
        List<ClassModel> GetAll();

        int Upsert(ClassModel model);

        Task<int> Delete(int classId);

        Task<ClassModel> GetByIdAsync(int classId);

        ClassModel GetById(int classId);
    }
}