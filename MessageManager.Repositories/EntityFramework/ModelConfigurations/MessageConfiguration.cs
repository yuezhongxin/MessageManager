using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using MessageManager.Domain.DomainModel;

namespace MessageManager.Repositories.EntityFramework.ModelConfigurations
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
                .HasMaxLength(36)
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
                .IsOptional();
            Property(c => c.IsRead)
                .IsRequired();
            ToTable("Messages");

            // Relationships
            this.HasRequired(t => t.FromUser)
                .WithMany(t => t.SendMessages)
                .HasForeignKey(t => t.FromUserID)
                .WillCascadeOnDelete(false);
            this.HasRequired(t => t.ToUser)
                .WithMany(t => t.ReceiveMessages)
                .HasForeignKey(t => t.ToUserID)
                .WillCascadeOnDelete(false);
        }
    }
}
