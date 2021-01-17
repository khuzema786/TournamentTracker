
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE dbo.spMatchups_GetByTournament
	-- Add the parameters for the stored procedure here
	@TournamentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT m.*, t.TeamName FROM dbo.Matchups m
	LEFT JOIN dbo.Teams t on m.WinnerId = t.id
	WHERE m.TournamentId = @TournamentId order by MatchupRound;
END
GO
