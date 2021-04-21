CREATE DATABASE [AngularProjectSkillsAssessmentDB ] 

GO

CREATE TABLE [dbo].[Accounts](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[person_code] [int] NOT NULL,
	[account_number] [varchar](50) NOT NULL,
	[outstanding_balance] [money] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[surname] [varchar](50) NULL,
	[id_number] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[code] [int] IDENTITY(1,1) NOT NULL,
	[account_code] [int] NOT NULL,
	[transaction_date] [datetime] NOT NULL,
	[capture_date] [datetime] NOT NULL,
	[amount] [money] NOT NULL,
	[description] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Account_num]    Script Date: 2021/04/22 01:26:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Account_num] ON [dbo].[Accounts]
(
	[account_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Person_id]    Script Date: 2021/04/22 01:26:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Person_id] ON [dbo].[Persons]
(
	[id_number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Account_Person] FOREIGN KEY([person_code])
REFERENCES [dbo].[Persons] ([code])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Account_Person]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Account] FOREIGN KEY([account_code])
REFERENCES [dbo].[Accounts] ([code])
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transaction_Account]
GO
/****** Object:  StoredProcedure [dbo].[pr_AddNewAccount]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_AddNewAccount] @person_code int = NULL,
@account_number varchar(max) = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    INSERT INTO [dbo].[Accounts] ([person_code]
    , [account_number]
    , [outstanding_balance])
      VALUES (@person_code, @account_number, 0.00)
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_AddNewTransaction]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_AddNewTransaction] @account_code int = NULL,
@transaction_date datetime = NULL,
@amount float = NULL,
@description varchar(max) = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN


    INSERT INTO [dbo].[Transactions] ([account_code]
    , [transaction_date]
    , [capture_date]
    , [amount]
    , [description])
      VALUES (@account_code, @transaction_date, GETDATE(), @amount, @description)

    UPDATE [dbo].[Accounts]
    SET [outstanding_balance] = [outstanding_balance] + @amount
    WHERE code = @account_code

  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_AddPerson]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_AddPerson] @name varchar(50),
@surname varchar(50),
@id_number varchar(50)

AS

  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    INSERT INTO [dbo].[Persons] ([name]
    , [surname]
    , [id_number])
      VALUES (@name, @surname, @id_number)
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_DeleteAccount]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[pr_DeleteAccount] @code int = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN
    DELETE FROM [dbo].[Accounts]
    WHERE code = @code
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_DeletePerson]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_DeletePerson] @code int = NULL

AS

  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    DELETE FROM [dbo].[Persons]
    WHERE code = @code
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_DeleteTransactionsByAccountCode]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_DeleteTransactionsByAccountCode]
@account_code INT = NULL
AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

DELETE FROM [dbo].[Transactions]
      WHERE account_code = @account_code
COMMIT


GO
/****** Object:  StoredProcedure [dbo].[pr_GetAccountByCode]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_GetAccountByCode] @code int = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    SELECT
      [code],
      [person_code],
      [account_number],
      [outstanding_balance]
    FROM [Accounts]
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAccountsByPersonCode]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_GetAccountsByPersonCode] @person_code int = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN
    SELECT
      [code],
      [person_code],
      [account_number],
      [outstanding_balance]
    FROM [Accounts]
    WHERE person_code = @person_code
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAllAccoounts]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_GetAllAccoounts]
AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    SELECT
      [code],
      [person_code],
      [account_number],
      [outstanding_balance]
    FROM [Accounts]
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_GetAllPerson]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_GetAllPerson]
AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN
    SELECT
      [code],
      [name],
      [surname],
      [id_number]
    FROM [Persons]
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_GetPersonByCode]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_GetPersonByCode] @code int = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN
    SELECT
      [code],
      [name],
      [surname],
      [id_number]
    FROM [Persons]

    WHERE [code] = @code
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_GetTransactionByCode]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_GetTransactionByCode] @code int = NULL
AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    SELECT
      [code],
      [account_code],
      [transaction_date],
      [capture_date],
      [amount],
      [description]
    FROM [Transactions]
    WHERE code = @code
    ORDER BY [capture_date] DESC
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_GetTransactionsByAccountCode]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_GetTransactionsByAccountCode] @account_code int = NULL
AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN
    SELECT
      [code],
      [account_code],
      [transaction_date],
      [capture_date],
      [amount],
      [description]
    FROM [Transactions]
    WHERE account_code = @account_code
    ORDER BY [capture_date] DESC

  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_SearchPerson]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_SearchPerson] @term varchar(max) = NULL

AS

  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    SELECT
      table1.[code],
      [name],
      [surname],
      [id_number],
      table2.account_number
    FROM [AngularProjectSkillsAssessmentDB ].[dbo].[Persons] table1

    LEFT JOIN accounts table2

      ON table1.code = table2.person_code
    WHERE surname = @term
    OR id_number = @term
    OR table2.account_number = @term

  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_UpdateAccount]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_UpdateAccount] @code int = NULL,
@account_number varchar(max) = NULL
AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    UPDATE [dbo].[Accounts]
    SET [account_number] = @account_number
    WHERE [code] = @code
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_UpdatePerson]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_UpdatePerson] @code int = NULL,
@name varchar(50) = NULL,
@surname varchar(50) = NULL,
@id_number varchar(50) = NULL

AS

  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    UPDATE [dbo].[Persons]
    SET [name] = @name,
        [surname] = @surname,
        [id_number] = @id_number
    WHERE code = @code
  COMMIT
GO
/****** Object:  StoredProcedure [dbo].[pr_UpdateTransaction]    Script Date: 2021/04/22 01:26:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[pr_UpdateTransaction] @code int = NULL,
@account_code int = NULL,
@transaction_date datetime = NULL,
@amount float = NULL,
@description varchar(max) = NULL

AS
  SET NOCOUNT ON
  SET XACT_ABORT ON

  BEGIN TRAN

    UPDATE [dbo].[Accounts]
    SET [outstanding_balance] = [outstanding_balance] - (SELECT TOP (1)
      amount
    FROM Transactions
    WHERE code = @code)
    WHERE code = @account_code

    UPDATE [dbo].[Transactions]
    SET [transaction_date] = @transaction_date,
        [capture_date] = GETDATE(),
        [amount] = @amount,
        [description] = @description
    WHERE code = @code
    IF (@description = 'credit')
    BEGIN
      UPDATE [dbo].[Accounts]
      SET [outstanding_balance] = [outstanding_balance] + @amount
      WHERE code = @account_code
    END
    ELSE
    BEGIN
      UPDATE [dbo].[Accounts]
      SET [outstanding_balance] = [outstanding_balance] - @amount
      WHERE code = @account_code
    END

  COMMIT
GO
USE [master]
GO
ALTER DATABASE [AngularProjectSkillsAssessmentDB ] SET  READ_WRITE 
GO
