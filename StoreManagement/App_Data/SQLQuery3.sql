USE CompanyMag
GO

INSERT [dbo].[Stores] 
(Id,CompanyId,Name,Address,City,Zip,Country,Longitude,Latitude)
VALUES(NEWID(),'7a70b121-98c6-458d-b483-1ff0f63339f6','Telia 1','Storgatan 3','Ljungby','34143','Sweden','',''),
(NEWID(),'7a70b121-98c6-458d-b483-1ff0f63339f6','Telia 2','Storgatan 4','Ljungby','34143','Sweden','',''),
(NEWID(),'f6a2daa8-d850-4e6c-9242-ce3d1f71539e','Telenor 1','Storgatan 5','Ljungby','34143','Sweden','',''),
(NEWID(),'f6a2daa8-d850-4e6c-9242-ce3d1f71539e','Telenor 2','Storgatan 6','Ljungby','34143','Sweden','','');
