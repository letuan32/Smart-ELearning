using System.Collections.Generic;
using System.Threading.Tasks;
using Smart_ELearning.Models;

namespace Smart_ELearning.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<ICollection<SubjectModel>> GetAllAsync();

        ICollection<SubjectModel> GetAll();

        Task<int> Upsert(SubjectModel model);

        Task<int> Delete(int classId);

        Task<SubjectModel> GetById(int? classId);
    }
}