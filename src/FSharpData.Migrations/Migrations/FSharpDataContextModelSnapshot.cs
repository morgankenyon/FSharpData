﻿// <auto-generated />
using System;
using FSharpData.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FSharpData.Migrations.Migrations
{
    [DbContext(typeof(FSharpDataContext))]
    partial class FSharpDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FSharpData.Db.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("FSharpData.Db.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FSharpData.Db.Question", b =>
                {
                    b.HasOne("FSharpData.Db.User", "User")
                        .WithMany("Questions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
