using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Smart_ELearning.Data;
using Smart_ELearning.Models;
using Smart_ELearning.Services.Interfaces;

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
            var userIp = GetIpAddress();
            var isFake = 0;
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.AppUserModels.Find(userId);
            // Check if Ip in white list
            var isInIpList = _context.IpInfos.FirstOrDefault(x => x.StudentId == user.SpecificId && x.Ip == userIp);
            if (isInIpList != null && isInIpList.IsBlock != true) return 0;

            var info = new WebClient().DownloadString("https://v2.api.iphub.info/guest/ip/" + userIp + "?c=Fae9gi8a");
            var ipInfo = JsonConvert.DeserializeObject<dynamic>(info);
            if (ipInfo.block == 1 || ipInfo.block == 2)
            {
                isFake = 1;
                if (isInIpList == null)
                {
                    var model = new IpInfo
                    {
                        Ip = userIp,
                        StudentId = user.SpecificId,
                        IsBlock = true,
                        LimitAccount = 0
                    };
                    _context.IpInfos.Add(model);
                    _context.SaveChanges();
                }
            }

            return isFake;
        }

        public int Delete(int id)
        {
            var submit = _context.submitModels.Find(id);
            _context.submitModels.Remove(submit);
            return _context.SaveChanges();
        }

        public SubmitModel GetById(int id)
        {
            var model = _context.submitModels.Find(id);
            return model;
        }

        public string GetIpAddress()
        {
            var userIp = "unknow";
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
            var isDuplicate = 0;
            var userIp = GetIpAddress();
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.AppUserModels.Find(userId);

            var record = _context.submitModels.Where(x => x.TestId == testId)
                .Where(x => x.UserIp == userIp || x.UserId == userId);

            if (record.Count() == 0)
            {
                isDuplicate = 0;
                return isDuplicate;
            }

            var isWhiteList = _context.IpInfos.FirstOrDefault(x => x.StudentId == user.SpecificId && x.Ip == userIp);
            if (isWhiteList != null && isWhiteList.IsBlock == false)
                foreach (var item in record)
                    if (item.UserId == userId)
                        return 1;
            if (isWhiteList != null && isWhiteList.IsBlock)
                return isDuplicate = 1;
            if (isWhiteList == null)
            {
                var model = new IpInfo
                {
                    Ip = userIp,
                    StudentId = user.SpecificId,
                    IsBlock = true,
                    LimitAccount = 0
                };
                _context.IpInfos.Add(model);
                _context.SaveChanges();
                return isDuplicate = 1;
            }

            return isDuplicate;
        }

        public int IsExpired(int testId)
        {
            var status = _context.TestModels.Find(testId).Status;
            if (status == false)
                return 1;
            return 0;
        }
    }
}