
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spMatchupEntries_Update
	-- Add the parameters for the stored procedure here
	@id int,
	@TeamCompetingId int = null,
	@Score float = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.MatchupEntries
	SET TeamCompetingId = @TeamCompetingId, Score = @Score
	WHERE id = @id;
END
GO
