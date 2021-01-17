
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spTeam_GetByTournament
	-- Add the parameters for the stored procedure here
	@TournamentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t.* FROM dbo.Teams t
	INNER JOIN dbo.TournamentEntries e on t.id = e.TeamId
	WHERE e.TournamentId = @TournamentId;
END
GO
