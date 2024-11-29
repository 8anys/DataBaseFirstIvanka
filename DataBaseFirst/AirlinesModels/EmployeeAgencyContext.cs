using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.AirlinesModels;

public partial class EmployeeAgencyContext : DbContext
{
    public EmployeeAgencyContext()
    {
    }

    public EmployeeAgencyContext(DbContextOptions<EmployeeAgencyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adre> Adres { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<ContactType> ContactTypes { get; set; }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<EducationLevel> EducationLevels { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<PersonContact> PersonContacts { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Speciality> Specialities { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=Maroon52015;Database=employee_agency;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adre>(entity =>
        {
            entity.HasKey(e => e.AdresId).HasName("PRIMARY");

            entity.ToTable("adres");

            entity.HasIndex(e => e.CityId, "city_id");

            entity.HasIndex(e => e.DistrictId, "district_id");

            entity.HasIndex(e => e.StreetId, "street_id");

            entity.Property(e => e.AdresId).HasColumnName("adres_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.StreetId).HasColumnName("street_id");

            entity.HasOne(d => d.City).WithMany(p => p.Adres)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("adres_ibfk_1");

            entity.HasOne(d => d.District).WithMany(p => p.Adres)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("adres_ibfk_2");

            entity.HasOne(d => d.Street).WithMany(p => p.Adres)
                .HasForeignKey(d => d.StreetId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("adres_ibfk_3");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("city");

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CityName)
                .HasMaxLength(30)
                .HasColumnName("city_name");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PRIMARY");

            entity.ToTable("company");

            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.CompanyFullName)
                .HasMaxLength(100)
                .HasColumnName("company_full_name");
            entity.Property(e => e.CompanyShortName)
                .HasMaxLength(100)
                .HasColumnName("company_short_name");
        });

        modelBuilder.Entity<ContactType>(entity =>
        {
            entity.HasKey(e => e.ContactTypeId).HasName("PRIMARY");

            entity.ToTable("contact_type");

            entity.HasIndex(e => e.ContactType1, "contact_type").IsUnique();

            entity.Property(e => e.ContactTypeId).HasColumnName("contact_type_id");
            entity.Property(e => e.ContactType1)
                .HasMaxLength(30)
                .HasColumnName("contact_type");
        });

        modelBuilder.Entity<Departament>(entity =>
        {
            entity.HasKey(e => e.DepartamentId).HasName("PRIMARY");

            entity.ToTable("departament");

            entity.HasIndex(e => e.AdresId, "adres_id");

            entity.HasIndex(e => e.CompanyId, "company_id");

            entity.Property(e => e.DepartamentId).HasColumnName("departament_id");
            entity.Property(e => e.AdresId).HasColumnName("adres_id");
            entity.Property(e => e.CompanyId).HasColumnName("company_id");
            entity.Property(e => e.DepartamentFullName)
                .HasMaxLength(100)
                .HasColumnName("departament_full_name");
            entity.Property(e => e.DepartamentShortName)
                .HasMaxLength(100)
                .HasColumnName("departament_short_name");
            entity.Property(e => e.NumberOfVacancies).HasColumnName("number_of_vacancies");

            entity.HasOne(d => d.Adres).WithMany(p => p.Departaments)
                .HasForeignKey(d => d.AdresId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("departament_ibfk_2");

            entity.HasOne(d => d.Company).WithMany(p => p.Departaments)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("departament_ibfk_1");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.DistrictId).HasName("PRIMARY");

            entity.ToTable("district");

            entity.HasIndex(e => e.CityId, "city_id");

            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(30)
                .HasColumnName("district_name");

            entity.HasOne(d => d.City).WithMany(p => p.Districts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("district_ibfk_1");
        });

        modelBuilder.Entity<EducationLevel>(entity =>
        {
            entity.HasKey(e => e.EducationLevelId).HasName("PRIMARY");

            entity.ToTable("education_level");

            entity.HasIndex(e => e.EducationLevelFull, "education_level_full").IsUnique();

            entity.Property(e => e.EducationLevelId).HasColumnName("education_level_id");
            entity.Property(e => e.EducationLevelFull)
                .HasMaxLength(100)
                .HasColumnName("education_level_full");
            entity.Property(e => e.EducationLevelShort)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("education_level_short");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.DepartamentId, "departament_id");

            entity.HasIndex(e => e.JobId, "job_id");

            entity.HasIndex(e => e.PersonId, "person_id");

            entity.HasIndex(e => e.ProjectId, "project_id");

            entity.HasIndex(e => e.SalaryId, "salary_id");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.DepartamentId).HasColumnName("departament_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.SalaryId).HasColumnName("salary_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Departament).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartamentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_5");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_4");

            entity.HasOne(d => d.Person).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_3");

            entity.HasOne(d => d.Project).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_1");

            entity.HasOne(d => d.Salary).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SalaryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_2");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PRIMARY");

            entity.ToTable("job");

            entity.HasIndex(e => e.JobName, "job_name").IsUnique();

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.JobName)
                .HasMaxLength(30)
                .HasColumnName("job_name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PRIMARY");

            entity.ToTable("person");

            entity.HasIndex(e => e.EducationLevelId, "education_level_id");

            entity.HasIndex(e => e.SpecialityId, "speciality_id");

            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.EducationLevelId).HasColumnName("education_level_id");
            entity.Property(e => e.Fname)
                .HasMaxLength(30)
                .HasColumnName("fname");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.Sname)
                .HasMaxLength(30)
                .HasColumnName("sname");
            entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");
            entity.Property(e => e.WhenBorn)
                .HasColumnType("date")
                .HasColumnName("when_born");

            entity.HasOne(d => d.EducationLevel).WithMany(p => p.People)
                .HasForeignKey(d => d.EducationLevelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("person_ibfk_1");

            entity.HasOne(d => d.Speciality).WithMany(p => p.People)
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("person_ibfk_2");
        });

