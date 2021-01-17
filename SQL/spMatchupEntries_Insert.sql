
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spMatchupEntries_Insert
	-- Add the parameters for the stored procedure here
	@MatchupId int,
	@ParentMatchUpId int,
	@TeamCompetingId int,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.MatchupEntries(MatchupId, ParentMatchupId, TeamCompetingId)
	VALUES (@MatchupId, @ParentMatchupId, @TeamCompetingId);

    SELECT @id = SCOPE_IDENTITY();
END
GO
