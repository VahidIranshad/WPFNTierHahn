using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Persistence.Configurations
{
    public class SharesConfiguration : EntityTypeConfiguration<Entities.Shares>
    {

        public SharesConfiguration()
        {
            SetColumnProperties();
            SetPrimaryKey();
        }

        private void SetPrimaryKey()
        {
            HasKey(r => r.SharesId);
        }

        private void SetColumnProperties()
        {
            ToTable("Shares", "dbo");

            Property(r => r.SharesId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(r => r.Name).HasMaxLength(200).IsRequired();
            Property(r => r.Symbol).HasMaxLength(10).IsRequired();
            Property(r => r.CreatedTime).IsRequired();
            Property(r => r.UpdatedTime).IsRequired();

        }
    }
}
