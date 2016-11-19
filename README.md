
# Ivanov

# Project Title

Решение задач по спецкурсу "Построение и анализ алгоритмов программирования" Иванова на ФФ МГУ 2015/2016 года.

## Getting Started

Проект содержит несколько задач каждая из которых реализованна в отдельном проекте на языке C#:

```
Задача 1.
 - Вычисление дистанции Левинштейна. 
    - Реализация для случайно генерируемого массива символов.
    - Реализация для реального текста.

Задача 2.
 - Сравнение алгоритмов Select Sort и Bubble Sort.
    - Количество операций присваивания и сравнения от длины массива
    - Количество операций присваивания и сравнения от меры упорядоченности массива

Задача 3.
 - Сравнение алгоритмов Quick Sort и Merge Sort.
    - Количество операций присваивания и сравнения от длины массива
    - Количество операций присваивания и сравнения от меры упорядоченности массива

Задача 4.
 - Построение кривой Серпинского (приложение Windows Forms)
  - Рекурсивный вариант
  - Нерекурсивный вариант основанный на идее использования стэка, хранящего все параметры конкретной кривой A, B, C или D и вызове их в обратном порядке.
  - Сравнение графиков времени работы двух алгоритмов.

Задача 5.
 - Обход доски шахматным конем.
  - Обход доски реализован с использованием правила Варнсдорфа: 
  Перед каждым ходом коня вычисляется рейтинг ближайших доступных полей - полей, 
  на которых конь еще не был, и на которые он может перейти за один ход. Рейтинг
  поля определяется числом ближайших доступных с него полей. Чем меньше рейтинг,
  тем он лучше. Потом делается ход на поле с наименьшим рейтингом (на любое из 
  таковых, если их несколько), и так далее, пока есть куда ходить. 
  Работает для досок размера от 5x5 до 76x76.
  - Реализована визуализация обхода доски конем.
  - Реализован метод позволяющий строить график зависимости времени выполнения программы от размера доски.


```
### Prerequisities

- Visual Studio 2015
- Python 2.7 (numpy, matplotlib)


