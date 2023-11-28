from typing import Tuple, Callable


class Equation:
    @staticmethod
    def input_equation() -> Callable:
        """ Ввод уравнения в общем виде """

        # Степень уравнения
        n = int(input())
        # Коэффициенты уравнения
        coefficients = [float(eval(x)) for x in input().split()]

        # Создание строки, представляющей уравнение
        equation = "0"
        for i in range(n + 1):
            equation += f" + {coefficients[i]} * x**{n-i}"

        # Анонимная функция, представляющая введенное уравнение
        return lambda x: eval(equation)


    @staticmethod
    def bisection_method(func: Callable, a: float, b: float, epsilon: float) -> Tuple[int, float] | Tuple[None, None]:
        """
        Метод бисекции для нахождения корня уравнения.

        func: Уравнение, для которого ищется корень\n
        a: Левый конец интервала\n
        b: Правый конец интервала\n
        epsilon: Точность решения\n
        return: Корень уравнения и количество итераций, необходимых для приближенного решения Или None, None, если метод не применим
        """

        # Проверка знаков на концах интервала
        if func(a) * func(b) > 0:
            print("Метод бисекции не применим. Начальные значения функции на концах интервала одного знака.")
            return None, None
        
        iteration = 0

        while (b - a) > 2 * epsilon:
            iteration += 1
            mid_point = (a + b) / 2
            
            # Если значение функции в середине интервала равно 0, возвращаем найденное значение
            if func(mid_point) == 0:
                return mid_point, iteration
            
            # Иначе сдвигаем левую или правую границы
            elif func(mid_point) * func(a) < 0:
                b = mid_point
            else:
                a = mid_point

        # Найденный корень
        root = (a + b) / 2

        return root, iteration


def main():
    func = Equation.input_equation()
    a, b = list(map(float, input().split()))
    e = float(input())

    root, iteration = Equation.bisection_method(func, a, b, e)
    print(f"Корень: {root}, Итерация: {iteration}")
    

if __name__ == "__main__":
    main()