﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SFA.DAS.Config.Database;

namespace SFA.DAS.Config.Database.Migrations
{
    [DbContext(typeof(ConfigDbContext))]
    [Migration("20190524141700_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SFA.DAS.Config.Database.TenantGroup", b =>
                {
                    b.Property<Guid>("TenantGroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName");

                    b.Property<Guid>("TenantObjectId");

                    b.HasKey("TenantGroupId");

                    b.HasIndex("TenantObjectId");

                    b.ToTable("TenantGroups");
                });

            modelBuilder.Entity("SFA.DAS.Config.Database.TenantGroupMembership", b =>
                {
                    b.Property<Guid>("TenantGroupId");

                    b.Property<Guid>("TenantObjectId");

                    b.HasKey("TenantGroupId", "TenantObjectId");

                    b.HasIndex("TenantObjectId");

                    b.ToTable("TenantGroupMembership");
                });

            modelBuilder.Entity("SFA.DAS.Config.Database.TenantObject", b =>
                {
                    b.Property<Guid>("TenantObjectId")
                        .ValueGeneratedOnAdd();

                    b.HasKey("TenantObjectId");

                    b.ToTable("TenantObjects");
                });

            modelBuilder.Entity("SFA.DAS.Config.Database.TenantUser", b =>
                {
                    b.Property<Guid>("TenantUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("TenantObjectId");

                    b.HasKey("TenantUserId");

                    b.HasIndex("TenantObjectId");

                    b.ToTable("TenantUsers");
                });

            modelBuilder.Entity("SFA.DAS.Config.Database.TenantGroup", b =>
                {
                    b.HasOne("SFA.DAS.Config.Database.TenantObject", "TenantObject")
                        .WithMany()
                        .HasForeignKey("TenantObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SFA.DAS.Config.Database.TenantGroupMembership", b =>
                {
                    b.HasOne("SFA.DAS.Config.Database.TenantGroup", "TenantGroup")
                        .WithMany("TenantGroupMembers")
                        .HasForeignKey("TenantGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SFA.DAS.Config.Database.TenantObject", "TenantObjectMember")
                        .WithMany("TenantGroupMemberships")
                        .HasForeignKey("TenantObjectId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("SFA.DAS.Config.Database.TenantUser", b =>
                {
                    b.HasOne("SFA.DAS.Config.Database.TenantObject", "TenantObject")
                        .WithMany()
                        .HasForeignKey("TenantObjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}