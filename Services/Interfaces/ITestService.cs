﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Smart_ELearning.Models;
using Smart_ELearning.ViewModels;

namespace Smart_ELearning.Services.Interfaces
{
    public interface ITestService
    {
        List<TestModel> GetAll();

        int Upsert(TestViewModel testViewModel);

        bool Delete(int classId);

        TestModel GetById(int? classId);
    }
}