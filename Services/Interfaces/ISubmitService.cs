using System.Collections.Generic;
using Smart_ELearning.Models;

namespace Smart_ELearning.Services.Interfaces
{
    public interface IIpService
    {
        List<IpInfo> GetAll();

        List<IpInfo> GetWhiteList();

        List<IpInfo> GetBlockList();

        int ChangeStatus(int id);
    }
}