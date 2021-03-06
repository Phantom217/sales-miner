﻿namespace allpax_sale_miner.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class allpax_sale_minerEntities : DbContext
    {
        public allpax_sale_minerEntities()
            : base("name=allpax_sale_minerEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<tbl_customer> tbl_customer { get; set; }
        public virtual DbSet<tbl_customer_event> tbl_customer_event { get; set; }
        public virtual DbSet<tbl_kit> tbl_kit { get; set; }
        public virtual DbSet<tbl_eqpmt_kits_current> tbl_eqpmt_kits_current { get; set; }
        public virtual DbSet<tbl_event_type> tbl_event_type { get; set; }
        public virtual DbSet<tbl_eqpmt_type> tbl_eqpmt_type { get; set; }
        public virtual DbSet<tbl_eqpmt_kits_avlbl> tbl_eqpmt_kits_avlbl { get; set; }
        public virtual DbSet<tbl_customer_eqpmt> tbl_customer_eqpmt { get; set; }
        public virtual DbSet<tbl_eqpmt_type_mgmt> tbl_eqpmt_type_mgmt { get; set; }
    }
}