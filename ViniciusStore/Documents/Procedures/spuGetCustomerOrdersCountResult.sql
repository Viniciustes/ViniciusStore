


CREATE PROCEDURE spuGetCustomerOrdersCountResult
@Document CHAR(11)
AS

SELECT 
    c.Id, 
    CONCAT(c.FirstName, ' ', c.LastName) AS Name, 
    c.Document, 
    COUNT(Document) AS Orders 
FROM 
    Customer c
INNER JOIN
    [Order] o ON o.CustomerId = c.Id
WHERE 
    Document = @Document
GROUP BY 
    Document, 
    c.Id, 
    FirstName,
    LastName

 