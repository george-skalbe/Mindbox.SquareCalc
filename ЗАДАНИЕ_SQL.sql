--В базе данных MS SQL Server есть статьи и тэги. Одной статье может соответствовать много тэгов, а тэгу — много статей. Напишите SQL запрос для выбора всех пар «Тема статьи – тэг». Если у статьи нет тэгов, то её тема всё равно должна выводиться.


SELECT a.Name, t.Name
FROM article a
LEFT JOIN article_tags at ON at.article_id = a.id
INNER JOIN tags t ON at.tag_id = t.id 