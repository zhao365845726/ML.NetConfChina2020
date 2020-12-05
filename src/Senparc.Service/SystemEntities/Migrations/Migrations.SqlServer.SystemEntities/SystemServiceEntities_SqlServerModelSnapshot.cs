﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Senparc.Service;

namespace Senparc.Service.SystemEntities.Migrations.Migrations.SqlServer.SystemEntities
{
    [DbContext(typeof(SystemServiceEntities_SqlServer))]
    partial class SystemServiceEntities_SqlServerModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Senparc.Core.Models.AdminUserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<string>("LastLoginIp")
                        .HasColumnName("LastLoginIP")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ThisLoginIp")
                        .HasColumnName("ThisLoginIP")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime>("ThisLoginTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("AdminUserInfos");
                });

            modelBuilder.Entity("Senparc.Core.Models.FeedBack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("EmailChecked")
                        .HasColumnType("bit");

                    b.Property<bool>("Flag")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("HeadImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastLoginIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLoginTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastWeixinSignInTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("LockMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("Locked")
                        .HasColumnType("bit");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Package")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<bool?>("PhoneChecked")
                        .HasColumnType("bit");

                    b.Property<string>("PicUrl")
                        .HasColumnType("varchar(300)")
                        .HasMaxLength(300)
                        .IsUnicode(false);

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("QQ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RealName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<byte>("Sex")
                        .HasColumnType("tinyint");

                    b.Property<string>("ThisLoginIp")
                        .HasColumnName("ThisLoginIP")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<DateTime>("ThisLoginTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("WeixinOpenId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeixinSignTimes")
                        .HasColumnType("int");

                    b.Property<string>("WeixinUnionId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.AccountPayLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("AddIp")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<DateTime>("CompleteTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("money");

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<decimal>("GetPoints")
                        .HasColumnType("money");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("OrderType")
                        .HasColumnType("int");

                    b.Property<decimal>("PayMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PayParam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PayType")
                        .HasColumnType("int");

                    b.Property<string>("PrepayId")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TradeNumber")
                        .HasColumnType("varchar(150)");

                    b.Property<byte?>("Type")
                        .HasColumnType("tinyint");

                    b.Property<decimal?>("UsedPoints")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountPayLogs");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.SysButton", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ButtonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MenuId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("OpearMark")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(350)")
                        .HasMaxLength(350);

                    b.HasKey("Id");

                    b.ToTable("SysButtons");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.SysMenu", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<int>("MenuType")
                        .HasColumnType("int");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ResourceCode")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(350)")
                        .HasMaxLength(350);

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("SysMenus");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.SysPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMenu")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PermissionId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("ResourceCode")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("RoleCode")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SysPermission");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.SysRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("RoleCode")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SysRoles");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.SysRoleAdminUserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("RoleCode")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SysRoleAdminUserInfos");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.DataBaseModel.XncfModule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("AllowRemove")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("MenuId")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("MenuName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("UpdateLog")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("XncfModules");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.PointsLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int?>("AccountPayLogId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<decimal>("AfterPoints")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("BeforePoints")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Points")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AccountPayLogId");

                    b.ToTable("PointsLogs");
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.SystemConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("AdminRemark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<bool?>("HideModuleManager")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MchId")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("MchKey")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Remark")
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TenPayAppId")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("Senparc.Core.Models.FeedBack", b =>
                {
                    b.HasOne("Senparc.Ncf.Core.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.AccountPayLog", b =>
                {
                    b.HasOne("Senparc.Ncf.Core.Models.Account", "Account")
                        .WithMany("AccountPayLogs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Senparc.Ncf.Core.Models.PointsLog", b =>
                {
                    b.HasOne("Senparc.Ncf.Core.Models.Account", "Account")
                        .WithMany("PointsLogs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Senparc.Ncf.Core.Models.AccountPayLog", "AccountPayLog")
                        .WithMany("PointsLogs")
                        .HasForeignKey("AccountPayLogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
