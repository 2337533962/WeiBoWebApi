using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiBoWebApi.Controllers
{
    /// <summary>
    /// hub控制器(测试阶段)
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HubController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _countHub;
        public HubController(IHubContext<ChatHub> countHub)
        {
            _countHub = countHub;
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        /// <param name="msg">发送的消息</param>
        /// <param name="id">发送者Id</param>
        [HttpGet]
        public async Task Send(string msg, string id)
        {
            await _countHub.Clients.All.SendAsync("AddMsg", $"{id}：{msg}");
        }
    }
}
