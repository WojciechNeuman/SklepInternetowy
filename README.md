# SKLEP INTERNETOWY

Aplikacja "Sklep Internetowy" jest platformą e-commerce. Na ten moment umożliwia użytkownikom:
- przeglądanie i edycję listy wszystkich złożonych zamówień,
- przeglądanie i edycję listy zarejestrowanych użytkowników,
- przeglądanie listy zamówień złożonych przez użytkowników,
- zawiera opcję logowania i rejestracji.

Poniżej znajduje się opis struktury danych wykorzystywanych przez aplikację:

## Tabela "Users":

- `user_id` (klucz główny)
- `name`
- `email`
- `address`

## Tabela "Orders":

- `order_id` (klucz główny)
- `customer_id` (klucz obcy powiązany z tabelą "Customers")
- `order_date`
- `total_amount`

## Tabela "Products":

- `product_id` (klucz główny)
- `name`
- `price`
- `description`

## Tabela "OrderItems":

- `order_item_id` (klucz główny)
- `order_id` (klucz obcy powiązany z tabelą "Orders")
- `product_id` (klucz obcy powiązany z tabelą "Products")
- `quantity`
