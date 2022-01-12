namespace WebOnline.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BHDBContext : DbContext
    {
        public BHDBContext()
            : base("name=BHDBContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<baiViet> baiViets { get; set; }
        public virtual DbSet<ctDonHang> ctDonHangs { get; set; }
        public virtual DbSet<donHang> donHangs { get; set; }
        public virtual DbSet<khachHang> khachHangs { get; set; }
        public virtual DbSet<loaiSP> loaiSPs { get; set; }
        public virtual DbSet<nhomTk> nhomTks { get; set; }
        public virtual DbSet<quanHuyen> quanHuyens { get; set; }
        public virtual DbSet<sanPham> sanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<taiKhoanTV> taiKhoanTVs { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<baiViet>()
                .Property(e => e.maBV)
                .IsUnicode(false);

            modelBuilder.Entity<baiViet>()
                .Property(e => e.hinhDD)
                .IsUnicode(false);

            modelBuilder.Entity<baiViet>()
                .Property(e => e.taiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<ctDonHang>()
                .Property(e => e.soDH)
                .IsUnicode(false);

           // modelBuilder.Entity<ctDonHang>()
             //   .Property(e => e.maSP)
               // .IsUnicode(false);

            modelBuilder.Entity<donHang>()
                .Property(e => e.soDH)
                .IsUnicode(false);

            modelBuilder.Entity<donHang>()
                .Property(e => e.maKH)
                .IsUnicode(false);

            modelBuilder.Entity<donHang>()
                .Property(e => e.taiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<donHang>()
                .HasMany(e => e.ctDonHangs)
                .WithRequired(e => e.donHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachHang>()
                .Property(e => e.maKH)
                .IsUnicode(false);

            modelBuilder.Entity<khachHang>()
                .Property(e => e.soDT)
                .IsUnicode(false);

            modelBuilder.Entity<khachHang>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<khachHang>()
                .HasMany(e => e.donHangs)
                .WithRequired(e => e.khachHang)
                .WillCascadeOnDelete(false);

            //modelBuilder.Entity<sanPham>()
              //  .Property(e => e.maSP)
                //.IsUnicode(false);

            modelBuilder.Entity<sanPham>()
                .Property(e => e.hinhDD)
                .IsUnicode(false);

            modelBuilder.Entity<sanPham>()
                .Property(e => e.taiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<sanPham>()
                .HasMany(e => e.ctDonHangs)
                .WithRequired(e => e.sanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<taiKhoanTV>()
                .Property(e => e.taiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<taiKhoanTV>()
                .Property(e => e.matKhau)
                .IsUnicode(false);

            modelBuilder.Entity<taiKhoanTV>()
                .HasMany(e => e.baiViets)
                .WithRequired(e => e.taiKhoanTV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<taiKhoanTV>()
                .HasMany(e => e.donHangs)
                .WithRequired(e => e.taiKhoanTV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<taiKhoanTV>()
                .HasMany(e => e.sanPhams)
                .WithRequired(e => e.taiKhoanTV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassAdmin)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModfiedBy)
                .IsUnicode(false);
        }

        internal void SubmitChanges()
        {
            throw new NotImplementedException();
        }
    }
}
