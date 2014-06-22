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
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>ApplicationService</c>类型的实例。
        /// </summary>
        public ApplicationService()
        {
            Initialize();
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
