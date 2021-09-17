﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smart_ELearning.Data;
using Smart_ELearning.Models;
using Smart_ELearning.Services.Interfaces;

namespace Smart_ELearning.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _context;

        public SubjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Upsert(SubjectModel model)
        {
            if (model.Id == 0)
            {
                _context.SubjectModels.Add(model);
            }
            else
            {
                var subFromDb = await _context.SubjectModels.FindAsync(model.Id);
                if (subFromDb == null) throw new Exception($"Could not found class id{model.Id}");
                else
                {
                    _context.Entry<SubjectModel>(subFromDb).State = EntityState.Detached;
                    _context.Entry<SubjectModel>(model).State = EntityState.Modified;
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int Id)
        {
            var subFromDb = await _context.SubjectModels.FindAsync(Id);
            if (subFromDb == null) throw new Exception($"Could not found class id{Id}");

            _context.SubjectModels.Remove(subFromDb);

            return await _context.SaveChangesAsync();
        }

        public List<SubjectModel> GetAll()
        {
            var query = _context.SubjectModels;
            var classes =  query.ToList();

            return classes;
        }

        public async Task<SubjectModel> GetById(int? classId)
        {
            var classModel = await _context.SubjectModels.FindAsync(classId);
            if (classModel == null) throw new Exception("Cound not found");

            return classModel;
        }
    }
}