SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spTeamMembers_GetByTeam
	-- Add the parameters for the stored procedure here
	@TeamId int
AS
BEGIN	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT p.* FROM dbo.TeamMembers m 
	INNER JOIN dbo.People p on m.PersonId = p.id
	WHERE m.TeamId = @TeamId;
END
GO
