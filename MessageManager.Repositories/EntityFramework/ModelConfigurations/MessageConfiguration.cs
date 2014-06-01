using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using MessageManager.Domain.DomainModel;

namespace MessageManager.Domain.Repositories.EntityFramework.ModelConfigurations
{
    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        /// <summary>
        /// Initializes a new instance of <c>MessageConfiguration</c> class.
        /// </summary>
        public MessageConfiguration()
        {
            HasKey(c => c.ID);
            Property(c => c.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.FromUserID)
                .IsRequired()
                .HasMaxLength(36);
            Property(c => c.ToUserID)
                .IsRequired()
                .HasMaxLength(36);
            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(2000);
            Property(c => c.SendTime)
                .IsRequired();
            Property(c => c.ReceiveTime)
                .IsRequired();
            Property(c => c.IsRead)
                .IsRequired();
            ToTable("Messages");
        }
    }
}
