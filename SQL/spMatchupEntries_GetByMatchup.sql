
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spMatchupEntries_GetByMatchup
	-- Add the parameters for the stored procedure here
	@MatchupId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM MatchupEntries
	WHERE MatchupId = @MatchupId;
END
GO
