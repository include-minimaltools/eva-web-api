namespace eva_web_api.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UniModel : DbContext
    {
        public UniModel()
            : base("name=UniDatabase")
        {
        }

        public virtual DbSet<CAMPUS> CAMPUS { get; set; }
        public virtual DbSet<CAREER> CAREER { get; set; }
        public virtual DbSet<COURSE> COURSE { get; set; }
        public virtual DbSet<FACULTY> FACULTY { get; set; }
        public virtual DbSet<GROUPS> GROUPS { get; set; }
        public virtual DbSet<PERMISSION> PERMISSION { get; set; }
        public virtual DbSet<ROLE> ROLE { get; set; }
        public virtual DbSet<ROLE_PERMISSION> ROLE_PERMISSION { get; set; }
        public virtual DbSet<SEMESTER> SEMESTER { get; set; }
        public virtual DbSet<STUDENT> STUDENT { get; set; }
        public virtual DbSet<STUDENT_COURSE> STUDENT_COURSE { get; set; }
        public virtual DbSet<STUDENT_TASK> STUDENT_TASK { get; set; }
        public virtual DbSet<TASK> TASK { get; set; }
        public virtual DbSet<TASK_COMMENT> TASK_COMMENT { get; set; }
        public virtual DbSet<TEACHER> TEACHER { get; set; }
        public virtual DbSet<TEACHER_COURSE> TEACHER_COURSE { get; set; }
        public virtual DbSet<TEACHER_GROUPS> TEACHER_GROUPS { get; set; }
        public virtual DbSet<TYPE_TASK> TYPE_TASK { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CAMPUS>()
                .HasMany(e => e.CAREER)
                .WithRequired(e => e.CAMPUS1)
                .HasForeignKey(e => e.CAMPUS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAREER>()
                .Property(e => e.ID_CAREER)
                .IsUnicode(false);

            modelBuilder.Entity<CAREER>()
                .HasMany(e => e.COURSE)
                .WithRequired(e => e.CAREER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAREER>()
                .HasMany(e => e.SEMESTER)
                .WithRequired(e => e.CAREER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAREER>()
                .HasMany(e => e.STUDENT)
                .WithRequired(e => e.CAREER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE>()
                .Property(e => e.NAME)
                .IsFixedLength();

            modelBuilder.Entity<COURSE>()
                .Property(e => e.OBJECTS)
                .IsFixedLength();

            modelBuilder.Entity<COURSE>()
                .Property(e => e.ID_CAREER)
                .IsUnicode(false);

            modelBuilder.Entity<COURSE>()
                .HasMany(e => e.SEMESTER)
                .WithRequired(e => e.COURSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE>()
                .HasMany(e => e.STUDENT_COURSE)
                .WithRequired(e => e.COURSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE>()
                .HasMany(e => e.TASK)
                .WithRequired(e => e.COURSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COURSE>()
                .HasMany(e => e.TEACHER_COURSE)
                .WithRequired(e => e.COURSE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FACULTY>()
                .HasMany(e => e.CAREER)
                .WithRequired(e => e.FACULTY1)
                .HasForeignKey(e => e.FACULTY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FACULTY>()
                .HasMany(e => e.TEACHER)
                .WithRequired(e => e.FACULTY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GROUPS>()
                .Property(e => e.ID_GROUPS)
                .IsUnicode(false);

            modelBuilder.Entity<GROUPS>()
                .Property(e => e.NAME)
                .IsFixedLength();

            modelBuilder.Entity<GROUPS>()
                .HasMany(e => e.STUDENT)
                .WithRequired(e => e.GROUPS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GROUPS>()
                .HasMany(e => e.TEACHER_GROUPS)
                .WithRequired(e => e.GROUPS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PERMISSION>()
                .HasMany(e => e.ROLE_PERMISSION)
                .WithRequired(e => e.PERMISSION)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.ROLE_PERMISSION)
                .WithRequired(e => e.ROLE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ROLE>()
                .HasMany(e => e.USERS)
                .WithOptional(e => e.ROLE1)
                .HasForeignKey(e => e.ROLE);

            modelBuilder.Entity<SEMESTER>()
                .Property(e => e.ID_SEMESTER)
                .IsFixedLength();

            modelBuilder.Entity<SEMESTER>()
                .Property(e => e.N_SEMESTER)
                .IsFixedLength();

            modelBuilder.Entity<SEMESTER>()
                .Property(e => e.ID_CAREER)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.CARNET)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.ID_CAREER)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.ID_GROUPS)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT>()
                .HasMany(e => e.STUDENT_COURSE)
                .WithRequired(e => e.STUDENT)
                .HasForeignKey(e => e.ID_STUDENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STUDENT>()
                .HasMany(e => e.STUDENT_TASK)
                .WithRequired(e => e.STUDENT)
                .HasForeignKey(e => e.ID_STUDENT)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<STUDENT_COURSE>()
                .Property(e => e.ID_STUDENT)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT_TASK>()
                .Property(e => e.ID_STUDENT)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT_TASK>()
                .Property(e => e.ID_TASK)
                .IsUnicode(false);

            modelBuilder.Entity<STUDENT_TASK>()
                .Property(e => e.QUALIFICATION)
                .IsFixedLength();

            modelBuilder.Entity<STUDENT_TASK>()
                .Property(e => e.TASK_FILE)
                .IsFixedLength();

            modelBuilder.Entity<TASK>()
                .Property(e => e.ID_TASK)
                .IsUnicode(false);

            modelBuilder.Entity<TASK>()
                .Property(e => e.ID_TYPE_TASK)
                .IsFixedLength();

            modelBuilder.Entity<TASK>()
                .HasMany(e => e.STUDENT_TASK)
                .WithRequired(e => e.TASK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TASK_COMMENT>()
                .Property(e => e.TYPE_TASK)
                .IsFixedLength();

            modelBuilder.Entity<TASK_COMMENT>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<TEACHER>()
                .Property(e => e.NAME)
                .IsFixedLength();

            modelBuilder.Entity<TEACHER>()
                .Property(e => e.LASTNAME)
                .IsFixedLength();

            modelBuilder.Entity<TEACHER>()
                .HasMany(e => e.TEACHER_COURSE)
                .WithRequired(e => e.TEACHER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEACHER>()
                .HasMany(e => e.TEACHER_GROUPS)
                .WithRequired(e => e.TEACHER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TEACHER_GROUPS>()
                .Property(e => e.ID_GROUPS)
                .IsUnicode(false);

            modelBuilder.Entity<TYPE_TASK>()
                .Property(e => e.ID_TYPE_TASK)
                .IsFixedLength();

            modelBuilder.Entity<TYPE_TASK>()
                .Property(e => e.DESCRIPTION)
                .IsFixedLength();

            modelBuilder.Entity<TYPE_TASK>()
                .HasMany(e => e.TASK)
                .WithRequired(e => e.TYPE_TASK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.STUDENT)
                .WithRequired(e => e.USERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.TEACHER)
                .WithRequired(e => e.USERS)
                .WillCascadeOnDelete(false);
        }
    }
}
