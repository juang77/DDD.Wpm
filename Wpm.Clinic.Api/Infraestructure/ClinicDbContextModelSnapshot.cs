﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wpm.Clinic.Api.Infraestructure;

#nullable disable

namespace Wpm.Clinic.Api.Infraestructure
{
    [DbContext(typeof(ClinicDbContext))]
    partial class ClinicDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Clinic")
                .HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("Wpm.Clinic.Domain.Entities.Consultation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ConsultationEnd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ConsultationStart")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Consultation", "Clinic");
                });

            modelBuilder.Entity("Wpm.Clinic.Domain.Entities.Consultation", b =>
                {
                    b.OwnsOne("Wpm.Clinic.Domain.ValueObjects.Text", "Diagnosis", b1 =>
                        {
                            b1.Property<Guid>("ConsultationId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ConsultationId");

                            b1.ToTable("Consultation", "Clinic");

                            b1.WithOwner()
                                .HasForeignKey("ConsultationId");
                        });

                    b.OwnsOne("Wpm.Clinic.Domain.ValueObjects.Text", "Treatment", b1 =>
                        {
                            b1.Property<Guid>("ConsultationId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("ConsultationId");

                            b1.ToTable("Consultation", "Clinic");

                            b1.WithOwner()
                                .HasForeignKey("ConsultationId");
                        });

                    b.OwnsMany("Wpm.Clinic.Domain.Entities.DrugAdministration", "AdministeredDrugs", b1 =>
                        {
                            b1.Property<Guid>("ConsultationId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("TEXT");

                            b1.HasKey("ConsultationId", "Id");

                            b1.ToTable("DrugAdministration", "Clinic");

                            b1.WithOwner()
                                .HasForeignKey("ConsultationId");

                            b1.OwnsOne("Wpm.Clinic.Domain.ValueObjects.Dose", "Dose", b2 =>
                                {
                                    b2.Property<Guid>("DrugAdministrationConsultationId")
                                        .HasColumnType("TEXT");

                                    b2.Property<Guid>("DrugAdministrationId")
                                        .HasColumnType("TEXT");

                                    b2.Property<decimal>("Quantity")
                                        .HasColumnType("TEXT");

                                    b2.Property<int>("Unit")
                                        .HasColumnType("INTEGER");

                                    b2.HasKey("DrugAdministrationConsultationId", "DrugAdministrationId");

                                    b2.ToTable("DrugAdministration", "Clinic");

                                    b2.WithOwner()
                                        .HasForeignKey("DrugAdministrationConsultationId", "DrugAdministrationId");
                                });

                            b1.OwnsOne("Wpm.Clinic.Domain.ValueObjects.DrugId", "DrugId", b2 =>
                                {
                                    b2.Property<Guid>("DrugAdministrationConsultationId")
                                        .HasColumnType("TEXT");

                                    b2.Property<Guid>("DrugAdministrationId")
                                        .HasColumnType("TEXT");

                                    b2.Property<Guid>("Value")
                                        .HasColumnType("TEXT");

                                    b2.HasKey("DrugAdministrationConsultationId", "DrugAdministrationId");

                                    b2.ToTable("DrugAdministration", "Clinic");

                                    b2.WithOwner()
                                        .HasForeignKey("DrugAdministrationConsultationId", "DrugAdministrationId");
                                });

                            b1.Navigation("Dose")
                                .IsRequired();

                            b1.Navigation("DrugId")
                                .IsRequired();
                        });

                    b.OwnsMany("Wpm.Clinic.Domain.Entities.VitalSigns", "VitalSignsReadings", b1 =>
                        {
                            b1.Property<Guid>("ConsultationId")
                                .HasColumnType("TEXT");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("TEXT");

                            b1.Property<int>("HeartRate")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime>("ReadingDateTime")
                                .HasColumnType("TEXT");

                            b1.Property<int>("RespiratoryRate")
                                .HasColumnType("INTEGER");

                            b1.Property<decimal>("Temperature")
                                .HasColumnType("TEXT");

                            b1.HasKey("ConsultationId", "Id");

                            b1.ToTable("VitalSigns", "Clinic");

                            b1.WithOwner()
                                .HasForeignKey("ConsultationId");
                        });

                    b.OwnsOne("Wpm.SharedKernel.Weight", "CurrentWeight", b1 =>
                        {
                            b1.Property<Guid>("ConsultationId")
                                .HasColumnType("TEXT");

                            b1.Property<decimal>("Value")
                                .HasColumnType("TEXT");

                            b1.HasKey("ConsultationId");

                            b1.ToTable("Consultation", "Clinic");

                            b1.WithOwner()
                                .HasForeignKey("ConsultationId");
                        });

                    b.Navigation("AdministeredDrugs");

                    b.Navigation("CurrentWeight");

                    b.Navigation("Diagnosis");

                    b.Navigation("Treatment");

                    b.Navigation("VitalSignsReadings");
                });
#pragma warning restore 612, 618
        }
    }
}
