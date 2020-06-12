using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DemoProjectSem2.Models
{
    public partial class ApplicationDB : DbContext
    {
        public ApplicationDB()
        {
        }

        public ApplicationDB(DbContextOptions<ApplicationDB> options)
            : base(options)
        {
        }

        public virtual DbSet<TblActivity> TblActivity { get; set; }
        public virtual DbSet<TblActivityType> TblActivityType { get; set; }
        public virtual DbSet<TblCity> TblCity { get; set; }
        public virtual DbSet<TblFoodTimeDetails> TblFoodTimeDetails { get; set; }
        public virtual DbSet<TblGuide> TblGuide { get; set; }
        public virtual DbSet<TblHotel> TblHotel { get; set; }
        public virtual DbSet<TblPackage> TblPackage { get; set; }
        public virtual DbSet<TblPackageActivities> TblPackageActivities { get; set; }
        public virtual DbSet<TblPayment> TblPayment { get; set; }
        public virtual DbSet<TblState> TblState { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblUserPackage> TblUserPackage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblActivity>(entity =>
            {
                entity.HasKey(e => e.ActivityId)
                    .HasName("PK__tbl_Acti__482FBD6354C85027");

                entity.ToTable("tbl_Activity");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.ActivityCost)
                    .HasColumnName("activity_cost")
                    .HasColumnType("money");

                entity.Property(e => e.ActivityName)
                    .HasColumnName("activity_name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ActivityTiming).HasColumnName("activity_timing");

                entity.Property(e => e.ActivityType).HasColumnName("activity_type");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.ActivityTypeNavigation)
                    .WithMany(p => p.TblActivity)
                    .HasForeignKey(d => d.ActivityType)
                    .HasConstraintName("FK__tbl_Activ__activ__4CA06362");
            });

            modelBuilder.Entity<TblActivityType>(entity =>
            {
                entity.HasKey(e => e.ActivityTypeId)
                    .HasName("PK__tbl_acti__0A48BF67BAE6D871");

                entity.ToTable("tbl_activityType");

                entity.Property(e => e.ActivityTypeId).HasColumnName("activityType_id");

                entity.Property(e => e.ActivityTypeName)
                    .HasColumnName("activityType_name")
                    .HasMaxLength(25)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK__tbl_city__031491A8C4EDF588");

                entity.ToTable("tbl_city");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CityName)
                    .HasColumnName("city_name")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TblCity)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK__tbl_city__state___3A81B327");
            });

            modelBuilder.Entity<TblFoodTimeDetails>(entity =>
            {
                entity.HasKey(e => e.FoodTimeId)
                    .HasName("PK__tbl_food__70446D4489DEC752");

                entity.ToTable("tbl_foodTimeDetails");

                entity.Property(e => e.FoodTimeId).HasColumnName("foodTime_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FoodTimeName)
                    .HasColumnName("foodTime _name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblGuide>(entity =>
            {
                entity.HasKey(e => e.GuideId)
                    .HasName("PK__tbl_guid__04A8224113D5D1B5");

                entity.ToTable("tbl_guide");

                entity.Property(e => e.GuideId).HasColumnName("guide_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.GuideCityId).HasColumnName("guide_city_id");

                entity.Property(e => e.GuideContact)
                    .HasColumnName("guide_contact")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GuideFees)
                    .HasColumnName("guide_fees")
                    .HasColumnType("money");

                entity.Property(e => e.GuideGender)
                    .HasColumnName("guide_gender")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GuideName)
                    .HasColumnName("guide_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GuideStatus).HasColumnName("guide_status");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.GuideCity)
                    .WithMany(p => p.TblGuide)
                    .HasForeignKey(d => d.GuideCityId)
                    .HasConstraintName("FK__tbl_guide__guide__5629CD9C");
            });

            modelBuilder.Entity<TblHotel>(entity =>
            {
                entity.HasKey(e => e.HotelId)
                    .HasName("PK__tbl_hote__45FE7E26AFD5D0B1");

                entity.ToTable("tbl_hotel");

                entity.Property(e => e.HotelId).HasColumnName("hotel_id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.FoodTimeId).HasColumnName("foodTime_id");

                entity.Property(e => e.HotelCost)
                    .HasColumnName("hotel_Cost")
                    .HasColumnType("money");

                entity.Property(e => e.HotelName)
                    .HasColumnName("hotel_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TblHotel)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__tbl_hotel__city___5FB337D6");

                entity.HasOne(d => d.FoodTime)
                    .WithMany(p => p.TblHotel)
                    .HasForeignKey(d => d.FoodTimeId)
                    .HasConstraintName("FK__tbl_hotel__foodT__60A75C0F");
            });

            modelBuilder.Entity<TblPackage>(entity =>
            {
                entity.HasKey(e => e.PackageId)
                    .HasName("PK__tbl_pack__63846AE853E58E5D");

                entity.ToTable("tbl_package");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.PackageCityId).HasColumnName("package_city_id");

                entity.Property(e => e.PackageDetail)
                    .HasColumnName("package_detail")
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.PackageGuideId).HasColumnName("package_guide_id");

                entity.Property(e => e.PackageHotelId).HasColumnName("package_hotel_id");

                entity.Property(e => e.PackageImage)
                    .HasColumnName("package_image")
                    .HasColumnType("text");

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasColumnName("package_name")
                    .HasMaxLength(60)
                    .IsFixedLength();

                entity.Property(e => e.PackageNoOfDays).HasColumnName("package_noOfDays");

                entity.Property(e => e.PackageNoOfNights).HasColumnName("package_noOfNights");

                entity.Property(e => e.PackageStatus).HasColumnName("package_status");

                entity.Property(e => e.PackageTotalCost)
                    .HasColumnName("package_totalCost")
                    .HasColumnType("money");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.PackageCity)
                    .WithMany(p => p.TblPackage)
                    .HasForeignKey(d => d.PackageCityId)
                    .HasConstraintName("FK__tbl_packa__packa__6EF57B66");

                entity.HasOne(d => d.PackageGuide)
                    .WithMany(p => p.TblPackage)
                    .HasForeignKey(d => d.PackageGuideId)
                    .HasConstraintName("FK__tbl_packa__packa__6E01572D");

                entity.HasOne(d => d.PackageHotel)
                    .WithMany(p => p.TblPackage)
                    .HasForeignKey(d => d.PackageHotelId)
                    .HasConstraintName("FK__tbl_packa__packa__6D0D32F4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPackage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tbl_packa__user___6FE99F9F");
            });

            modelBuilder.Entity<TblPackageActivities>(entity =>
            {
                entity.HasKey(e => e.PackageActivitiesId)
                    .HasName("PK__tbl_pack__DD3C264259E12906");

                entity.ToTable("tbl_packageActivities");

                entity.Property(e => e.PackageActivitiesId).HasColumnName("packageActivities_id");

                entity.Property(e => e.ActivityId).HasColumnName("activity_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.TblPackageActivities)
                    .HasForeignKey(d => d.ActivityId)
                    .HasConstraintName("FK__tbl_packa__activ__787EE5A0");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.TblPackageActivities)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK__tbl_packa__packa__778AC167");
            });

            modelBuilder.Entity<TblPayment>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__tbl_paym__DA638B1975FF7D14");

                entity.ToTable("tbl_payment");

                entity.Property(e => e.PaymentId).HasColumnName("Payment_id");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnName("payment_amount")
                    .HasColumnType("money");

                entity.Property(e => e.PaymentDate)
                    .HasColumnName("payment_date")
                    .HasColumnType("date");

                entity.Property(e => e.PaymentTransactionId)
                    .HasColumnName("payment_transaction_id")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.PaymentType)
                    .HasColumnName("payment_type")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblPayment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tbl_payme__user___7B5B524B");
            });

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("PK__tbl_stat__81A47417EAB7133C");

                entity.ToTable("tbl_state");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.StateName)
                    .HasColumnName("state_name")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__tbl_user__B9BE370FBB7A2101");

                entity.ToTable("tbl_user");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserCityId).HasColumnName("user_city_id");

                entity.Property(e => e.UserDob)
                    .HasColumnName("user_DOB")
                    .HasColumnType("date");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("user_email")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.UserFname)
                    .HasColumnName("user_fname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserGender)
                    .HasColumnName("user_gender")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserLname)
                    .HasColumnName("user_lname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserMobile)
                    .HasColumnName("user_mobile")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UserPassword)
                    .HasColumnName("user_password")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserCity)
                    .WithMany(p => p.TblUser)
                    .HasForeignKey(d => d.UserCityId)
                    .HasConstraintName("FK__tbl_user__user_c__4F7CD00D");
            });

            modelBuilder.Entity<TblUserPackage>(entity =>
            {
                entity.HasKey(e => e.UserPackageId)
                    .HasName("PK__tbl_user__A42C85340136DB54");

                entity.ToTable("tbl_userPackage");

                entity.Property(e => e.UserPackageId).HasColumnName("userPackage _id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsDelete).HasColumnName("isDelete");

                entity.Property(e => e.PackageDateFrom)
                    .HasColumnName("Package_dateFrom")
                    .HasColumnType("date");

                entity.Property(e => e.PackageDateTo)
                    .HasColumnName("Package_dateTo")
                    .HasColumnType("date");

                entity.Property(e => e.PackageId).HasColumnName("package_id");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("updateDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.TblUserPackage)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK__tbl_userP__packa__74AE54BC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserPackage)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__tbl_userP__user___73BA3083");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
