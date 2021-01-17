SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spTeamMembers_Insert 
	-- Add the parameters for the stored procedure here
	@TeamId int,
	@PersonId int,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO dbo.TeamMembers(TeamId, PersonId)
	VALUES(@TeamId, @PersonId);
	
	SELECT @id = SCOPE_IDENTITY();
END
GO
