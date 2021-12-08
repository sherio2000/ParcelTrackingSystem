using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParcelTrackingSystem.Models;

namespace ParcelTrackingSystem.Data.Config
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.OwnsOne(o => o.CustomerAddress, a =>
            {
                a.WithOwner();
            });
        }
    }
}
