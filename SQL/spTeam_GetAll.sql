
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spTeam_GetAll

AS
BEGIN	
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Teams;
END
GO
