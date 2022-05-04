﻿using ApiCatalgo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalgo.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}

    DbSet<Produto>? Produtos { get; set; }
    DbSet<Categoria>? Categorias { get; set; }  

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

        mb.Entity<Categoria>().Property(c => c.Nome)
                              .HasMaxLength(128)
                              .IsRequired();

        mb.Entity<Categoria>().Property(c => c.Descricao)
                              .HasMaxLength(180)
                              .IsRequired();

        mb.Entity<Produto>().HasKey(c => c.ProdutoId);

        mb.Entity<Produto>().Property(c => c.Nome)
                            .HasMaxLength(128)
                            .IsRequired();

        mb.Entity<Produto>().Property(c => c.Descricao)
                            .HasMaxLength(180);

        mb.Entity<Produto>().Property(c => c.Imagem)
                            .HasMaxLength(100);

        mb.Entity<Produto>().Property(c => c.Preco)
                            .HasPrecision(14, 2);

        mb.Entity<Produto>().HasOne<Categoria>(c => c.Categoria)
                                .WithMany(p => p.Produtos)
                                    .HasForeignKey(c => c.CategoriaId);

    }
}