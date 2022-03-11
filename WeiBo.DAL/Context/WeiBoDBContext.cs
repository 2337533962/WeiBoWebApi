using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WeiBoWebApi.DAL.Context
{
    public partial class WeiBoDBContext : DbContext
    {
        public WeiBoDBContext()
        {
        }

        public WeiBoDBContext(DbContextOptions<WeiBoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArticleComment> ArticleComments { get; set; }
        public virtual DbSet<ArticleImg> ArticleImgs { get; set; }
        public virtual DbSet<ArticleInfo> ArticleInfos { get; set; }
        public virtual DbSet<ArticlePermission> ArticlePermissions { get; set; }
        public virtual DbSet<ArticleTag> ArticleTags { get; set; }
        public virtual DbSet<ArticleType> ArticleTypes { get; set; }
        public virtual DbSet<ArticleVideo> ArticleVideos { get; set; }
        public virtual DbSet<AttentionInfo> AttentionInfos { get; set; }
        public virtual DbSet<CollectInfo> CollectInfos { get; set; }
        public virtual DbSet<EtInfo> EtInfos { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<SecondComment> SecondComments { get; set; }
        public virtual DbSet<SexInfo> SexInfos { get; set; }
        public virtual DbSet<UserBehavior> UserBehaviors { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=.;database=WeiBoDB;uid=sa;pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<ArticleComment>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__ArticleC__CDDE919D542E24E5");

                entity.ToTable("ArticleComment");

                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Content)
                    .HasMaxLength(200)
                    .HasColumnName("content");

                entity.Property(e => e.ContentTime)
                    .HasColumnType("datetime")
                    .HasColumnName("contentTime");

                entity.Property(e => e.Fabulous).HasColumnName("fabulous");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.ArticleComments)
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK__ArticleCo__artic__276EDEB3");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.ArticleComments)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK__ArticleComm__uid__267ABA7A");
            });

            modelBuilder.Entity<ArticleImg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ArticleImg");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(50)
                    .HasColumnName("imgUrl");

                entity.HasOne(d => d.Article)
                    .WithMany()
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK__ArticleIm__artic__21B6055D");
            });

            modelBuilder.Entity<ArticleInfo>(entity =>
            {
                entity.HasKey(e => e.ArticleId)
                    .HasName("PK__ArticleI__75D3D37EF035BCF1");

                entity.ToTable("ArticleInfo");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .HasColumnName("content");

                entity.Property(e => e.Fabulous).HasColumnName("fabulous");

                entity.Property(e => e.Forward).HasColumnName("forward");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.ReleaseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("releaseTime");

                entity.Property(e => e.TagId).HasColumnName("tagId");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.UserEquipment)
                    .HasMaxLength(50)
                    .HasColumnName("userEquipment");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ArticleInfos)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__ArticleIn__permi__1FCDBCEB");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.ArticleInfos)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK__ArticleIn__tagId__1ED998B2");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.ArticleInfos)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK__ArticleInfo__uid__1DE57479");
            });

            modelBuilder.Entity<ArticlePermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PK__ArticleP__D821329CEC3F17F0");

                entity.ToTable("ArticlePermission");

                entity.Property(e => e.PermissionId).HasColumnName("permissionId");

                entity.Property(e => e.Permission)
                    .HasMaxLength(20)
                    .HasColumnName("permission");
            });

            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasKey(e => e.TagId)
                    .HasName("PK__ArticleT__50FC0157071A459B");

                entity.ToTable("ArticleTag");

                entity.Property(e => e.TagId).HasColumnName("tagId");

                entity.Property(e => e.Tag)
                    .HasColumnType("text")
                    .HasColumnName("tag");
            });

            modelBuilder.Entity<ArticleType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__ArticleT__F04DF13A1397F136");

                entity.ToTable("ArticleType");

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<ArticleVideo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ArticleVideo");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.VideoUrl)
                    .HasMaxLength(50)
                    .HasColumnName("videoUrl");

                entity.HasOne(d => d.Article)
                    .WithMany()
                    .HasForeignKey(d => d.ArticleId)
                    .HasConstraintName("FK__ArticleVi__artic__239E4DCF");
            });

            modelBuilder.Entity<AttentionInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AttentionInfo");

                entity.Property(e => e.FollowId).HasColumnName("followId");

                entity.Property(e => e.FollowToId).HasColumnName("followToId");
            });

            modelBuilder.Entity<CollectInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CollectInfo");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Uid).HasColumnName("uid");
            });

            modelBuilder.Entity<EtInfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EtInfo");

                entity.Property(e => e.Et).HasColumnName("et");

                entity.Property(e => e.EtTime)
                    .HasColumnType("datetime")
                    .HasColumnName("etTime");

                entity.Property(e => e.EtTo).HasColumnName("etTo");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("History");

                entity.Property(e => e.ArticleId).HasColumnName("articleId");

                entity.Property(e => e.Uid).HasColumnName("uid");
            });

            modelBuilder.Entity<SecondComment>(entity =>
            {
                entity.ToTable("SecondComment");

                entity.Property(e => e.SecondCommentId).HasColumnName("secondCommentId");

                entity.Property(e => e.CommentId).HasColumnName("commentId");

                entity.Property(e => e.Content)
                    .HasMaxLength(200)
                    .HasColumnName("content");

                entity.Property(e => e.ContentTime)
                    .HasColumnType("datetime")
                    .HasColumnName("contentTime");

                entity.Property(e => e.Fabulous).HasColumnName("fabulous");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.SecondComments)
                    .HasForeignKey(d => d.CommentId)
                    .HasConstraintName("FK__SecondCom__comme__2A4B4B5E");
            });

            modelBuilder.Entity<SexInfo>(entity =>
            {
                entity.HasKey(e => e.SexId)
                    .HasName("PK__SexInfo__D8437D9C4C8D1630");

                entity.ToTable("SexInfo");

                entity.Property(e => e.SexId).HasColumnName("sexId");

                entity.Property(e => e.Sex)
                    .HasMaxLength(10)
                    .HasColumnName("sex");
            });

            modelBuilder.Entity<UserBehavior>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserBehavior");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.UserBehavior1).HasColumnName("UserBehavior");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("FK__UserBehavio__uid__2F10007B");

                entity.HasOne(d => d.UserBehavior1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.UserBehavior1)
                    .HasConstraintName("FK__UserBehav__UserB__300424B4");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("PK__UserInfo__DD701264EB93BA68");

                entity.ToTable("UserInfo");

                entity.HasIndex(e => e.Account, "UQ__UserInfo__EA162E110340BFE3")
                    .IsUnique();

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Account)
                    .HasMaxLength(50)
                    .HasColumnName("account");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Birth)
                    .HasColumnType("date")
                    .HasColumnName("birth");

                entity.Property(e => e.Follow).HasColumnName("follow");

                entity.Property(e => e.HeadPortrait)
                    .HasMaxLength(50)
                    .HasColumnName("headPortrait");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.NickName)
                    .HasMaxLength(50)
                    .HasColumnName("nickName");

                entity.Property(e => e.Overdue)
                    .HasColumnType("datetime")
                    .HasColumnName("overdue");

                entity.Property(e => e.Pwd)
                    .HasMaxLength(50)
                    .HasColumnName("pwd");

                entity.Property(e => e.SexId).HasColumnName("sexId");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.HasOne(d => d.Sex)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.SexId)
                    .HasConstraintName("FK__UserInfo__sexId__1367E606");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
