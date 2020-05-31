/****** Object:  Table [dbo].[LabTestInfo]    Script Date: 5/23/2020 11:29:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabTestInfo](
	[UserId] [nvarchar](50) NOT NULL,
	[DateOfEntry] [datetime] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[TestType] [nvarchar](30) NULL,
	[TestDate] [datetime] NULL,
	[TestResult] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestStatus]    Script Date: 5/23/2020 11:29:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestStatus](
	[UserId] [nvarchar](50) NOT NULL,
	[DateOfEntry] [datetime] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[ReturnRequestStatus] [nvarchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SymptomsInfo]    Script Date: 5/23/2020 11:29:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SymptomsInfo](
	[UserId] [nvarchar](50) NOT NULL,
	[DateOfEntry] [datetime] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UserIsExposed] [bit] NOT NULL,
	[ExposureDate] [datetime] NULL,
	[IsSymptomatic] [bit] NOT NULL,
	[SymptomFever] [bit] NULL,
	[SymptomCough] [bit] NULL,
	[SymptomShortnessOfBreath] [bit] NULL,
	[SymptomChills] [bit] NULL,
	[SymptomMusclePain] [bit] NULL,
	[SymptomSoreThroat] [bit] NULL,
	[SymptomLossOfSmellTaste] [bit] NULL,
	[SymptomVomiting] [bit] NULL,
	[SymptomDiarrhea] [bit] NULL,
	[Temperature] [decimal](5, 2) NULL,
	[UserIsSymptomatic] [bit] NULL,
	[ClearToWorkToday] [bit] NOT NULL,
	[GUID] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 5/23/2020 11:29:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInfo](
	[UserId] [nvarchar](50) NOT NULL,
	[UserGUID] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Role] [nvarchar](50) NULL,
	[YearOfBirth] [int] NOT NULL,
	[MobileNumber] [nvarchar](15) NULL,
	[EmailAddress] [nvarchar](100) NOT NULL,
	[StreetAddress1] [nvarchar](50) NULL,
	[StreetAddress2] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[ZipCode] [nvarchar](30) NULL,
	[TeamsAddress] [nvarchar](1500) NULL,
	[TwilioAddress] [nvarchar](1500) NULL,
	[RequestBTWEmail] [nvarchar](100) NULL,
	[RequestBTWMobile] [nvarchar](15) NULL,
 ) ON [PRIMARY]
GO
