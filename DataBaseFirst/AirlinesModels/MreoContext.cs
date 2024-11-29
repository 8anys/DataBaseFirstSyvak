using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst.AirlinesModels;

public partial class MreoContext : DbContext
{
    public MreoContext()
    {
    }

    public MreoContext(DbContextOptions<MreoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adre> Adres { get; set; }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<AutoFine> AutoFines { get; set; }

    public virtual DbSet<AutoModel> AutoModels { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Inspection> Inspections { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<ServiceCenter> ServiceCenters { get; set; }

    public virtual DbSet<Street> Streets { get; set; }

    public virtual DbSet<Violation> Violations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;User ID=root;Password=Maroon52015;Database=mreo;");

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

        modelBuilder.Entity<Auto>(entity =>
        {
            entity.HasKey(e => e.AutoId).HasName("PRIMARY");

            entity.ToTable("auto");

            entity.HasIndex(e => e.AutoModelId, "auto_model_id");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.HasIndex(e => e.InspectionsId, "inspections_id");

            entity.HasIndex(e => e.InsuranceId, "insurance_id");

            entity.HasIndex(e => e.PersonId, "person_id");

            entity.HasIndex(e => e.RegistrationId, "registration_id");

            entity.Property(e => e.AutoId).HasColumnName("auto_id");
            entity.Property(e => e.AutoModelId).HasColumnName("auto_model_id");
            entity.Property(e => e.AutoName)
                .HasMaxLength(100)
                .HasColumnName("auto_name");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .HasColumnName("color");
            entity.Property(e => e.InspectionsId).HasColumnName("inspections_id");
            entity.Property(e => e.InsuranceId).HasColumnName("insurance_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.RegistrationId).HasColumnName("registration_id");

            entity.HasOne(d => d.AutoModel).WithMany(p => p.Autos)
                .HasForeignKey(d => d.AutoModelId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("auto_ibfk_2");

            entity.HasOne(d => d.Category).WithMany(p => p.Autos)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("auto_ibfk_1");

            entity.HasOne(d => d.Inspections).WithMany(p => p.Autos)
                .HasForeignKey(d => d.InspectionsId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("auto_ibfk_5");

            entity.HasOne(d => d.Insurance).WithMany(p => p.Autos)
                .HasForeignKey(d => d.InsuranceId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("auto_ibfk_4");

            entity.HasOne(d => d.Person).WithMany(p => p.Autos)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("auto_ibfk_6");

            entity.HasOne(d => d.Registration).WithMany(p => p.Autos)
                .HasForeignKey(d => d.RegistrationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("auto_ibfk_3");
        });

        modelBuilder.Entity<AutoFine>(entity =>
        {
            entity.HasKey(e => e.FineId).HasName("PRIMARY");

            entity.ToTable("auto_fines");

            entity.HasIndex(e => e.AutoId, "auto_id");

            entity.HasIndex(e => e.ViolationId, "violation_id");

            entity.Property(e => e.FineId).HasColumnName("fine_id");
            entity.Property(e => e.Amount)
                .HasPrecision(10)
                .HasColumnName("amount");
            entity.Property(e => e.AutoId).HasColumnName("auto_id");
            entity.Property(e => e.FineDate)
                .HasColumnType("date")
                .HasColumnName("fine_date");
            entity.Property(e => e.ViolationId).HasColumnName("violation_id");

            entity.HasOne(d => d.Auto).WithMany(p => p.AutoFines)
                .HasForeignKey(d => d.AutoId)
                .HasConstraintName("auto_fines_ibfk_1");

            entity.HasOne(d => d.Violation).WithMany(p => p.AutoFines)
                .HasForeignKey(d => d.ViolationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("auto_fines_ibfk_2");
        });

        modelBuilder.Entity<AutoModel>(entity =>
        {
            entity.HasKey(e => e.AutoModelId).HasName("PRIMARY");

            entity.ToTable("auto_model");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.Property(e => e.AutoModelId).HasColumnName("auto_model_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .HasColumnName("color");
            entity.Property(e => e.EngineNumber).HasColumnName("engine_number");
            entity.Property(e => e.Make)
                .HasMaxLength(100)
                .HasColumnName("make");
            entity.Property(e => e.YearOfManufacture).HasColumnName("year_of_manufacture");

            entity.HasOne(d => d.Category).WithMany(p => p.AutoModels)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("auto_model_ibfk_1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(30)
                .HasColumnName("category_name");
            entity.Property(e => e.MaxPassengers).HasColumnName("max_passengers");
            entity.Property(e => e.MaxWeight).HasColumnName("max_weight");
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

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.JobId, "job_id");

            entity.HasIndex(e => e.PersonId, "person_id");

            entity.HasIndex(e => e.ServiceCenterId, "service_center_id");

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.PersonId).HasColumnName("person_id");
            entity.Property(e => e.ServiceCenterId).HasColumnName("service_center_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Job).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_3");

            entity.HasOne(d => d.Person).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_2");

            entity.HasOne(d => d.ServiceCenter).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ServiceCenterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_1");
        });

        modelBuilder.Entity<Inspection>(entity =>
        {
            entity.HasKey(e => e.InspectionId).HasName("PRIMARY");

            entity.ToTable("inspections");

            entity.Property(e => e.InspectionId).HasColumnName("inspection_id");
            entity.Property(e => e.InspectionDate)
                .HasColumnType("date")
                .HasColumnName("inspection_date");
            entity.Property(e => e.InspectionType)
                .HasMaxLength(50)
                .HasColumnName("inspection_type");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("PRIMARY");

            entity.ToTable("insurance");

            entity.HasIndex(e => e.InsuranceCompanyId, "insurance_company_id");

            entity.Property(e => e.InsuranceId).HasColumnName("insurance_id");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("date")
                .HasColumnName("expiry_date");
            entity.Property(e => e.InsuranceCompanyId).HasColumnName("insurance_company_id");
            entity.Property(e => e.PolicyNumber).HasColumnName("policy_number");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");

            entity.HasOne(d => d.InsuranceCompany).WithMany(p => p.Insurances)
                .HasForeignKey(d => d.InsuranceCompanyId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("insurance_ibfk_1");
        });

        modelBuilder.Entity<InsuranceCompany>(entity =>
        {
            entity.HasKey(e => e.InsuranceCompanyId).HasName("PRIMARY");

            entity.ToTable("insurance_company");

            entity.Property(e => e.InsuranceCompanyId).HasColumnName("insurance_company_id");
            entity.Property(e => e.EstablishedDate)
                .HasColumnType("date")
                .HasColumnName("established_date");
            entity.Property(e => e.InsuranceCompanyName)
                .HasMaxLength(100)
                .HasColumnName("insurance_company_name");
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

            entity.Property(e => e.PersonId).HasColumnName("person_id");
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
            entity.Property(e => e.WhenBorn)
                .HasColumnType("date")
                .HasColumnName("when_born");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PRIMARY");

            entity.ToTable("registration");

            entity.Property(e => e.RegistrationId).HasColumnName("registration_id");
            entity.Property(e => e.ExpiryDate)
                .HasColumnType("date")
                .HasColumnName("expiry_date");
            entity.Property(e => e.RegistrationDate)
                .HasColumnType("date")
                .HasColumnName("registration_date");
            entity.Property(e => e.RegistrationNumber).HasColumnName("registration_number");
            entity.Property(e => e.RegistrationType)
                .HasMaxLength(30)
                .HasColumnName("registration_type");
        });

        modelBuilder.Entity<ServiceCenter>(entity =>
        {
            entity.HasKey(e => e.ServiceCenterId).HasName("PRIMARY");

            entity.ToTable("service_center");

            entity.HasIndex(e => e.AdresId, "adres_id");

            entity.HasIndex(e => e.AutoId, "auto_id");

            entity.Property(e => e.ServiceCenterId).HasColumnName("service_center_id");
            entity.Property(e => e.AdresId).HasColumnName("adres_id");
            entity.Property(e => e.AutoId).HasColumnName("auto_id");
            entity.Property(e => e.ServiceCenterName)
                .HasMaxLength(100)
                .HasColumnName("service_center_name");
            entity.Property(e => e.WorkingHour).HasColumnName("working_hour");

            entity.HasOne(d => d.Adres).WithMany(p => p.ServiceCenters)
                .HasForeignKey(d => d.AdresId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("service_center_ibfk_1");

            entity.HasOne(d => d.Auto).WithMany(p => p.ServiceCenters)
                .HasForeignKey(d => d.AutoId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("service_center_ibfk_2");
        });

        modelBuilder.Entity<Street>(entity =>
        {
            entity.HasKey(e => e.StreetId).HasName("PRIMARY");

            entity.ToTable("street");

            entity.HasIndex(e => e.DistrictId, "district_id");

            entity.Property(e => e.StreetId).HasColumnName("street_id");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.StreetName)
                .HasMaxLength(30)
                .HasColumnName("street_name");

            entity.HasOne(d => d.District).WithMany(p => p.Streets)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("street_ibfk_1");
        });

        modelBuilder.Entity<Violation>(entity =>
        {
            entity.HasKey(e => e.ViolationId).HasName("PRIMARY");

            entity.ToTable("violations");

            entity.Property(e => e.ViolationId).HasColumnName("violation_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.PenaltyAmount)
                .HasPrecision(10)
                .HasColumnName("penalty_amount");
            entity.Property(e => e.ViolationDate)
                .HasColumnType("date")
                .HasColumnName("violation_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
