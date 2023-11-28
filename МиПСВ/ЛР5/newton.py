from sympy import symbols, diff, sympify
from typing import Callable, Tuple


class Equation:
    @staticmethod
    def equation_input():
        """ Ввод уравнения пользователем """
        equation_str = input()
        return sympify(equation_str)

    @staticmethod
    def newton_method(f: Callable, df: Callable, initial_guess: float, e: float) -> Tuple[float | int]:
        """
        Метод Ньютона для нахождения корня уравнения.

        f: Функция уравнения\n
        df: Производная функции уравнения\n
        initial_guess: Начальное приближение\n
        e: Точность решения\n
        return: Корень уравнения и количество итераций, необходимых для приближенного решения
        """
        x = initial_guess
        new_x = x - f(x) / df(x)
        iteration = 1
        while abs(new_x - x) > e:
            x = new_x
            new_x = new_x - f(new_x) / df(new_x)
            iteration += 1

        return new_x, iteration
    
    @staticmethod
    def simple_newton_method(f: Callable, df: Callable, initial_guess: float, e: float) -> Tuple[float | int]:
        """
        Упрощенный метод Ньютона для нахождения корня уравнения.

        f: Функция уравнения\n
        df: Производная функции уравнения (первоначальная)\n
        initial_guess: Начальное приближение\n
        e: Точность решения\n
        return: Корень уравнения и количество итераций, необходимых для приближенного решения
        """
        x = initial_guess

        # Значение производной, найденное в начальной точке
        df0 = df(x)
        
        new_x = x - f(x) / df0
        iteration = 1
        while abs(new_x - x) > e:
            x = new_x
            new_x = new_x - f(new_x) / df0
            iteration += 1

        return new_x, iteration
    
    @staticmethod
    def secant_method(f: Callable, initial_guess: float, e: float) -> Tuple[float | int]:
        """
        Метод секущих для нахождения корня уравнения.

        f: Функция уравнения\n
        initial_guess: Начальное приближение\n
        e: Точность решения\n
        return: Корень уравнения и количество итераций, необходимых для приближенного решения
        """
        x = initial_guess
        # Первое приближение
        new_x = x - (f(x) * e) / (f(x + e) - f(x))
        iteration = 1
        # Все последующие
        while abs(new_x - x) > e:
            tmp_x = new_x
            new_x = new_x - (f(new_x)*(x - new_x)) / (f(x) - f(new_x))
            x = tmp_x
            iteration += 1
        
        return new_x, iteration
    

def main():
    x = symbols('x')
    equation = Equation.equation_input()
    derivative = diff(equation, x)
    initial_guesses = list(map(float, input().split()))
    e = float(input())

    # Создаем функции из уравнения и его производной
    f = lambda x_val: equation.subs(x, x_val)
    df = lambda x_val: derivative.subs(x, x_val)

    for guess in initial_guesses:
        print(Equation.newton_method(f, df, guess, e))
        # print(Equation.simple_newton_method(f, df, guess, e))
        # print(Equation.secant_method(f, guess, e))
    

if __name__ == "__main__":
    main()
