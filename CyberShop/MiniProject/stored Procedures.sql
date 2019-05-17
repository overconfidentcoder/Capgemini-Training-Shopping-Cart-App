---- Stored Procedures ----

CREATE PROCEDURE SearchProduct
@ModelName varchar(50)
AS
BEGIN
	SELECT * FROM Products_174772 WHERE ModelName like '[%@ModelName%]'
END

l