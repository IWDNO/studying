import numpy as np
import matplotlib.pyplot as plt
from sympy import symbols, sympify
import os

def main():
    # Ввод уравнения
    equation_str = input()
    x = symbols('x')
    equation = sympify(equation_str)
    f = lambda x_val: equation.subs(x, x_val)

    # Ввод степени многочлена Лагранжа и интервала
    degree = int(input())
    a, b = list(map(float, input().split()))

    # Построение графика
    x_range = np.linspace(a, b, 1000)
    y_range = [f(x) for x in x_range]
    plt.plot(x_range, y_range, label="f(x)")

    # Построение интерполяции
    x_range_simp = np.linspace(a, b, degree + 1)
    y_range_simp = [f(x) for x in x_range_simp]
    plt.plot(x_range_simp, y_range_simp,  label="Интерполяция")
    plt.scatter(x_range_simp, y_range_simp, color='red')

    plt.xlabel('x')
    plt.ylabel('y')
    plt.legend()

    if not os.path.isdir("./data"):
        os.mkdir("./data")
    plt.savefig("./data/linear.png")


if __name__ == "__main__":
    main()
