﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBLAPTOP.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QUANLILAPTOPEntities : DbContext
    {
        public QUANLILAPTOPEntities()
            : base("name=QUANLILAPTOPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CTHDN> CTHDNs { get; set; }
        public virtual DbSet<CTSP> CTSPs { get; set; }
        public virtual DbSet<HDN> HDNs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<LoaiSP> LoaiSPs { get; set; }
        public virtual DbSet<NCC> NCCs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tintuc> tintucs { get; set; }
        public virtual DbSet<loaiTT> loaiTTs { get; set; }
        public virtual DbSet<DH> DHs { get; set; }
        public virtual DbSet<CTDHB> CTDHBs { get; set; }
        public virtual DbSet<login> logins { get; set; }
    }
}