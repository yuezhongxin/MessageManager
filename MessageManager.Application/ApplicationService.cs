/**
* author:xishuai
* address:https://www.github.com/yuezhongxin/MessageManager
**/

using AutoMapper;
using MessageManager.Application.DTO;
using MessageManager.Domain.Entity;
using MessageManager.Domain.Repositories;
using MessageManager.Domain.ValueObject;

namespace MessageManager.Application
{
    /// <summary>
    /// 表示应用层服务的抽象类。
    /// </summary>
    public abstract class ApplicationService
    {
        #region Private Fields
        private readonly IRepositoryContext context;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>ApplicationService</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>ApplicationService</c>类型的仓储上下文实例。</param>
        public ApplicationService(IRepositoryContext context)
        {
            this.context = context;
        }
        #endregion

        #region Protected Properties
        /// <summary>
        /// 获取当前应用层服务所使用的仓储上下文实例。
        /// </summary>
        protected IRepositoryContext Context
        {
            get { return this.context; }
        }
        #endregion

        #region Public Static Methods
        /// <summary>
        /// 对应用层服务进行初始化。
        /// </summary>
        /// <remarks>包含的初始化任务有：
        /// 1. AutoMapper框架的初始化</remarks>
        public static void Initialize()
        {
            //Mapper.CreateMap<ContactDTO, Contact>();
            Mapper.CreateMap<Contact, ContactDTO>();
            //Mapper.CreateMap<MessageDTO, Message>();
            Mapper.CreateMap<Message, MessageDTO>()
                .ForMember(dest => dest.State, opt => opt.ResolveUsing<MessageStateCustomResolver>());
        }
        public class MessageStateCustomResolver : ValueResolver<Message, string>
        {
            protected override string ResolveCore(Message source)
            {
                switch (source.State)
                {
                    case MessageState.Unread:
                        return "未读";
                    case MessageState.Read:
                        return "已读";
                    default:
                        return "未读";
                }
            }
        }
        #endregion
    }
}
