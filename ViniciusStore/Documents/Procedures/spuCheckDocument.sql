USE ViniciusStore
GO

CREATE PROCEDURE spuCheckDocument
	@Document CHAR(11)
AS
	SELECT CASE WHEN EXISTS (
		SELECT [Id]
		FROM [Customer] NOLOCK
		WHERE [Document] = @Document
	)
	THEN CAST(1 AS BIT)
	ELSE CAST(0 AS BIT) END

GO