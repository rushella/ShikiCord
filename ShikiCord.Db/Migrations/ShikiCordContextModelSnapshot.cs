// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShikiCord.Db;

#nullable disable

namespace ShikiCord.Db.Migrations
{
    [DbContext(typeof(ShikiCordContext))]
    partial class ShikiCordContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.2.22153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShikiCord.Db.Entities.User", b =>
                {
                    b.Property<decimal>("DiscordId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("numeric(20,0)");

                    b.Property<int?>("ShikimoriId")
                        .HasColumnType("integer");

                    b.HasKey("DiscordId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
