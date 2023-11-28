from sympy import symbols, diff, sympify
from typing import Callable, Tuple


class Equation:
    @staticmethod
    def equation_input():
        equation_str = input()
        return sympify(equation_str)

    @staticmethod
    def newton_method(f: Callable, df: Callable, initial_guess: float, e: float) -> Tuple[float | int]:
        x = initial_guess
        new_x = x - f(x) / df(x)
        iteration = 0
        while abs(new_x - x) > e:
            x = new_x
            new_x = new_x - f(new_x) / df(new_x)
            iteration += 1

        return new_x, iteration
    
    @staticmethod
    def simple_newton_method(f: Callable, df: Callable, initial_guess: float, e: float) -> Tuple[float | int]:
        x = initial_guess
        df0 = df(x)
        new_x = x - f(x) / df0
        iteration = 0
        while abs(new_x - x) > e:
            x = new_x
            new_x = new_x - f(new_x) / df0
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
    
    # for guess in initial_guesses:
    #     print(Equation.simple_newton_method(f, df, guess, e))

if __name__ == "__main__":
    main()
