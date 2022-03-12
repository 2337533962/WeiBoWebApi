using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeiBoWebApi.Model;

namespace WeiBoWebApi.DAL
{
    /// <summary>
    /// DBContextFactory 单例工厂
    /// </summary>
    public class DBContextFactory
    {
        private static WeiBoDBContext _dbContext = null;
        private DBContextFactory()
        {

        }
        public static WeiBoDBContext GetContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new WeiBoDBContext();
                // 关闭跟踪
                //_dbContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            }
            return _dbContext;
        }
    }
}
