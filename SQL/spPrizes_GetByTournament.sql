
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spPrizes_GetByTournament
	-- Add the parameters for the stored procedure here
	@TournamentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT p.* FROM dbo.Prizes p
	INNER JOIN dbo.TournamentPrizes t on p.id = t.PrizeId
	WHERE t.TournamentId = @TournamentId;
END
GO
