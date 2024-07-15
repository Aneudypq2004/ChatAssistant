using Microsoft.EntityFrameworkCore;
using P3_Proyecto.Models;

namespace P3_Proyecto.Context;

public partial class ChatRoomContext : DbContext
{
    public ChatRoomContext()
    {
    }

    public ChatRoomContext(DbContextOptions<ChatRoomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CHATmessage");

            entity.ToTable("ChatMessage");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA");
            entity.Property(e => e.Mensaje)
                .HasColumnType("text")
                .HasColumnName("MENSAJE");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .HasColumnName("USUARIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
