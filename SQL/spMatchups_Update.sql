
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spMatchups_Update
	-- Add the parameters for the stored procedure here
	@id int,
	@WinnerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE dbo.Matchups
	SET WinnerId = @WinnerId
	WHERE id = @id;
END
GO
