using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UrbanStyleApi.Models
{
    public partial class urbanstyleContext : IdentityDbContext
    {
        public urbanstyleContext()
        {
        }

        public urbanstyleContext(DbContextOptions<urbanstyleContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingItem> BookingItems { get; set; }
        public virtual DbSet<BookingTime> BookingTimes { get; set; }
        public virtual DbSet<BookingUser> BookingUsers { get; set; }
        public virtual DbSet<BusinessService> BusinessServices { get; set; }
        public virtual DbSet<BusinessServiceLocation> BusinessServiceLocations { get; set; }
        public virtual DbSet<BusinessServiceUser> BusinessServiceUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CompanySetting> CompanySettings { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CouponUser> CouponUsers { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<DealItem> DealItems { get; set; }
        public virtual DbSet<EmployeeGroup> EmployeeGroups { get; set; }
        public virtual DbSet<EmployeeGroupService> EmployeeGroupServices { get; set; }
        public virtual DbSet<FrontThemeSetting> FrontThemeSettings { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LtmTranslation> LtmTranslations { get; set; }
        public virtual DbSet<Medium> Media { get; set; }
        public virtual DbSet<Migration> Migrations { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PasswordReset> PasswordResets { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentGatewayCredential> PaymentGatewayCredentials { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionRole> PermissionRoles { get; set; }
        public virtual DbSet<PermissionUser> PermissionUsers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        public virtual DbSet<SmsSetting> SmsSettings { get; set; }
        public virtual DbSet<SmtpSetting> SmtpSettings { get; set; }
        public virtual DbSet<TaxSetting> TaxSettings { get; set; }
        public virtual DbSet<ThemeSetting> ThemeSettings { get; set; }
        public virtual DbSet<TodoItem> TodoItems { get; set; }
        public virtual DbSet<UniversalSearch> UniversalSearches { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=UrbanStyleConnect");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__bookings__3213E83E972A60F9")
                    .IsClustered(false);

                entity.ToTable("bookings");

                entity.HasIndex(e => e.CouponId, "bookings_coupon_id_foreign");

                entity.HasIndex(e => e.DealId, "bookings_deal_id_foreign");

                entity.HasIndex(e => e.UserId, "bookings_user_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdditionalNotes).HasColumnName("additional_notes");

                entity.Property(e => e.AmountToPay).HasColumnName("amount_to_pay");

                entity.Property(e => e.CouponDiscount).HasColumnName("coupon_discount");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DateTime).HasColumnName("date_time");

                entity.Property(e => e.DealId).HasColumnName("deal_id");

                entity.Property(e => e.DealQuantity).HasColumnName("deal_quantity");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.DiscountPercent).HasColumnName("discount_percent");

                entity.Property(e => e.OriginalAmount).HasColumnName("original_amount");

                entity.Property(e => e.PaymentGateway)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("payment_gateway");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(27)
                    .HasColumnName("payment_status")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("source")
                    .HasDefaultValueSql("('pos')");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(33)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.TaxAmount).HasColumnName("tax_amount");

                entity.Property(e => e.TaxName)
                    .HasMaxLength(191)
                    .HasColumnName("tax_name");

                entity.Property(e => e.TaxPercent).HasColumnName("tax_percent");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CouponId);

                entity.HasOne(d => d.Deal)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.DealId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BookingItem>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PRIMARY")
                    .IsClustered(false);

                entity.ToTable("booking_items");

                entity.HasIndex(e => e.BookingId, "booking_items_booking_id_foreign");

                entity.HasIndex(e => e.BusinessServiceId, "booking_items_business_service_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.BusinessServiceId).HasColumnName("business_service_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingItems)
                    .HasForeignKey(d => d.BookingId);

                entity.HasOne(d => d.BusinessService)
                    .WithMany(p => p.BookingItems)
                    .HasForeignKey(d => d.BusinessServiceId);
            });

            modelBuilder.Entity<BookingTime>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__booking___3213E83EC60CAACC")
                    .IsClustered(false);

                entity.ToTable("booking_times");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Day)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("day");

                entity.Property(e => e.EndTime).HasColumnName("end_time");

                entity.Property(e => e.MaxBooking).HasColumnName("max_booking");

                entity.Property(e => e.MultipleBooking)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("multiple_booking")
                    .HasDefaultValueSql("('yes')");

                entity.Property(e => e.SlotDuration)
                    .HasColumnName("slot_duration")
                    .HasDefaultValueSql("((30))");

                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('enabled')");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<BookingUser>(entity =>
            {
                entity.HasKey(e => new { e.BookingId, e.UserId })
                    .HasName("PK__booking___B67846C0B8DAC131")
                    .IsClustered(false);

                entity.ToTable("booking_user");

                entity.HasIndex(e => e.UserId, "booking_user_user_id_foreign");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingUsers)
                    .HasForeignKey(d => d.BookingId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookingUsers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<BusinessService>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__business__3213E83EEEC8C9E0")
                    .IsClustered(false);

                entity.ToTable("business_services");

                entity.HasIndex(e => e.CategoryId, "business_services_category_id_foreign");

                entity.HasIndex(e => e.LocationId, "business_services_location_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DefaultImage)
                    .HasMaxLength(191)
                    .HasColumnName("default_image");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.DiscountType)
                    .IsRequired()
                    .HasMaxLength(21)
                    .HasColumnName("discount_type");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Slug)
                    .HasMaxLength(191)
                    .HasColumnName("slug");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('active')");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.TimeType)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("time_type");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BusinessServices)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.BusinessServices)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<BusinessServiceLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("business_service_location");

                entity.Property(e => e.BusinessServiceId).HasColumnName("business_service_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");
            });

            modelBuilder.Entity<BusinessServiceUser>(entity =>
            {
                entity.HasKey(e => new { e.BusinessServiceId, e.UserId })
                    .HasName("PK__business__E3AB3AA1C8928BF2")
                    .IsClustered(false);

                entity.ToTable("business_service_user");

                entity.HasIndex(e => e.UserId, "business_service_user_user_id_foreign");

                entity.Property(e => e.BusinessServiceId).HasColumnName("business_service_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.BusinessService)
                    .WithMany(p => p.BusinessServiceUsers)
                    .HasForeignKey(d => d.BusinessServiceId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BusinessServiceUsers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__categori__3213E83E4A614A43")
                    .IsClustered(false);

                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Image)
                    .HasMaxLength(191)
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.Slug)
                    .HasMaxLength(191)
                    .HasColumnName("slug");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('active')");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<CompanySetting>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__company___3213E83E16E9A7A8")
                    .IsClustered(false);

                entity.ToTable("company_settings");

                entity.HasIndex(e => e.CurrencyId, "company_settings_currency_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.BookingPerDay)
                    .HasMaxLength(191)
                    .HasColumnName("booking_per_day");

                entity.Property(e => e.BookingTimeType)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("booking_time_type");

                entity.Property(e => e.CompanyEmail)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("company_email");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("company_name");

                entity.Property(e => e.CompanyPhone)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("company_phone");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.DateFormat)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("date_format")
                    .HasDefaultValueSql("('Y-m-d')");

                entity.Property(e => e.DisableSlot)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("disable_slot")
                    .HasDefaultValueSql("('disabled')");

                entity.Property(e => e.EmployeeSelection)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("employee_selection")
                    .HasDefaultValueSql("('disabled')");

                entity.Property(e => e.Latitude)
                    .HasColumnType("numeric(10, 8)")
                    .HasColumnName("latitude");

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("locale");

                entity.Property(e => e.Logo)
                    .HasMaxLength(191)
                    .HasColumnName("logo");

                entity.Property(e => e.Longitude)
                    .HasColumnType("numeric(11, 8)")
                    .HasColumnName("longitude");

                entity.Property(e => e.MultiTaskUser)
                    .HasMaxLength(191)
                    .HasColumnName("multi_task_user");

                entity.Property(e => e.PurchaseCode)
                    .HasMaxLength(100)
                    .HasColumnName("purchase_code");

                entity.Property(e => e.SupportedUntil).HasColumnName("supported_until");

                entity.Property(e => e.TimeFormat)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("time_format")
                    .HasDefaultValueSql("('h:i A')");

                entity.Property(e => e.Timezone)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("timezone");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Website)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("website");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.CompanySettings)
                    .HasForeignKey(d => d.CurrencyId);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__coupons__3213E83E9F754F11")
                    .IsClustered(false);

                entity.ToTable("coupons");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Days).HasColumnName("days");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EndDateTime).HasColumnName("end_date_time");

                entity.Property(e => e.MinimumPurchaseAmount).HasColumnName("minimum_purchase_amount");

                entity.Property(e => e.Percent).HasColumnName("percent");

                entity.Property(e => e.StartDateTime).HasColumnName("start_date_time");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('active')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UsedTime).HasColumnName("used_time");

                entity.Property(e => e.UsesLimit).HasColumnName("uses_limit");
            });

            modelBuilder.Entity<CouponUser>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__coupon_u__3213E83E7DD35A0F")
                    .IsClustered(false);

                entity.ToTable("coupon_users");

                entity.HasIndex(e => e.CouponId, "coupon_users_coupon_id_foreign");

                entity.HasIndex(e => e.UserId, "coupon_users_user_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CouponId).HasColumnName("coupon_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.CouponUsers)
                    .HasForeignKey(d => d.CouponId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CouponUsers)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__currenci__3213E83EF3375CFC")
                    .IsClustered(false);

                entity.ToTable("currencies");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CurrencyCode)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("currency_code");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("currency_name");

                entity.Property(e => e.CurrencySymbol)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("currency_symbol");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__deals__3213E83E3F0B6360")
                    .IsClustered(false);

                entity.ToTable("deals");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CloseTime).HasColumnName("close_time");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Days).HasColumnName("days");

                entity.Property(e => e.DealAmount).HasColumnName("deal_amount");

                entity.Property(e => e.DealAppliedOn)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("deal_applied_on");

                entity.Property(e => e.DealType)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("deal_type");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DiscountType)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("discount_type");

                entity.Property(e => e.EndDateTime).HasColumnName("end_date_time");

                entity.Property(e => e.Image)
                    .HasMaxLength(191)
                    .HasColumnName("image");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.MaxOrderPerCustomer).HasColumnName("max_order_per_customer");

                entity.Property(e => e.OpenTime).HasColumnName("open_time");

                entity.Property(e => e.OriginalAmount).HasColumnName("original_amount");

                entity.Property(e => e.Percentage).HasColumnName("percentage");

                entity.Property(e => e.Slug)
                    .HasMaxLength(191)
                    .HasColumnName("slug");

                entity.Property(e => e.StartDateTime).HasColumnName("start_date_time");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('active')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UsedTime).HasColumnName("used_time");

                entity.Property(e => e.UsesLimit).HasColumnName("uses_limit");
            });

            modelBuilder.Entity<DealItem>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__deal_ite__3213E83E557E5464")
                    .IsClustered(false);

                entity.ToTable("deal_items");

                entity.HasIndex(e => e.BusinessServiceId, "deal_items_business_service_id_foreign");

                entity.HasIndex(e => e.DealId, "deal_items_deal_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessServiceId).HasColumnName("business_service_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DealId).HasColumnName("deal_id");

                entity.Property(e => e.DiscountAmount).HasColumnName("discount_amount");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalAmount).HasColumnName("total_amount");

                entity.Property(e => e.UnitPrice).HasColumnName("unit_price");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.BusinessService)
                    .WithMany(p => p.DealItems)
                    .HasForeignKey(d => d.BusinessServiceId);

                entity.HasOne(d => d.Deal)
                    .WithMany(p => p.DealItems)
                    .HasForeignKey(d => d.DealId);
            });

            modelBuilder.Entity<EmployeeGroup>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__employee__3213E83EFA5ADC56")
                    .IsClustered(false);

                entity.ToTable("employee_groups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('active')");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<EmployeeGroupService>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__employee__3213E83EB54AD1A2")
                    .IsClustered(false);

                entity.ToTable("employee_group_services");

                entity.HasIndex(e => e.BusinessServiceId, "employee_group_services_business_service_id_foreign");

                entity.HasIndex(e => e.EmployeeGroupsId, "employee_group_services_employee_groups_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BusinessServiceId).HasColumnName("business_service_id");

                entity.Property(e => e.EmployeeGroupsId).HasColumnName("employee_groups_id");

                entity.HasOne(d => d.BusinessService)
                    .WithMany(p => p.EmployeeGroupServices)
                    .HasForeignKey(d => d.BusinessServiceId);

                entity.HasOne(d => d.EmployeeGroups)
                    .WithMany(p => p.EmployeeGroupServices)
                    .HasForeignKey(d => d.EmployeeGroupsId);
            });

            modelBuilder.Entity<FrontThemeSetting>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__front_th__3213E83E3B0D60EC")
                    .IsClustered(false);

                entity.ToTable("front_theme_settings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CustomCss).HasColumnName("custom_css");

                entity.Property(e => e.Logo)
                    .HasMaxLength(191)
                    .HasColumnName("logo");

                entity.Property(e => e.PrimaryColor)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("primary_color");

                entity.Property(e => e.SecondaryColor)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("secondary_color");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__language__3213E83ED26A3D8D")
                    .IsClustered(false);

                entity.ToTable("languages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.LanguageCode)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("language_code");

                entity.Property(e => e.LanguageName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("language_name");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('disabled')");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__location__3213E83E4FD1B606")
                    .IsClustered(false);

                entity.ToTable("locations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<LtmTranslation>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__ltm_tran__3213E83E708A7EC3")
                    .IsClustered(false);

                entity.ToTable("ltm_translations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Group)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("group");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key");

                entity.Property(e => e.Locale)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("locale");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Medium>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__media__3213E83E600ED563")
                    .IsClustered(false);

                entity.ToTable("media");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("file_name");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Migration>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__migratio__3213E83EC5D0A8B3")
                    .IsClustered(false);

                entity.ToTable("migrations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Batch).HasColumnName("batch");

                entity.Property(e => e.Migration1)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("migration");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__modules__3213E83E431C2BF5")
                    .IsClustered(false);

                entity.ToTable("modules");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(191)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__pages__3213E83E76F77390")
                    .IsClustered(false);

                entity.ToTable("pages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnName("content");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("slug");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<PasswordReset>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("password_resets");

                entity.HasIndex(e => e.Email, "password_resets_email_index");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("email");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("token");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__payments__3213E83EB54D4966")
                    .IsClustered(false);

                entity.ToTable("payments");

                entity.HasIndex(e => e.BookingId, "payments_booking_id_foreign");

                entity.HasIndex(e => e.EventId, "payments_event_id_unique")
                    .IsUnique()
                    .HasFilter("([event_id] IS NOT NULL)");

                entity.HasIndex(e => e.TransactionId, "payments_transaction_id_unique")
                    .IsUnique()
                    .HasFilter("([transaction_id] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(191)
                    .HasColumnName("customer_id");

                entity.Property(e => e.EventId)
                    .HasMaxLength(191)
                    .HasColumnName("event_id");

                entity.Property(e => e.Gateway)
                    .HasMaxLength(191)
                    .HasColumnName("gateway");

                entity.Property(e => e.PaidOn).HasColumnName("paid_on");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(27)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(191)
                    .HasColumnName("transaction_id");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId);
            });

            modelBuilder.Entity<PaymentGatewayCredential>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__payment___3213E83E5D9122A0")
                    .IsClustered(false);

                entity.ToTable("payment_gateway_credentials");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.OfflinePayment)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("offline_payment")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.PaypalClientId)
                    .HasMaxLength(191)
                    .HasColumnName("paypal_client_id");

                entity.Property(e => e.PaypalMode)
                    .IsRequired()
                    .HasMaxLength(21)
                    .HasColumnName("paypal_mode")
                    .HasDefaultValueSql("('sandbox')");

                entity.Property(e => e.PaypalSecret)
                    .HasMaxLength(191)
                    .HasColumnName("paypal_secret");

                entity.Property(e => e.PaypalStatus)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("paypal_status")
                    .HasDefaultValueSql("('deactive')");

                entity.Property(e => e.RazorpayKey)
                    .HasMaxLength(191)
                    .HasColumnName("razorpay_key");

                entity.Property(e => e.RazorpaySecret)
                    .HasMaxLength(191)
                    .HasColumnName("razorpay_secret");

                entity.Property(e => e.RazorpayStatus)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("razorpay_status")
                    .HasDefaultValueSql("('deactive')");

                entity.Property(e => e.ShowPaymentOptions)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("show_payment_options")
                    .HasDefaultValueSql("('show')");

                entity.Property(e => e.StripeClientId)
                    .HasMaxLength(191)
                    .HasColumnName("stripe_client_id");

                entity.Property(e => e.StripeSecret)
                    .HasMaxLength(191)
                    .HasColumnName("stripe_secret");

                entity.Property(e => e.StripeStatus)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("stripe_status")
                    .HasDefaultValueSql("('deactive')");

                entity.Property(e => e.StripeWebhookSecret)
                    .HasMaxLength(191)
                    .HasColumnName("stripe_webhook_secret");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__permissi__3213E83E61B30204")
                    .IsClustered(false);

                entity.ToTable("permissions");

                entity.HasIndex(e => e.Name, "permissions_name_unique")
                    .IsUnique()
                    .HasFilter("([name] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(191)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.ModuleId).HasColumnName("module_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<PermissionRole>(entity =>
            {
                entity.HasKey(e => new { e.PermissionId, e.RoleId })
                    .HasName("PK__permissi__32538CA726ADF750")
                    .IsClustered(false);

                entity.ToTable("permission_role");

                entity.HasIndex(e => e.RoleId, "permission_role_role_id_foreign");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.PermissionId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionRoles)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<PermissionUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId, e.UserType })
                    .HasName("PK__permissi__8CF2DCD5F6F7951D")
                    .IsClustered(false);

                entity.ToTable("permission_user");

                entity.HasIndex(e => e.PermissionId, "permission_user_permission_id_foreign");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.UserType)
                    .HasMaxLength(191)
                    .HasColumnName("user_type");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionUsers)
                    .HasForeignKey(d => d.PermissionId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__roles__3213E83E6EF2660A")
                    .IsClustered(false);

                entity.ToTable("roles");

                entity.HasIndex(e => e.Name, "roles_name_unique")
                    .IsUnique()
                    .HasFilter("([name] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description)
                    .HasMaxLength(191)
                    .HasColumnName("description");

                entity.Property(e => e.DisplayName)
                    .HasMaxLength(191)
                    .HasColumnName("display_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId, e.UserType })
                    .HasName("PK__role_use__E5C17B26B17CB5DE")
                    .IsClustered(false);

                entity.ToTable("role_user");

                entity.HasIndex(e => e.RoleId, "role_user_role_id_foreign");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserType)
                    .HasMaxLength(191)
                    .HasColumnName("user_type");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<SmsSetting>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__sms_sett__3213E83E87B6829B")
                    .IsClustered(false);

                entity.ToTable("sms_settings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.NexmoFrom)
                    .HasMaxLength(191)
                    .HasColumnName("nexmo_from")
                    .HasDefaultValueSql("('NEXMO')");

                entity.Property(e => e.NexmoKey)
                    .HasMaxLength(191)
                    .HasColumnName("nexmo_key");

                entity.Property(e => e.NexmoSecret)
                    .HasMaxLength(191)
                    .HasColumnName("nexmo_secret");

                entity.Property(e => e.NexmoStatus)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("nexmo_status")
                    .HasDefaultValueSql("('deactive')");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<SmtpSetting>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__smtp_set__3213E83E446D8695")
                    .IsClustered(false);

                entity.ToTable("smtp_settings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.MailDriver)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("mail_driver");

                entity.Property(e => e.MailEncryption)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("mail_encryption");

                entity.Property(e => e.MailFromEmail)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("mail_from_email");

                entity.Property(e => e.MailFromName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("mail_from_name");

                entity.Property(e => e.MailHost)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("mail_host");

                entity.Property(e => e.MailPassword)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("mail_password");

                entity.Property(e => e.MailPort)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("mail_port");

                entity.Property(e => e.MailUsername)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("mail_username");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.Verified).HasColumnName("verified");
            });

            modelBuilder.Entity<TaxSetting>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__tax_sett__3213E83E88380238")
                    .IsClustered(false);

                entity.ToTable("tax_settings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Percent).HasColumnName("percent");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('active')");

                entity.Property(e => e.TaxName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("tax_name");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<ThemeSetting>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__theme_se__3213E83E649A95FE")
                    .IsClustered(false);

                entity.ToTable("theme_settings");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.CustomCss).HasColumnName("custom_css");

                entity.Property(e => e.PrimaryColor)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("primary_color");

                entity.Property(e => e.SecondaryColor)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("secondary_color");

                entity.Property(e => e.SidebarBgColor)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("sidebar_bg_color");

                entity.Property(e => e.SidebarTextColor)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("sidebar_text_color");

                entity.Property(e => e.TopbarTextColor)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("topbar_text_color")
                    .HasDefaultValueSql("('#FFFFFF')");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__todo_ite__3213E83EA43012FD")
                    .IsClustered(false);

                entity.ToTable("todo_items");

                entity.HasIndex(e => e.UserId, "todo_items_user_id_foreign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Position).HasColumnName("position");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(27)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('pending')");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TodoItems)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UniversalSearch>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__universa__3213E83EE3EDD18E")
                    .IsClustered(false);

                entity.ToTable("universal_searches");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.RouteName)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("route_name");

                entity.Property(e => e.SearchableId)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("searchable_id");

                entity.Property(e => e.SearchableType)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("searchable_type");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("title");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__users__3213E83ECB402F21")
                    .IsClustered(false);

                entity.ToTable("users");

                entity.HasIndex(e => e.Email, "users_email_unique")
                    .IsUnique()
                    .HasFilter("([email] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CallingCode)
                    .HasMaxLength(191)
                    .HasColumnName("calling_code");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.Image)
                    .HasMaxLength(191)
                    .HasColumnName("image");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(191)
                    .HasColumnName("mobile");

                entity.Property(e => e.MobileVerified).HasColumnName("mobile_verified");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(191)
                    .HasColumnName("password");

                entity.Property(e => e.RememberToken)
                    .HasMaxLength(100)
                    .HasColumnName("remember_token");

                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at");
            });
            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
