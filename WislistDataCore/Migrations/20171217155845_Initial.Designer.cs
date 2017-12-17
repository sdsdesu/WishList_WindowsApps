using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WislistDataCore.Models;

namespace WislistDataCore.Migrations
{
    [DbContext(typeof(WislistDataCoreContext))]
    [Migration("20171217155845_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WislistDataCore.Models.CategoryModel", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryID");

                    b.ToTable("CategoryModel");
                });

            modelBuilder.Entity("WislistDataCore.Models.ItemModel", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Categoryid");

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name");

                    b.Property<string>("WebLink");

                    b.Property<int>("WishListId");

                    b.HasKey("ItemId");

                    b.HasIndex("Categoryid");

                    b.HasIndex("WishListId");

                    b.ToTable("ItemModel");
                });

            modelBuilder.Entity("WislistDataCore.Models.UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.HasKey("UserId");

                    b.ToTable("UserModel");
                });

            modelBuilder.Entity("WislistDataCore.Models.WishListModel", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("ListId");

                    b.HasIndex("UserId");

                    b.ToTable("WishListModel");
                });

            modelBuilder.Entity("WislistDataCore.Models.ItemModel", b =>
                {
                    b.HasOne("WislistDataCore.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("Categoryid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WislistDataCore.Models.WishListModel", "WishList")
                        .WithMany("Items")
                        .HasForeignKey("WishListId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WislistDataCore.Models.WishListModel", b =>
                {
                    b.HasOne("WislistDataCore.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
