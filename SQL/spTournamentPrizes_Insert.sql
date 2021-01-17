
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spTournamentPrizes_Insert
	-- Add the parameters for the stored procedure here
	@TournamentId int,
	@PrizeId int,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.TournamentPrizes(TournamentId, PrizeId)
	VALUES(@TournamentId, @PrizeId);

	SELECT @id = SCOPE_IDENTITY();
END
GO
