using MessageManager.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

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
            Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(50);
            Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(2000);
            Property(c => c.SendTime)
                .IsRequired();

            // Relationships
            //HasRequired(x => x.SendAccount)
            //    .WithMany()
            //    .Map(x => x.MapKey("SendAccountID"))
            //    .WillCascadeOnDelete(false);
            //HasRequired(x => x.ReceiveAccount)
            //    .WithMany()
            //    .Map(x => x.MapKey("ReceiveAccountID"))
            //    .WillCascadeOnDelete(false);
        }
    }
}
