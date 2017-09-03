using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL;
using DAL.Contracts.Enumerations;

namespace DAL.Migrations
{
    [DbContext(typeof(HeroContext))]
    partial class HeroContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Hero");
                });

            modelBuilder.Entity("DAL.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int?>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });
        }
    }
}
