﻿// <auto-generated />
using EmailSenderApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmailSenderApi.Migrations
{
    [DbContext(typeof(MailContext))]
    [Migration("20190406180538_Updated")]
    partial class Updated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmailSenderApi.Models.Mail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<string>("From")
                        .IsRequired();

                    b.Property<string>("Title");

                    b.Property<string>("To")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("EmailSenderApi.Models.Reciver", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("To")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Recivers");
                });
#pragma warning restore 612, 618
        }
    }
}