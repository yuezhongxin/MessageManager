using System.Linq;
using AutoMapper;
using MessageManager.Application.DTO;
using MessageManager.Domain.DomainModel;
using MessageManager.Domain.Repositories;
using System.Configuration;

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
            Initialize();
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
            Mapper.CreateMap<UserDTO, User>();
            Mapper.CreateMap<MessageDTO, Message>();
            Mapper.CreateMap<User, UserDTO>();
            Mapper.CreateMap<Message, MessageDTO>()
                .ForMember(dest => dest.Status, opt => opt.ResolveUsing<CustomResolver>());
        }
        public class CustomResolver : ValueResolver<Message, string>
        {
            protected override string ResolveCore(Message source)
            {
                if (source.IsRead)
                {
                    return "已读";
                }
                else
                {
                    return "未读";
                }
            }
        }
        #endregion
    }
}
