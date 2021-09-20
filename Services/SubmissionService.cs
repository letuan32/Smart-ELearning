﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Smart_ELearning.Data;
using Smart_ELearning.Models;
using Smart_ELearning.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Smart_ELearning.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubmissionService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public int CheckFakeAddress()
        {
            string userIp = this.GetIpAddress();
            int isFake = 0;
            string info = new WebClient().DownloadString("https://v2.api.iphub.info/guest/ip/14.243.128.251" + "?c=Fae9gi8a");
            var ipInfo = JsonConvert.DeserializeObject<dynamic>(info);
            if (ipInfo.block == 1 || ipInfo.block == 2)
            {
                isFake = 1;
            }

            return isFake;
        }

        public string GetIpAddress()
        {
            string userIp = "unknow";
            try
            {
                userIp = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            catch (Exception ex)
            {
            }
            return userIp;
        }

        public int IsDuplicate(int testId)
        {
            int isDuplicate = 0;
            string userIp = this.GetIpAddress();
            // Dùng tạm ip cố định
            var record = _context.submitModels.Where(x => x.TestId == testId).Where(x => x.UserIp == "14.243.128.251").First();
            if (record != null)
            {
                isDuplicate = 1;
            }
            return isDuplicate;
        }
    }
}