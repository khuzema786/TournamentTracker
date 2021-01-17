
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spTournamentEntries_Insert
	-- Add the parameters for the stored procedure here
	@TournamentId int,
	@TeamId int,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.TournamentEntries(TournamentId, TeamId)
	VALUES(@TournamentId, @TeamId);

	SELECT @id = SCOPE_IDENTITY();
END
GO
