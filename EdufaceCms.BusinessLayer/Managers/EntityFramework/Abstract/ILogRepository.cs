using EdufaceCms.DataAccessLayer.Abstract;
using EdufaceCms.Entities.Concrete;
using Microsoft.Extensions.Logging;
using System;

namespace EdufaceCms.BusinessLayer.Managers.EntityFramework.Abstract
{
    public interface ILogRepository:IGenericRepository<LogEntity>
    {
        void LogInfo(string message,string url, LogLevel level);
        void LogError(Exception ex, string url, LogLevel level);
    }
}
