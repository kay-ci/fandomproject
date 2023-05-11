﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using UserInfo;

#nullable disable

namespace FandomApp.Migrations
{
    [DbContext(typeof(FanAppContext))]
    [Migration("20230509014154_AddedOwnerToEvents")]
    partial class AddedOwnerToEvents
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CategoryEvent", b =>
                {
                    b.Property<int>("CategoriesCategoryId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("eventsEventId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("CategoriesCategoryId", "eventsEventId");

                    b.HasIndex("eventsEventId");

                    b.ToTable("CategoryEvent");
                });

            modelBuilder.Entity("Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("MinAge")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("userID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EventId");

                    b.HasIndex("userID");

                    b.ToTable("FandomEvents");
                });

            modelBuilder.Entity("EventFandom", b =>
                {
                    b.Property<int>("EventsEventId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("FandomsFandomId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EventsEventId", "FandomsFandomId");

                    b.HasIndex("FandomsFandomId");

                    b.ToTable("EventFandom");
                });

            modelBuilder.Entity("EventUser", b =>
                {
                    b.Property<int>("AttendeesuserID")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EventsAttendingEventId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("AttendeesuserID", "EventsAttendingEventId");

                    b.HasIndex("EventsAttendingEventId");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("FandomUser", b =>
                {
                    b.Property<int>("FandomsFandomId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("FansuserID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("FandomsFandomId", "FansuserID");

                    b.HasIndex("FansuserID");

                    b.ToTable("FandomUser");
                });

            modelBuilder.Entity("UserInfo.Badge", b =>
                {
                    b.Property<int>("BadgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BadgeId"));

                    b.Property<string>("BadgeName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("BadgeId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FandomBadges");
                });

            modelBuilder.Entity("UserInfo.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Category_name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("CategoryId");

                    b.HasIndex("ProfileId");

                    b.ToTable("FandomCategories");
                });

            modelBuilder.Entity("UserInfo.Fandom", b =>
                {
                    b.Property<int>("FandomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FandomId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("ProfileId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("FandomId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Fandoms");
                });

            modelBuilder.Entity("UserInfo.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Seen")
                        .HasColumnType("NUMBER(1)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("Timesent")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int?>("UserMessageId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int?>("UserMessageId1")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Id");

                    b.HasIndex("UserMessageId");

                    b.HasIndex("UserMessageId1");

                    b.ToTable("FandomMessages");
                });

            modelBuilder.Entity("UserInfo.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"));

                    b.Property<int>("Age")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Interests")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Picture")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Pronouns")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("userID")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ProfileId");

                    b.HasIndex("userID")
                        .IsUnique();

                    b.ToTable("FandomProfiles");
                });

            modelBuilder.Entity("UserInfo.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"));

                    b.Property<byte[]>("Hash")
                        .IsRequired()
                        .HasColumnType("RAW(2000)");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("RAW(2000)");

                    b.Property<string>("Username")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("userID");

                    b.ToTable("FandomUsers");
                });

            modelBuilder.Entity("UserInfo.UserMessage", b =>
                {
                    b.Property<int>("UserMessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserMessageId"));

                    b.Property<int>("UserId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("UserMessageId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("FandomUserMessages");
                });

            modelBuilder.Entity("CategoryEvent", b =>
                {
                    b.HasOne("UserInfo.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event", null)
                        .WithMany()
                        .HasForeignKey("eventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Event", b =>
                {
                    b.HasOne("UserInfo.User", "Owner")
                        .WithMany("EventsCreated")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("EventFandom", b =>
                {
                    b.HasOne("Event", null)
                        .WithMany()
                        .HasForeignKey("EventsEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserInfo.Fandom", null)
                        .WithMany()
                        .HasForeignKey("FandomsFandomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventUser", b =>
                {
                    b.HasOne("UserInfo.User", null)
                        .WithMany()
                        .HasForeignKey("AttendeesuserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Event", null)
                        .WithMany()
                        .HasForeignKey("EventsAttendingEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FandomUser", b =>
                {
                    b.HasOne("UserInfo.Fandom", null)
                        .WithMany()
                        .HasForeignKey("FandomsFandomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserInfo.User", null)
                        .WithMany()
                        .HasForeignKey("FansuserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserInfo.Badge", b =>
                {
                    b.HasOne("UserInfo.Profile", null)
                        .WithMany("Badges")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("UserInfo.Category", b =>
                {
                    b.HasOne("UserInfo.Profile", null)
                        .WithMany("Categories")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("UserInfo.Fandom", b =>
                {
                    b.HasOne("UserInfo.Profile", null)
                        .WithMany("Fandoms")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("UserInfo.Message", b =>
                {
                    b.HasOne("UserInfo.UserMessage", null)
                        .WithMany("Inbox")
                        .HasForeignKey("UserMessageId");

                    b.HasOne("UserInfo.UserMessage", null)
                        .WithMany("Outbox")
                        .HasForeignKey("UserMessageId1");
                });

            modelBuilder.Entity("UserInfo.Profile", b =>
                {
                    b.HasOne("UserInfo.User", "user")
                        .WithOne("UserProfile")
                        .HasForeignKey("UserInfo.Profile", "userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("UserInfo.UserMessage", b =>
                {
                    b.HasOne("UserInfo.User", "user")
                        .WithOne("Messages")
                        .HasForeignKey("UserInfo.UserMessage", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("UserInfo.Profile", b =>
                {
                    b.Navigation("Badges");

                    b.Navigation("Categories");

                    b.Navigation("Fandoms");
                });

            modelBuilder.Entity("UserInfo.User", b =>
                {
                    b.Navigation("EventsCreated");

                    b.Navigation("Messages")
                        .IsRequired();

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("UserInfo.UserMessage", b =>
                {
                    b.Navigation("Inbox");

                    b.Navigation("Outbox");
                });
#pragma warning restore 612, 618
        }
    }
}
