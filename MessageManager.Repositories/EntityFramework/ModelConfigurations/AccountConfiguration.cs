using MessageManager.Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MessageManager.Repositories.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// Represents the entity type configuration for the <see cref="Customer"/> entity.
    /// </summary>
    public class AccountConfiguration : EntityTypeConfiguration<Account>
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of <c>AccountConfiguration</c> class.
        /// </summary>
        public AccountConfiguration()
        {
            HasKey(c => c.ID);
            Property(c => c.ID)
                .IsRequired()
                .HasMaxLength(36)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.LoginName)
                .IsRequired()
                .HasMaxLength(20);
            Property(c => c.DisplayName)
                .IsRequired()
                .HasMaxLength(20);
        }
        #endregion
    }
}
