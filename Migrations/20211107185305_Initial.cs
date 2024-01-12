using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UrbanStyleApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "booking_times",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    start_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    end_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    multiple_booking = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, defaultValueSql: "('yes')"),
                    max_booking = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('enabled')"),
                    slot_duration = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((30))"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__booking___3213E83EC60CAACC", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "business_service_location",
                columns: table => new
                {
                    business_service_id = table.Column<int>(type: "int", nullable: false),
                    location_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    image = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('active')"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__3213E83E4A614A43", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    start_date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    uses_limit = table.Column<int>(type: "int", nullable: true),
                    used_time = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<double>(type: "float", nullable: true),
                    percent = table.Column<int>(type: "int", nullable: true),
                    minimum_purchase_amount = table.Column<int>(type: "int", nullable: false),
                    days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('active')"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__coupons__3213E83E9F754F11", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currency_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    currency_symbol = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    currency_code = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__currenci__3213E83EF3375CFC", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "deals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: false),
                    deal_type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    start_date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    end_date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    open_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    close_time = table.Column<TimeSpan>(type: "time", nullable: true),
                    uses_limit = table.Column<int>(type: "int", nullable: true),
                    used_time = table.Column<int>(type: "int", nullable: true),
                    original_amount = table.Column<double>(type: "float", nullable: true),
                    deal_amount = table.Column<double>(type: "float", nullable: true),
                    days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('active')"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    discount_type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    percentage = table.Column<int>(type: "int", nullable: true),
                    deal_applied_on = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    max_order_per_customer = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__deals__3213E83E3F0B6360", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "employee_groups",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('active')"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employee__3213E83EFA5ADC56", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "front_theme_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primary_color = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    secondary_color = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    custom_css = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__front_th__3213E83E3B0D60EC", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    language_code = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    language_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('disabled')"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__language__3213E83ED26A3D8D", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__location__3213E83E4FD1B606", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "ltm_translations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<int>(type: "int", nullable: false),
                    locale = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    group = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ltm_tran__3213E83E708A7EC3", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    file_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__media__3213E83E600ED563", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "migrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    migration = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    batch = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__migratio__3213E83EC5D0A8B3", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "modules",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    description = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__modules__3213E83E431C2BF5", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__pages__3213E83E76F77390", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "password_resets",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    token = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "payment_gateway_credentials",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    paypal_client_id = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    paypal_secret = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    stripe_client_id = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    stripe_secret = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    stripe_webhook_secret = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    stripe_status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('deactive')"),
                    paypal_status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('deactive')"),
                    paypal_mode = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false, defaultValueSql: "('sandbox')"),
                    offline_payment = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, defaultValueSql: "('1')"),
                    show_payment_options = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false, defaultValueSql: "('show')"),
                    razorpay_key = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    razorpay_secret = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    razorpay_status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('deactive')"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__payment___3213E83E5D9122A0", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    module_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    description = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permissi__3213E83E61B30204", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    display_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    description = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__roles__3213E83E6EF2660A", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "sms_settings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nexmo_status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('deactive')"),
                    nexmo_key = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    nexmo_secret = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    nexmo_from = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true, defaultValueSql: "('NEXMO')"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sms_sett__3213E83E87B6829B", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "smtp_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mail_driver = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    mail_host = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    mail_port = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    mail_username = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    mail_password = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    mail_from_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    mail_from_email = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    mail_encryption = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    verified = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__smtp_set__3213E83E446D8695", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "tax_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tax_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    percent = table.Column<double>(type: "float", nullable: false),
                    status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('active')"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tax_sett__3213E83E88380238", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "theme_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primary_color = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    secondary_color = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    sidebar_bg_color = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    sidebar_text_color = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    topbar_text_color = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false, defaultValueSql: "('#FFFFFF')"),
                    custom_css = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__theme_se__3213E83E649A95FE", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "universal_searches",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    searchable_id = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    searchable_type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    route_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__universa__3213E83EE3EDD18E", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    group_id = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    calling_code = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    mobile = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    mobile_verified = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    image = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    remember_token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users__3213E83ECB402F21", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "company_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    company_email = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    company_phone = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    logo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date_format = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false, defaultValueSql: "('Y-m-d')"),
                    time_format = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false, defaultValueSql: "('h:i A')"),
                    website = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    timezone = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    locale = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    latitude = table.Column<decimal>(type: "numeric(10,8)", nullable: false),
                    longitude = table.Column<decimal>(type: "numeric(11,8)", nullable: false),
                    currency_id = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    purchase_code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    supported_until = table.Column<DateTime>(type: "datetime2", nullable: true),
                    multi_task_user = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    booking_per_day = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    employee_selection = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('disabled')"),
                    disable_slot = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('disabled')"),
                    booking_time_type = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__company___3213E83E16E9A7A8", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_company_settings_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "business_services",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    time = table.Column<double>(type: "float", nullable: false),
                    time_type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    discount = table.Column<double>(type: "float", nullable: false),
                    discount_type = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    location_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    default_image = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    status = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false, defaultValueSql: "('active')"),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__business__3213E83EEEC8C9E0", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_business_services_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_business_services_locations_location_id",
                        column: x => x.location_id,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission_user",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permissi__8CF2DCD5F6F7951D", x => new { x.user_id, x.permission_id, x.user_type })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_permission_user_permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission_role",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permissi__32538CA726ADF750", x => new { x.permission_id, x.role_id })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_permission_role_permissions_permission_id",
                        column: x => x.permission_id,
                        principalTable: "permissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_permission_role_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_user",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    user_type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__role_use__E5C17B26B17CB5DE", x => new { x.user_id, x.role_id, x.user_type })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_role_user_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deal_id = table.Column<int>(type: "int", nullable: true),
                    deal_quantity = table.Column<double>(type: "float", nullable: true),
                    coupon_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    date_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(33)", maxLength: 33, nullable: false, defaultValueSql: "('pending')"),
                    payment_gateway = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    original_amount = table.Column<double>(type: "float", nullable: false),
                    discount = table.Column<double>(type: "float", nullable: false),
                    coupon_discount = table.Column<double>(type: "float", nullable: true),
                    discount_percent = table.Column<double>(type: "float", nullable: false),
                    tax_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    tax_percent = table.Column<double>(type: "float", nullable: true),
                    tax_amount = table.Column<double>(type: "float", nullable: true),
                    amount_to_pay = table.Column<double>(type: "float", nullable: false),
                    payment_status = table.Column<string>(type: "nvarchar(27)", maxLength: 27, nullable: false, defaultValueSql: "('pending')"),
                    source = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false, defaultValueSql: "('pos')"),
                    additional_notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__bookings__3213E83E972A60F9", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_bookings_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bookings_deals_deal_id",
                        column: x => x.deal_id,
                        principalTable: "deals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bookings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "coupon_users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    coupon_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__coupon_u__3213E83E7DD35A0F", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_coupon_users_coupons_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "coupons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_coupon_users_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "todo_items",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "nvarchar(27)", maxLength: 27, nullable: false, defaultValueSql: "('pending')"),
                    position = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__todo_ite__3213E83EA43012FD", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_todo_items_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "business_service_user",
                columns: table => new
                {
                    business_service_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__business__E3AB3AA1C8928BF2", x => new { x.business_service_id, x.user_id })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_business_service_user_business_services_business_service_id",
                        column: x => x.business_service_id,
                        principalTable: "business_services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_business_service_user_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deal_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deal_id = table.Column<int>(type: "int", nullable: true),
                    business_service_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<double>(type: "float", nullable: false),
                    discount_amount = table.Column<double>(type: "float", nullable: false),
                    total_amount = table.Column<double>(type: "float", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__deal_ite__3213E83E557E5464", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_deal_items_business_services_business_service_id",
                        column: x => x.business_service_id,
                        principalTable: "business_services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_deal_items_deals_deal_id",
                        column: x => x.deal_id,
                        principalTable: "deals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "employee_group_services",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_groups_id = table.Column<int>(type: "int", nullable: true),
                    business_service_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__employee__3213E83EB54AD1A2", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_employee_group_services_business_services_business_service_id",
                        column: x => x.business_service_id,
                        principalTable: "business_services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employee_group_services_employee_groups_employee_groups_id",
                        column: x => x.employee_groups_id,
                        principalTable: "employee_groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "booking_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    business_service_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<double>(type: "float", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_booking_items_bookings_booking_id",
                        column: x => x.booking_id,
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_items_business_services_business_service_id",
                        column: x => x.business_service_id,
                        principalTable: "business_services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "booking_user",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__booking___B67846C0B8DAC131", x => new { x.booking_id, x.user_id })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_booking_user_bookings_booking_id",
                        column: x => x.booking_id,
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_booking_user_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currency_id = table.Column<int>(type: "int", nullable: true),
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    gateway = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    transaction_id = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    status = table.Column<string>(type: "nvarchar(27)", maxLength: 27, nullable: false, defaultValueSql: "('pending')"),
                    paid_on = table.Column<DateTime>(type: "datetime2", nullable: true),
                    customer_id = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    event_id = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__payments__3213E83EB54D4966", x => x.id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_payments_bookings_booking_id",
                        column: x => x.booking_id,
                        principalTable: "bookings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "booking_items_booking_id_foreign",
                table: "booking_items",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "booking_items_business_service_id_foreign",
                table: "booking_items",
                column: "business_service_id");

            migrationBuilder.CreateIndex(
                name: "booking_user_user_id_foreign",
                table: "booking_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "bookings_coupon_id_foreign",
                table: "bookings",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "bookings_deal_id_foreign",
                table: "bookings",
                column: "deal_id");

            migrationBuilder.CreateIndex(
                name: "bookings_user_id_foreign",
                table: "bookings",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "business_service_user_user_id_foreign",
                table: "business_service_user",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "business_services_category_id_foreign",
                table: "business_services",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "business_services_location_id_foreign",
                table: "business_services",
                column: "location_id");

            migrationBuilder.CreateIndex(
                name: "company_settings_currency_id_foreign",
                table: "company_settings",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "coupon_users_coupon_id_foreign",
                table: "coupon_users",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "coupon_users_user_id_foreign",
                table: "coupon_users",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "deal_items_business_service_id_foreign",
                table: "deal_items",
                column: "business_service_id");

            migrationBuilder.CreateIndex(
                name: "deal_items_deal_id_foreign",
                table: "deal_items",
                column: "deal_id");

            migrationBuilder.CreateIndex(
                name: "employee_group_services_business_service_id_foreign",
                table: "employee_group_services",
                column: "business_service_id");

            migrationBuilder.CreateIndex(
                name: "employee_group_services_employee_groups_id_foreign",
                table: "employee_group_services",
                column: "employee_groups_id");

            migrationBuilder.CreateIndex(
                name: "password_resets_email_index",
                table: "password_resets",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "payments_booking_id_foreign",
                table: "payments",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "payments_event_id_unique",
                table: "payments",
                column: "event_id",
                unique: true,
                filter: "([event_id] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "payments_transaction_id_unique",
                table: "payments",
                column: "transaction_id",
                unique: true,
                filter: "([transaction_id] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "permission_role_role_id_foreign",
                table: "permission_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "permission_user_permission_id_foreign",
                table: "permission_user",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "permissions_name_unique",
                table: "permissions",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "role_user_role_id_foreign",
                table: "role_user",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "roles_name_unique",
                table: "roles",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "todo_items_user_id_foreign",
                table: "todo_items",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "users_email_unique",
                table: "users",
                column: "email",
                unique: true,
                filter: "([email] IS NOT NULL)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "booking_items");

            migrationBuilder.DropTable(
                name: "booking_times");

            migrationBuilder.DropTable(
                name: "booking_user");

            migrationBuilder.DropTable(
                name: "business_service_location");

            migrationBuilder.DropTable(
                name: "business_service_user");

            migrationBuilder.DropTable(
                name: "company_settings");

            migrationBuilder.DropTable(
                name: "coupon_users");

            migrationBuilder.DropTable(
                name: "deal_items");

            migrationBuilder.DropTable(
                name: "employee_group_services");

            migrationBuilder.DropTable(
                name: "front_theme_settings");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "ltm_translations");

            migrationBuilder.DropTable(
                name: "media");

            migrationBuilder.DropTable(
                name: "migrations");

            migrationBuilder.DropTable(
                name: "modules");

            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropTable(
                name: "password_resets");

            migrationBuilder.DropTable(
                name: "payment_gateway_credentials");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "permission_role");

            migrationBuilder.DropTable(
                name: "permission_user");

            migrationBuilder.DropTable(
                name: "role_user");

            migrationBuilder.DropTable(
                name: "sms_settings");

            migrationBuilder.DropTable(
                name: "smtp_settings");

            migrationBuilder.DropTable(
                name: "tax_settings");

            migrationBuilder.DropTable(
                name: "theme_settings");

            migrationBuilder.DropTable(
                name: "todo_items");

            migrationBuilder.DropTable(
                name: "universal_searches");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "business_services");

            migrationBuilder.DropTable(
                name: "employee_groups");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "deals");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
