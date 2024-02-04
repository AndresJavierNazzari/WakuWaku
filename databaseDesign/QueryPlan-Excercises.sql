SELECT TOP 10 p.Id, p.Name, p.Description, COUNT(OI.OrderId) as NumberOfOrders 
FROM products p 
JOIN OrderItems OI on p.Id =OI.ProductId 
GROUP BY p.Id, p.Name, p.Description 
ORDER By NumberOfOrders DESC 

SELECT TOP 10 P.Id AS ProductId, P.Name AS ProductName, P.Description AS ProductDescription,
    (SELECT COUNT(OrderId) FROM OrderItems WHERE ProductId = P.Id) AS NumberOfOrders
FROM Products P
ORDER BY NumberOfOrders DESC;
