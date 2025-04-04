# TasksLibrary

TasksLibrary - это библиотека классов на C# для работы с математическими операциями над числами.

## 📋 Описание

Библиотека предоставляет набор статических методов для:
- Поиска делителей чисел
- Работы с простыми числами
- Вычисления НОД и НОК
- Факторизации чисел

## ✨ Возможности

### Класс Divisors
- `FindDivisors(int n)` - находит все делители числа
- `CountDivisors(int n)` - подсчитывает количество делителей
- `FindNumbersWith5Divisors(int m, int n)` - ищет числа с ровно 5 делителями в диапазоне

### Класс PrimeNumbers
- `IsPrime(int n)` - проверяет простое ли число
- `GeneratePrimesByDefinition(int count)` - генерирует простые числа по определению
- `GeneratePrimesBySieve(int count)` - генерирует простые числа решетом Эратосфена

### Класс NumberTheory
- `GCD(int a, int b)` - вычисляет наибольший общий делитель
- `LCM(int a, int b)` - вычисляет наименьшее общее кратное

### Класс Factorization
- `Factorize(int n)` - раскладывает число на простые множители
- `FactorizationToString()` - форматирует разложение в строку

## 🚀 Использование

1. Добавьте ссылку на библиотеку в проект
2. Используйте нужные методы:

```csharp
using TasksLibrary;

// Примеры:
var divisors = Divisors.FindDivisors(12); // [1, 2, 3, 4, 6, 12]
var isPrime = PrimeNumbers.IsPrime(17); // true
var gcd = NumberTheory.GCD(36, 48); // 12
