USE [MvcCoreStartKit]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 1/22/2019 10:39:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 1/22/2019 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 1/22/2019 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 1/22/2019 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 1/22/2019 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 1/22/2019 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 1/22/2019 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[Tenant_Id] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 1/22/2019 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tenants]    Script Date: 1/22/2019 10:39:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tenants](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tenants] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190114083638_InitWithIzendaUser', N'2.2.1-servicing-10028')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190114091454_AddTenantTable', N'2.2.1-servicing-10028')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190115021421_PluralTenant', N'2.2.1-servicing-10028')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'7EA0B2FF-5A45-4E70-8F80-887E100127C1', N'Manager', N'MANAGER', N'922d0658-a5d9-4625-9a8b-71ff58e6fb83')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'732E6E70-84B9-4531-A75A-E729E0F9D941', N'Employee', N'EMPLOYEE', N'922d0658-a5d9-4625-9a8b-71ff58e6fb83')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'91FF0C14-7E34-4C71-974B-F2362F1BFEF6', N'VP', N'VP', N'922d0658-a5d9-4625-9a8b-71ff58e6fb83')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'A255F9B0-F2CB-4E5B-8D2A-05CECE4889A2', N'Administrator', N'ADMINISTRATOR', N'922d0658-a5d9-4625-9a8b-71ff58e6fb83')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'446f596a-b7ac-4d2e-9814-b96249e10796', N'7EA0B2FF-5A45-4E70-8F80-887E100127C1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'49529006-1142-40be-bacb-55793909d7dd', N'7EA0B2FF-5A45-4E70-8F80-887E100127C1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4d83f471-24c2-4f7c-8f84-f5ac195cb65a', N'732E6E70-84B9-4531-A75A-E729E0F9D941')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5de4e37e-ef25-4979-8cbe-303ea3eb2554', N'732E6E70-84B9-4531-A75A-E729E0F9D941')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'95087a84-a231-430b-a339-e72054888bb1', N'A255F9B0-F2CB-4E5B-8D2A-05CECE4889A2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a6155e91-f367-422a-9c4e-af19fe50e3ba', N'732E6E70-84B9-4531-A75A-E729E0F9D941')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bada6fa4-2a35-4868-b6b0-7567b659f719', N'7EA0B2FF-5A45-4E70-8F80-887E100127C1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd36d16e8-1246-481b-b8e0-fa1a0205f150', N'91FF0C14-7E34-4C71-974B-F2362F1BFEF6')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e704cd24-271f-4edc-80de-e88e0af3b5f3', N'91FF0C14-7E34-4C71-974B-F2362F1BFEF6')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eae7c07f-3a3d-494e-ae0f-ceb7e513dcad', N'7EA0B2FF-5A45-4E70-8F80-887E100127C1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f6c80567-6fdc-4145-a527-a4b5a9b1aad7', N'91FF0C14-7E34-4C71-974B-F2362F1BFEF6')
GO

INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'446f596a-b7ac-4d2e-9814-b96249e10796', N'manager@natwr.com', N'MANAGER@NATWR.COM', N'manager@natwr.com', N'MANAGER@NATWR.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'c7cb2b5c-9eeb-455a-a54a-93ddc4e306f3', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 3)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'49529006-1142-40be-bacb-55793909d7dd', N'manager@deldg.com', N'MANAGER@DELDG.COM', N'manager@deldg.com', N'MANAGER@DELDG.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'68702f74-bd3c-4d10-b8b4-a04490af978e', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 2)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'4d83f471-24c2-4f7c-8f84-f5ac195cb65a', N'employee@retcl.com', N'EMPLOYEE@RETCL.COM', N'employee@retcl.com', N'EMPLOYEE@RETCL.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'f8dcd354-0826-4f82-89e1-63ef0457b699', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 4)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'5de4e37e-ef25-4979-8cbe-303ea3eb2554', N'employee@deldg.com', N'EMPLOYEE@DELDG.COM', N'employee@deldg.com', N'EMPLOYEE@DELDG.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'561cf2a3-4e17-480c-9c12-512347d40871', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 2)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'693c15e5-918b-494c-8197-e4c10f4af46d', N'johndoe@izenda.com', N'JOHNDOE@IZENDA.COM', N'johndoe@izenda.com', N'JOHNDOE@IZENDA.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'659b633a-a151-401d-9e0f-f3efa873f5f8', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'93622e07-51e6-4a38-86d8-07e05142c28e', N'testdeldg@system.com', N'TESTDELDG@SYSTEM.COM', N'testdeldg@system.com', N'TESTDELDG@SYSTEM.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'33b5aca3-ef60-409e-98cc-96229935c7b3', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 4)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'93b5dc2d-3ed6-4a8a-93ca-ea7136418fc2', N'joedoe1@system.com', N'JOEDOE1@SYSTEM.COM', N'joedoe1@system.com', N'JOEDOE1@SYSTEM.COM', 0, N'ABBmugdCq2v//yc4a41thYzRe546tI2oMydHyaHiJ6F89r57bwtJ3Jr9ruVySeSx7w==', N'a9d23677-900b-4f5d-b4c3-83d7e9642bda', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'95087a84-a231-430b-a339-e72054888bb1', N'IzendaAdmin@system.com', N'IZENDAADMIN@SYSTEM.COM', N'IzendaAdmin@system.com', N'IZENDAADMIN@SYSTEM.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'fce856a8-bb02-474f-a371-fc8db7e82d5e', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 1)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'a6155e91-f367-422a-9c4e-af19fe50e3ba', N'employee@natwr.com', N'EMPLOYEE@NATWR.COM', N'employee@natwr.com', N'EMPLOYEE@NATWR.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'1047ba84-ab9f-40ad-ac75-9e866ed01283', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 3)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'b723d397-2317-4b3c-822c-592e0045cc7b', N'myemail@systm.com', N'MYEMAIL@SYSTM.COM', N'myemail@systm.com', N'MYEMAIL@SYSTM.COM', 0, N'ALBFBvLF6SYGzUxKv1HCDtcrTF9/3Q7MT7W7ZZPwluDp/XjLs/lWJ+eGE+DEDzy45Q==', N'60ea33da-5932-4f8e-8e5e-a4dda3bb990c', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 3)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'bada6fa4-2a35-4868-b6b0-7567b659f719', N'natwr@natwr.com', N'NATWR@NATWR.COM', N'natwr@natwr.com', N'NATWR@NATWR.COM', 0, N'AMctGcxJll3muS6d1ch65470x0Qp7LPQa3chVo3gO760jwT7lsUZgE45uYr1xcW5tg==', N'5a0bc273-efc3-4ac1-be09-2a72437d2915', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 3)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'd36d16e8-1246-481b-b8e0-fa1a0205f150', N'vp@deldg.com', N'VP@DELDG.COM', N'vp@deldg.com', N'VP@DELDG.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'ac216a19-668d-4e3e-9d82-73d1b9bd29ca', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 2)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'e704cd24-271f-4edc-80de-e88e0af3b5f3', N'vp@retcl.com', N'VP@RETCL.COM', N'vp@retcl.com', N'VP@RETCL.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'4b27ca91-549e-4024-9b22-44f17baa33b1', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 4)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'eae7c07f-3a3d-494e-ae0f-ceb7e513dcad', N'manager@retcl.com', N'MANAGER@RETCL.COM', N'manager@retcl.com', N'MANAGER@RETCL.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'6743e1df-7571-4ca4-9004-540f3c27f280', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 4)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'f6c80567-6fdc-4145-a527-a4b5a9b1aad7', N'VP@natwr.com', N'VP@NATWR.COM', N'VP@natwr.com', N'VP@NATWR.COM', 0, N'ADFoIj+1YECZ3N2jLRiz6urUkZObKIl2aFJDbK4ARdf8T3q2WhFpexNzbgT0o3l9fQ==', N'bcdbcbd6-74c3-4e2d-9fed-b5ae3c0d32d4', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 3)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Tenant_Id]) VALUES (N'fb1dbcc2-7780-47c9-98c1-d88faa62dfab', N'joedoe@system.com', N'JOEDOE@SYSTEM.COM', N'joedoe@system.com', N'JOEDOE@SYSTEM.COM', 0, N'AKbNLAQXJ5tBuXzUH4E/zsnPh7+HKzkzZQEwEHsqcxGeYZCezrCyGTQUGq3qAfmyfA==', N'b737c00f-9984-4b39-8a09-b72919811d41', N'93ff3b7c-7d0d-4ef1-a6a6-1c8b7b183e61', NULL, 0, 0, NULL, 1, 0, 1)

GO
SET IDENTITY_INSERT [dbo].[Tenants] ON 
GO
INSERT [dbo].[Tenants] ([Id], [Name]) VALUES (1, N'System')
INSERT [dbo].[Tenants] ([Id], [Name]) VALUES (2, N'DELDG')
INSERT [dbo].[Tenants] ([Id], [Name]) VALUES (3, N'NATWR')
INSERT [dbo].[Tenants] ([Id], [Name]) VALUES (4, N'RETCL')
GO
SET IDENTITY_INSERT [dbo].[Tenants] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 1/22/2019 10:39:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 1/22/2019 10:39:17 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 1/22/2019 10:39:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 1/22/2019 10:39:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 1/22/2019 10:39:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 1/22/2019 10:39:17 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_AspNetUsers_Tenant_Id]    Script Date: 1/22/2019 10:39:17 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUsers_Tenant_Id] ON [dbo].[AspNetUsers]
(
	[Tenant_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 1/22/2019 10:39:17 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [Tenant_Id]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Tenants_Tenant_Id] FOREIGN KEY([Tenant_Id])
REFERENCES [dbo].[Tenants] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Tenants_Tenant_Id]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO