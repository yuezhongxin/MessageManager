using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using MessageManager.Domain.DomainModel;

namespace MessageManager.Repositories.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// Represents the entity type configuration for the <see cref="Customer"/> entity.
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        #region Ctor
        /// <summary>
        /// Initializes a new instance of <c>UserConfiguration</c> class.
        /// </summary>
        public UserConfiguration()
        {
            HasKey(c => c.ID);
            Property(c => c.ID)
                .IsRequired()
                .HasMaxLength(36)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
        #endregion
    }
}
