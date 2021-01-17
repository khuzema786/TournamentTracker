
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE dbo.spTournaments_Insert
	-- Add the parameters for the stored procedure here
	@TournamentName nvarchar(200),
	@EntryFee money,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Tournaments(TournamentName, EntryFee, Active)
	VALUES(@TournamentName, @EntryFee, 1);

	SELECT @id = SCOPE_IDENTITY();
END
GO
