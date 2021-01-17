
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spMatchups_Insert
	-- Add the parameters for the stored procedure here
	@TournamentId int,
	@MatchupRound int,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Matchups (TournamentId, MatchupRound)
	VALUES (@TournamentId, @MatchupRound);

    SELECT @id = SCOPE_IDENTITY();
END
GO
