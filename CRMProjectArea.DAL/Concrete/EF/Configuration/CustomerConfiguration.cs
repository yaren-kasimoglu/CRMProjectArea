using CRMProjectArea.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMProjectArea.DAL.Concrete.EF.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.CustomerId);
            builder.Property(x => x.Adress).HasMaxLength(1000);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x=>x.LastName).HasMaxLength(50);
            builder.Property(x=>x.BirthDate).HasDefaultValue(DateTime.Now);
        }
    }
}
