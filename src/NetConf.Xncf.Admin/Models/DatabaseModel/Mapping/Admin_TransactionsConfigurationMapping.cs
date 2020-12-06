using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Senparc.Ncf.Core.Models.DataBaseModel;
using Senparc.Ncf.XncfBase.Attributes;
using NetConf.Xncf.Admin.Models.DatabaseModel;

namespace NetConf.Xncf.Admin.Models
{
    [XncfAutoConfigurationMapping]
    public class Admin_TransactionsConfigurationMapping : ConfigurationMappingWithIdBase<Transactions, string>
    {
        public override void Configure(EntityTypeBuilder<Transactions> builder)
        {
            
        }
    }
}