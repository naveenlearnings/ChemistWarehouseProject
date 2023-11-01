using ChemistWarehousePizzeria.Models;
using Microsoft.EntityFrameworkCore;

namespace ChemistWarehousePizzeria.Repositories
{
    public partial class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext()
        {
        }

        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<Pizza> Pizzas { get; set; }

        public virtual DbSet<PizzaMenu> PizzaMenus { get; set; }

        public virtual DbSet<Pizzeria> Pizzeria { get; set; }

        public virtual DbSet<Price> Prices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Location_Id");

                entity.ToTable("Location");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Menu_Id");

                entity.ToTable("Menu");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Pizzeria).WithMany(p => p.Menus)
                    .HasForeignKey(d => d.PizzeriaId)
                    .HasConstraintName("FK_Menu_PizzeriaId");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Pizza_Id");

                entity.ToTable("Pizza");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Toppings)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaMenu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PizzaMen_Id");

                entity.ToTable("PizzaMenu");

                entity.HasOne(d => d.Menu).WithMany(p => p.PizzaMenus)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaMenu_MenuId");

                entity.HasOne(d => d.Pizza).WithMany(p => p.PizzaMenus)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PizzaMenu_PizzaId");
            });

            modelBuilder.Entity<Pizzeria>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Pizzeria_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location).WithMany(p => p.Pizzeria)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Pizzeria_LocationId");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Price_Id");

                entity.ToTable("Price");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
                entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Location).WithMany(p => p.Prices)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Price_LocationId");

                entity.HasOne(d => d.Pizza).WithMany(p => p.Prices)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK_Price_PizzaId");
            });

            //OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
