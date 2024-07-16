﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCity.DataAccess;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyCity.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyCity.Core.Domain.CustomStop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLocked")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_locked");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<Guid?>("LockedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("locked_by");

                    b.Property<Guid>("PointOfInterestId")
                        .HasColumnType("uuid")
                        .HasColumnName("point_of_interest_id");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uuid")
                        .HasColumnName("route_id");

                    b.HasKey("Id")
                        .HasName("pk_custom_stops");

                    b.HasIndex("RouteId")
                        .HasDatabaseName("ix_custom_stops_route_id");

                    b.ToTable("custom_stops", (string)null);
                });

            modelBuilder.Entity("MyCity.Core.Domain.MediaFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<Guid?>("CustomStopId")
                        .HasColumnType("uuid")
                        .HasColumnName("custom_stop_id");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLocked")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_locked");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<Guid?>("LockedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("locked_by");

                    b.Property<int>("MediaFileType")
                        .HasColumnType("integer")
                        .HasColumnName("media_file_type");

                    b.Property<Guid?>("PointOfInterestId")
                        .HasColumnType("uuid")
                        .HasColumnName("point_of_interest_id");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("uri");

                    b.HasKey("Id")
                        .HasName("pk_media_files");

                    b.HasIndex("CustomStopId")
                        .HasDatabaseName("ix_media_files_custom_stop_id");

                    b.HasIndex("PointOfInterestId")
                        .HasDatabaseName("ix_media_files_point_of_interest_id");

                    b.ToTable("media_files", (string)null);
                });

            modelBuilder.Entity("MyCity.Core.Domain.PointOfInterest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("contact_info");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLocked")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_locked");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<Guid?>("LockedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("locked_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("version");

                    b.HasKey("Id")
                        .HasName("pk_point_of_interests");

                    b.ToTable("point_of_interests", (string)null);
                });

            modelBuilder.Entity("MyCity.Core.Domain.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLocked")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_locked");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<Guid?>("LockedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("locked_by");

                    b.Property<Guid?>("PointOfInterestId")
                        .HasColumnType("uuid")
                        .HasColumnName("point_of_interest_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid?>("RouteId")
                        .HasColumnType("uuid")
                        .HasColumnName("route_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("text");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("PointOfInterestId")
                        .HasDatabaseName("ix_reviews_point_of_interest_id");

                    b.HasIndex("RouteId")
                        .HasDatabaseName("ix_reviews_route_id");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("MyCity.Core.Domain.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLocked")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_locked");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<Guid?>("LockedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("locked_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("MyCity.Core.Domain.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLocked")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_locked");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<Guid?>("LockedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("locked_by");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_routes");

                    b.ToTable("routes", (string)null);
                });

            modelBuilder.Entity("MyCity.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<bool>("AgreeOnPersonalDataProcessing")
                        .HasColumnType("boolean")
                        .HasColumnName("agree_on_personal_data_processing");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("created_by");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_created");

                    b.Property<DateTime?>("DateLocked")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_locked");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("last_name");

                    b.Property<Guid?>("LockedBy")
                        .HasColumnType("uuid")
                        .HasColumnName("locked_by");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("middle_name");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)")
                        .HasColumnName("nickname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_users_role_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("MyCity.Core.Domain.CustomStop", b =>
                {
                    b.HasOne("MyCity.Core.Domain.Route", null)
                        .WithMany("CustomStops")
                        .HasForeignKey("RouteId")
                        .HasConstraintName("fk_custom_stops_routes_route_id");
                });

            modelBuilder.Entity("MyCity.Core.Domain.MediaFile", b =>
                {
                    b.HasOne("MyCity.Core.Domain.CustomStop", null)
                        .WithMany("MediaFiles")
                        .HasForeignKey("CustomStopId")
                        .HasConstraintName("fk_media_files_custom_stops_custom_stop_id");

                    b.HasOne("MyCity.Core.Domain.PointOfInterest", null)
                        .WithMany("MediaFiles")
                        .HasForeignKey("PointOfInterestId")
                        .HasConstraintName("fk_media_files_point_of_interests_point_of_interest_id");
                });

            modelBuilder.Entity("MyCity.Core.Domain.Review", b =>
                {
                    b.HasOne("MyCity.Core.Domain.PointOfInterest", null)
                        .WithMany("Reviews")
                        .HasForeignKey("PointOfInterestId")
                        .HasConstraintName("fk_reviews_point_of_interests_point_of_interest_id");

                    b.HasOne("MyCity.Core.Domain.Route", null)
                        .WithMany("Reviews")
                        .HasForeignKey("RouteId")
                        .HasConstraintName("fk_reviews_routes_route_id");
                });

            modelBuilder.Entity("MyCity.Core.Domain.User", b =>
                {
                    b.HasOne("MyCity.Core.Domain.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fk_users_roles_role_id");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("MyCity.Core.Domain.CustomStop", b =>
                {
                    b.Navigation("MediaFiles");
                });

            modelBuilder.Entity("MyCity.Core.Domain.PointOfInterest", b =>
                {
                    b.Navigation("MediaFiles");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MyCity.Core.Domain.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("MyCity.Core.Domain.Route", b =>
                {
                    b.Navigation("CustomStops");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
