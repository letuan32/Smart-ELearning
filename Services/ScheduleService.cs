﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Smart_ELearning.Data;
using Smart_ELearning.Models;
using Smart_ELearning.Services.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;
using Smart_ELearning.ViewModels;

namespace Smart_ELearning.Services
{

    public class ScheduleService : IScheduleService
    {
        private readonly ApplicationDbContext _context;

        public ScheduleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ScheduleModel> GetAll()
        {
            
            var ojb = _context.ScheduleModels.Include(x=>x.ClassModel).Include(x=>x.SubjectModel);
            var ojbschedule = ojb.ToList();
            return ojbschedule;
        }

        public int Upsert(ScheduleViewModel model)
        {
            if (model.ScheduleModel.Id == 0)
            {
                _context.ScheduleModels.Add(model.ScheduleModel);
            }
            else
            {
                var scheduleFromDb =  _context.ScheduleModels.Find(model.ScheduleModel.Id);
                if (scheduleFromDb == null) throw new Exception($"Could not found class id{model.ScheduleModel.Id}");
                else
                {
                    _context.Entry<ScheduleModel>(scheduleFromDb).State = EntityState.Detached;
                    _context.Entry<ScheduleModel>(model.ScheduleModel).State = EntityState.Modified;
                }
            }

            return _context.SaveChanges();
        }
        

        public bool Delete(int Id)
        {
            var scheduleFromDb = _context.ScheduleModels.Find(Id);
            if (scheduleFromDb == null) throw new Exception($"Could not found class id {Id}");
            _context.ScheduleModels.Remove(scheduleFromDb);
            _context.SaveChanges();
            return true;
        }

        ScheduleModel IScheduleService.GetById(int? Id)
        {
            var scheduleFromDb = _context.ScheduleModels.Find(Id);
            if (scheduleFromDb == null) throw new Exception($"Not Found");
            return scheduleFromDb;
        }
        
    }
}