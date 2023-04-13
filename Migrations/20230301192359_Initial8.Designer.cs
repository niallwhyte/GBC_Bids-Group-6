﻿// <auto-generated />
using System;
using GBC_Bids_Group_6.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GBC_Bids_Group_6.Migrations
{
    [DbContext(typeof(ItemContext))]
    [Migration("20230301192359_Initial8")]
    partial class Initial8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Automotive"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Beauty"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Books"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Collectablies"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Entertainment"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Health"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Garden"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Home"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Music"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Office"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Pets"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Tools"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Misc"
                        });
                });

            modelBuilder.Entity("GBC_Bids_Group_6.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conditions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Poor"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Okay"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Good"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Excellent"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mint"
                        });
                });

            modelBuilder.Entity("GBC_Bids_Group_6.Models.ItemAsset", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<DateTime>("AuctionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AuctionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ConditionID")
                        .HasColumnType("int");

                    b.Property<double>("CurrentPrice")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MinimumBidAmount")
                        .HasColumnType("int");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("verified")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            id = 1,
                            email = "",
                            password = "buyer",
                            userType = "Client",
                            username = "buyer",
                            verified = true
                        },
                        new
                        {
                            id = 2,
                            email = "",
                            password = "seller",
                            userType = "Client",
                            username = "seller",
                            verified = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
