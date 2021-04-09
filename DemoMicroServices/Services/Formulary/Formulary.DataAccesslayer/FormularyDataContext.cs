using Formulary.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formulary.DataAccesslayer
{
    public class FormularyDataContext : DbContext
    {

        public DbSet<FormularyModel> Formularies { get; set; }

        public DbSet<FormularyItem> FormularyItems { get; set; }

        public DbSet<FormularyItemNDC> formularyItemNDCs { get; set; }

        public DbSet<ReferenceDataItem> ReferenceDataItems { get; set; }


        public FormularyDataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