        modelBuilder.Entity<PersonContact>(entity =>
        {
            entity.HasKey(e => e.PersonContactId).HasName("PRIMARY");

            entity.ToTable("person_contact");

            entity.HasIndex(e => e.ContactTypeId, "contact_type_id");

            entity.HasIndex(e => e.PersonId, "person_id");

            entity.Property(e => e.PersonContactId).HasColumnName("person_contact_id");
            entity.Property(e => e.ContactTypeId).HasColumnName("contact_type_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");

            entity.HasOne(d => d.ContactType).WithMany(p => p.PersonContacts)
                .HasForeignKey(d => d.ContactTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("person_contact_ibfk_2");

            entity.HasOne(d => d.Person).WithMany(p => p.PersonContacts)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("person_contact_ibfk_1");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PRIMARY");

            entity.ToTable("project");

            entity.Property(e => e.ProjectId).HasColumnName("project_id");
            entity.Property(e => e.ProjectFullName)
                .HasMaxLength(100)
                .HasColumnName("project_full_name");
            entity.Property(e => e.ProjectShortName)
                .HasMaxLength(100)
                .HasColumnName("project_short_name");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PRIMARY");

            entity.ToTable("salary");

            entity.Property(e => e.SalaryId).HasColumnName("salary_id");
            entity.Property(e => e.SalaryInUsd).HasColumnName("salary_in_usd");
        });

        modelBuilder.Entity<Speciality>(entity =>
        {
            entity.HasKey(e => e.SpecialityId).HasName("PRIMARY");

            entity.ToTable("speciality");

            entity.HasIndex(e => e.SpecialityFullName, "speciality_full_name").IsUnique();

            entity.Property(e => e.SpecialityId).HasColumnName("speciality_id");
            entity.Property(e => e.SpecialityFullName)
                .HasMaxLength(100)
                .HasColumnName("speciality_full_name");
            entity.Property(e => e.SpecialityShortName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("speciality_short_name");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("PRIMARY");

            entity.ToTable("street");

            entity.HasIndex(e => e.DistrictId, "district_id");

            entity.Property(e => e.StreetId).HasColumnName("street_id");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.StreetName)
                .HasMaxLength(150)
                .HasColumnName("street_name");

            entity.HasOne(d => d.District).WithMany(p => p.Streets)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("street_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
