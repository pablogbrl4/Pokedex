﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;
using WebTeste.Models;
using WebTeste.Models.ModelConfigurations;


namespace WebTeste
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

       public DbSet<User> User { get; set; }

        public DbSet<_Pokemon_> _Pokemon_ { get; set; }

        public DbSet<Types> Types { get; set; }

        public DbSet<Pokemon_Types> Pokemon_Types { get; set; }


        protected IDbContextTransaction _contextoTransaction { get; set; }

        public async Task<IDbContextTransaction> IniciarTransaction()
        {
            if (_contextoTransaction == null)
            {
                _contextoTransaction = await this.Database.BeginTransactionAsync();
            }
            return _contextoTransaction;
        }

        private async Task RollBack()
        {
            if (_contextoTransaction != null)
            {
                await _contextoTransaction.RollbackAsync();
            }
        }

        private async Task Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await RollBack();
                throw new Exception(ex.Message);
            }
        }

        private async Task Commit()
        {
            if (_contextoTransaction != null)
            {
                await _contextoTransaction.CommitAsync();
                await _contextoTransaction.DisposeAsync();
                _contextoTransaction = null;
            }
        }

        public async Task SalvarMudancas()
        {
            await Salvar();
            await Commit();
        }
    }
}
