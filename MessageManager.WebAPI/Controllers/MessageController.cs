/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using MessageManager.Application;
using MessageManager.Application.DTO;
using MessageManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageManager.WebAPI.Controllers
{
    public class MessageController : ApiController
    {
        #region 应用层服务接口
        private readonly IMessageService messageServiceImpl = ServiceLocator.Instance.GetService<IMessageService>();
        #endregion

        #region 消息操作
        /// <summary>
        /// 通过发送方获取消息列表
        /// </summary>
        /// <param name="userName">发送方</param>
        /// <returns>消息列表</returns>
        [HttpGet]
        public IEnumerable<MessageDTO> GetMessagesBySendUser(string userName)
        {
            UserDTO userDTO = new UserDTO { Name = userName };
            var messages = messageServiceImpl.GetMessagesBySendUser(userDTO);
            return messages;
        }
        /// <summary>
        /// 通过接受方获取消息列表
        /// </summary>
        /// <param name="userName">接受方</param>
        /// <returns>消息列表</returns>
        [HttpGet]
        public IEnumerable<MessageDTO> GetMessagesByReceiveUser(string userName)
        {
            UserDTO userDTO = new UserDTO { Name = userName };
            var messages = messageServiceImpl.GetMessagesByReceiveUser(userDTO);
            return messages;
        }
        /// <summary>
        /// 获取未读消息数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpGet]
        public int GetNoReadCount(string userName)
        {
            UserDTO userDTO = new UserDTO { Name = userName };
            return messageServiceImpl.GetNoReadCount(userDTO);
        }
        #endregion

        #region 示例action
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}