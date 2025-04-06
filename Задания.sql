CREATE TABLE Clients
(
    Id bigint, -- Id �������
    ClientName nvarchar(200) -- ������������ �������
);

CREATE TABLE ClientContacts -- �������� ��������
(
    Id bigint, -- Id ��������
    ClientId bigint, -- Id �������
    ContactType nvarchar(255), -- ��� ��������
    ContactValue nvarchar(255) --  �������� ��������
);

CREATE TABLE Dates 
(
   Id bigint,
   Dt date
);


--1.�������� ������, ������� ���������� ������������ �������� � ���-�� ��������� ��������
SELECT c.ClientName, COUNT(cc.Id) as ClientsCount FROM Clients c INNER JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.ClientName

--2.�������� ������, ������� ���������� ������ ��������, � ������� ���� ����� 2 ���������
SELECT c.ClientName, COUNT(cc.Id) as ClientsCount FROM Clients c INNER JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.ClientName
HAVING COUNT(cc.Id) > 2

--3.�������� ������, ������� ���������� ��������� ��� ���������� Id
WITH rownumDates AS (
    SELECT 
        Id,
        Dt,
        ROW_NUMBER() OVER (PARTITION BY Id ORDER BY Dt) AS RN
    FROM 
        Dates
),
intervals AS (
    SELECT 
        a.Id,
        a.Dt AS Sd,
        b.Dt AS Ed
    FROM 
        rownumDates a
    JOIN 
        rownumDates b ON a.Id = b.Id AND a.RN = b.RN - 1
)

SELECT 
    Id,
    Sd,
    Ed
FROM 
    intervals
