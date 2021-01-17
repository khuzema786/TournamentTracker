SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spTeams_Insert 
	-- Add the parameters for the stored procedure here
	@TeamName nvarchar(100),
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO dbo.Teams (TeamName)
	VALUES(@TeamName);
	
	SELECT @id = SCOPE_IDENTITY();
END
GO
