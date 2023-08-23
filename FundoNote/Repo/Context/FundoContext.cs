using EFCoreCodeFirstSample.Models;
using Microsoft.EntityFrameworkCore;
using Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repo.Context
{
    public class FundoContext : DbContext
    {
        public FundoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NoteEntity> Notes { get; set; }

        public DbSet<ColabEntity> Colab { get; set; }
    }
}
