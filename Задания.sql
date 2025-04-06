CREATE TABLE Clients
(
    Id bigint, -- Id клиента
    ClientName nvarchar(200) -- Наименование клиента
);

CREATE TABLE ClientContacts -- контакты клиентов
(
    Id bigint, -- Id контакта
    ClientId bigint, -- Id клиента
    ContactType nvarchar(255), -- тип контакта
    ContactValue nvarchar(255) --  значение контакта
);

CREATE TABLE Dates 
(
   Id bigint,
   Dt date
);


--1.Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов
SELECT c.ClientName, COUNT(cc.Id) as ClientsCount FROM Clients c INNER JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.ClientName

--2.Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов
SELECT c.ClientName, COUNT(cc.Id) as ClientsCount FROM Clients c INNER JOIN ClientContacts cc ON c.Id = cc.ClientId
GROUP BY c.ClientName
HAVING COUNT(cc.Id) > 2

--3.Написать запрос, который возвращает интервалы для одинаковых Id
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
