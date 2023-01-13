using Microsoft.EntityFrameworkCore;
using ContaBancaria.Infra.Entities;

namespace ContaBancaria.Infra.Database
{
    public partial class ContaBancariaDbContext : DbContext
    {
        public ContaBancariaDbContext() { }

        public ContaBancariaDbContext(DbContextOptions<ContaBancariaDbContext> options)
            : base(options) { }

        public virtual DbSet<TbAgencia> TbAgencia { get; set; } = null!;
        public virtual DbSet<TbConta> TbConta { get; set; } = null!;
        public virtual DbSet<TbEndereco> TbEnderecos { get; set; } = null!;
        public virtual DbSet<TbMovimento> TbMovimentos { get; set; } = null!;
        public virtual DbSet<TbPessoa> TbPessoas { get; set; } = null!;
        public virtual DbSet<TbPessoaFisica> TbPessoaFisicas { get; set; } = null!;
        public virtual DbSet<TbPessoaJuridica> TbPessoaJuridicas { get; set; } = null!;
        public virtual DbSet<TbSaque> TbSaques { get; set; } = null!;
        public virtual DbSet<TbTipoMovimento> TbTipoMovimentos { get; set; } = null!;
        public virtual DbSet<TbTransferencium> TbTransferencia { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "server=172.18.0.3;database=conta_db;uid=dbuser;pwd=dbpwd",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TbAgencia>(entity =>
            {
                entity.HasKey(e => e.CodAgencia)
                    .HasName("PRIMARY");

                entity.ToTable("tb_agencia");

                entity.HasIndex(e => e.Cep, "tb_endereco_agencia_fk");

                entity.Property(e => e.CodAgencia)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_agencia");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep");

                entity.HasOne(d => d.CepNavigation)
                    .WithMany(p => p.TbAgencia)
                    .HasForeignKey(d => d.Cep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_endereco_agencia_fk");
            });

            modelBuilder.Entity<TbConta>(entity =>
            {
                entity.HasKey(e => e.CodConta)
                    .HasName("PRIMARY");

                entity.ToTable("tb_conta");

                entity.HasIndex(e => e.CodAgencia, "agencia_tb_conta_fk");

                entity.HasIndex(e => e.CodPessoa, "tb_pessoa_tb_conta_fk");

                entity.Property(e => e.CodConta).HasColumnName("cod_conta");

                entity.Property(e => e.CodAgencia).HasColumnName("cod_agencia");

                entity.Property(e => e.CodPessoa).HasColumnName("cod_pessoa");

                entity.Property(e => e.DataAbertura)
                    .HasColumnType("datetime")
                    .HasColumnName("data_abertura");

                entity.Property(e => e.Saldo)
                    .HasPrecision(2)
                    .HasColumnName("saldo");

                entity.HasOne(d => d.CodAgenciaNavigation)
                    .WithMany(p => p.TbConta)
                    .HasForeignKey(d => d.CodAgencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("agencia_tb_conta_fk");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithMany(p => p.TbConta)
                    .HasForeignKey(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_pessoa_tb_conta_fk");
            });

            modelBuilder.Entity<TbEndereco>(entity =>
            {
                entity.HasKey(e => e.Cep)
                    .HasName("PRIMARY");

                entity.ToTable("tb_endereco");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(100)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(100)
                    .HasColumnName("cidade");

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .HasColumnName("estado");

                entity.Property(e => e.Rua)
                    .HasMaxLength(100)
                    .HasColumnName("rua");
            });

            modelBuilder.Entity<TbMovimento>(entity =>
            {
                entity.HasKey(e => e.CodMovimento)
                    .HasName("PRIMARY");

                entity.ToTable("tb_movimento");

                entity.HasIndex(e => e.CodConta, "tb_conta_movimento_fk");

                entity.HasIndex(e => e.CodTipoMovimento, "tb_movimento_tb_tipo_movimento_fk");

                entity.HasIndex(e => e.CodSaque, "tb_saque_movimento_fk");

                entity.HasIndex(e => e.CodTransferencia, "tb_transferencia_movimento_fk");

                entity.Property(e => e.CodMovimento)
                    .HasMaxLength(32)
                    .HasColumnName("cod_movimento");

                entity.Property(e => e.CodConta).HasColumnName("cod_conta");

                entity.Property(e => e.CodSaque)
                    .HasMaxLength(32)
                    .HasColumnName("cod_saque");

                entity.Property(e => e.CodTipoMovimento).HasColumnName("cod_tipo_movimento");

                entity.Property(e => e.CodTransferencia)
                    .HasMaxLength(32)
                    .HasColumnName("cod_transferencia");

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasColumnName("data");

                entity.Property(e => e.Valor)
                    .HasPrecision(2)
                    .HasColumnName("valor");

                entity.HasOne(d => d.CodContaNavigation)
                    .WithMany(p => p.TbMovimentos)
                    .HasForeignKey(d => d.CodConta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_conta_movimento_fk");

                entity.HasOne(d => d.CodSaqueNavigation)
                    .WithMany(p => p.TbMovimentos)
                    .HasForeignKey(d => d.CodSaque)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_saque_movimento_fk");

                entity.HasOne(d => d.CodTipoMovimentoNavigation)
                    .WithMany(p => p.TbMovimentos)
                    .HasForeignKey(d => d.CodTipoMovimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_movimento_tb_tipo_movimento_fk");

                entity.HasOne(d => d.CodTransferenciaNavigation)
                    .WithMany(p => p.TbMovimentos)
                    .HasForeignKey(d => d.CodTransferencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_transferencia_movimento_fk");
            });

            modelBuilder.Entity<TbPessoa>(entity =>
            {
                entity.HasKey(e => e.CodPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("tb_pessoa");

                entity.HasIndex(e => e.Cep, "tb_endereco_tb_pessoa_fk");

                entity.Property(e => e.CodPessoa).HasColumnName("cod_pessoa");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .HasColumnName("cep");

                entity.Property(e => e.Nome)
                    .HasMaxLength(35)
                    .HasColumnName("nome");

                entity.HasOne(d => d.CepNavigation)
                    .WithMany(p => p.TbPessoas)
                    .HasForeignKey(d => d.Cep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_endereco_tb_pessoa_fk");
            });

            modelBuilder.Entity<TbPessoaFisica>(entity =>
            {
                entity.HasKey(e => e.CodPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("tb_pessoa_fisica");

                entity.Property(e => e.CodPessoa)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_pessoa");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .HasColumnName("cpf");

                entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");

                entity.Property(e => e.Rg)
                    .HasMaxLength(9)
                    .HasColumnName("rg");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithOne(p => p.TbPessoaFisica)
                    .HasForeignKey<TbPessoaFisica>(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_pessoa_tb_pessoa_fisica_fk");
            });

            modelBuilder.Entity<TbPessoaJuridica>(entity =>
            {
                entity.HasKey(e => e.CodPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("tb_pessoa_juridica");

                entity.Property(e => e.CodPessoa)
                    .ValueGeneratedNever()
                    .HasColumnName("cod_pessoa");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(14)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Ie)
                    .HasMaxLength(9)
                    .HasColumnName("ie")
                    .HasComment("Inscrição estadual");

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(100)
                    .HasColumnName("nome_fantasia");

                entity.HasOne(d => d.CodPessoaNavigation)
                    .WithOne(p => p.TbPessoaJuridica)
                    .HasForeignKey<TbPessoaJuridica>(d => d.CodPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_pessoa_tb_pessoa_juridica_fk");
            });

            modelBuilder.Entity<TbSaque>(entity =>
            {
                entity.HasKey(e => e.CodSaque)
                    .HasName("PRIMARY");

                entity.ToTable("tb_saque");

                entity.Property(e => e.CodSaque)
                    .HasMaxLength(32)
                    .HasColumnName("cod_saque");

                entity.Property(e => e.CodCaixa)
                    .HasMaxLength(32)
                    .HasColumnName("cod_caixa");
            });

            modelBuilder.Entity<TbTipoMovimento>(entity =>
            {
                entity.HasKey(e => e.CodTipoMovimento)
                    .HasName("PRIMARY");

                entity.ToTable("tb_tipo_movimento");

                entity.Property(e => e.CodTipoMovimento).HasColumnName("cod_tipo_movimento");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(30)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<TbTransferencium>(entity =>
            {
                entity.HasKey(e => e.CodTransferencia)
                    .HasName("PRIMARY");

                entity.ToTable("tb_transferencia");

                entity.HasIndex(e => e.CodConta, "tb_conta_tb_transferencia_fk");

                entity.Property(e => e.CodTransferencia)
                    .HasMaxLength(32)
                    .HasColumnName("cod_transferencia");

                entity.Property(e => e.CodConta).HasColumnName("cod_conta");

                entity.HasOne(d => d.CodContaNavigation)
                    .WithMany(p => p.TbTransferencia)
                    .HasForeignKey(d => d.CodConta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_conta_tb_transferencia_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
