using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Persistence.Configurations
{
    public class HistoryConfiguration : EntityTypeConfiguration<Entities.History>
    {
        public HistoryConfiguration()
        {

            SetColumnProperties();
            SetPrimaryKey();
        }

        private void SetPrimaryKey()
        {
            HasKey(r => r.HistoryId);
        }

        private void SetColumnProperties()
        {
            ToTable("History", "dbo");

            Property(r => r.HistoryId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(r => r.SharesId).IsRequired();
            Property(r => r.High).IsRequired();
            Property(r => r.Close).IsRequired();
            Property(r => r.Open).IsRequired();
            Property(r => r.Low).IsRequired();
            Property(r => r.DDate).IsRequired();
            this.HasOptional(x => x.Shares).WithMany().HasForeignKey(x => x.SharesId);

        }
    }
}
