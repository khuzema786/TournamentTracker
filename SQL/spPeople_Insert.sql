
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spPeople_Insert
	-- Add the parameters for the stored procedure here
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@EmailAddress nvarchar(100),
	@CellphoneNumber varchar(20),
	-- Return
	@id int = 0 output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.People (FirstName, LastName, EmailAddress, CellphoneNumber) 
	VALUES (@FirstName, @LastName, @EmailAddress, @CellphoneNumber);

	-- SCOPE_IDENTITY gives last id created from current transaction SCOPE
	SELECT @id = SCOPE_IDENTITY();
END
GO

