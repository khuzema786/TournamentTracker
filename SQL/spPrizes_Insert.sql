SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE dbo.spPeople_Insert
	-- Add the parameters for the stored procedure here
	@LastName int,
	@LastName nvarchar(50),
	@PrizeAmount money,
	@PrizePercentage float,
	-- Return
	@id int = 0 output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO dbo.Prizes (PlaceNumber, PlaceName, PrizeAmount, PrizePercentage) 
	VALUES (@PlaceNumber, @PlaceName, @PrizeAmount, @PrizePercentage);

	-- SCOPE_IDENTITY gives last id created from current transaction SCOPE
	SELECT @id = SCOPE_IDENTITY();
	
END
GO
