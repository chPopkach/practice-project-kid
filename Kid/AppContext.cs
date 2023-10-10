using Kid.Models;
using Microsoft.EntityFrameworkCore;

namespace Kid;

public partial class AppContext : DbContext
{
    public AppContext()
    {
        Database.EnsureCreated();
    }

    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Charter> Charters { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeesCharter> EmployeesCharters { get; set; }

    public virtual DbSet<EventsTable> EventsTables { get; set; }

    public virtual DbSet<EventsTableSchoolchild> EventsTableSchoolchilds { get; set; }

    public virtual DbSet<Schoolchild> Schoolchilds { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=App;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AS");

        modelBuilder.Entity<Charter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Charters__3214EC272EBDE652");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DescriptionC)
                .HasColumnType("text")
                .HasColumnName("Description_c");
            entity.Property(e => e.NameCharter).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC27B6498F46");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NameE)
                .HasMaxLength(50)
                .HasColumnName("Name_e");
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeesCharter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC2728D1D696");

            entity.ToTable("Employees_Charters");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CharterId).HasColumnName("Charter_ID");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

            entity.HasOne(d => d.Charter).WithMany(p => p.EmployeesCharters)
                .HasForeignKey(d => d.CharterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Chart__300424B4");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeesCharters)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__Emplo__30F848ED");
        });

        modelBuilder.Entity<EventsTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventsTa__3214EC27AA98D8A5");

            entity.ToTable("EventsTable");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.DateEvent).HasColumnType("date");
            entity.Property(e => e.DescriptionE)
                .HasColumnType("text")
                .HasColumnName("Description_e");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.IsCompleted).HasMaxLength(3);
            entity.Property(e => e.NameEvent).HasMaxLength(100);

            entity.HasOne(d => d.Employee).WithMany(p => p.EventsTables)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventsTab__Emplo__31EC6D26");
        });

        modelBuilder.Entity<EventsTableSchoolchild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventsTa__3214EC2732FFD34D");

            entity.ToTable("EventsTable_Schoolchilds");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EventId).HasColumnName("Event_ID");
            entity.Property(e => e.SchoolchildId).HasColumnName("Schoolchild_ID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventsTableSchoolchildren)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventsTab__Event__32E0915F");

            entity.HasOne(d => d.Schoolchild).WithMany(p => p.EventsTableSchoolchildren)
                .HasForeignKey(d => d.SchoolchildId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EventsTab__Schoo__33D4B598");
        });

        modelBuilder.Entity<Schoolchild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Schoolch__3214EC27412C61BC");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.NameE)
                .HasMaxLength(50)
                .HasColumnName("Name_e");
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27F5DCFBAB");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.IdentityKey)
                .HasMaxLength(16)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__Employee___34C8D9D1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
