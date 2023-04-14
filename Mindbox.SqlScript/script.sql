-- В базе данных MS SQL Server есть продукты и категории. Одному продукту может
-- соответствовать много категорий, в одной категории может быть много продуктов.
-- Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у
-- продукта нет категорий, то его имя все равно должно выводиться.

SELECT p.Name AS Product, c.Name AS Category
FROM Product p
         LEFT JOIN ProductCategory pc ON pc.ProductId = p.Id
         LEFT JOIN Category c ON c.Id = pc.CategoryId;

-- Может быть я что-то не так понял, но задание показалось лёгким. Чуть усложним:
-- у каждого продукта только одна строка, а категории перечислены через запятую

SELECT p.Name AS ProductName, STRING_AGG(c.Name, ', ') AS Categories
FROM Product p
         LEFT JOIN ProductCategory pc ON pc.ProductId = p.Id
         LEFT JOIN Category c ON c.Id = pc.CategoryId
GROUP BY p.Id, p.Name
