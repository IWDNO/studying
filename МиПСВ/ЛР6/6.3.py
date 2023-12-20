import numpy as np
import matplotlib.pyplot as plt
from sympy import symbols, sympify
import os


def inter(x, y, n, t):
    f = [[0] * n for _ in range(n)]

    for i in range(n):
        f[i][0] = y[i]
    
    for k in range(1, n):
        for i in range(n-k):
            f[i][k] = (f[i+1][k-1] - f[i][k-1]) / (x[i+k] - x[i])
    
    result = y[0]

    for k in range(1, n):
        term = f[0][k]
        for i in range(k):
            term *= (t - x[i])
        result += term
    
    return result


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
    x_range = np.linspace(a, b, 100)
    y_range = [f(x) for x in x_range]
    plt.plot(x_range, y_range, label="f(x)")

    # Построение интерполяции
    x_range_simp = np.linspace(a, b, degree+1)
    y_range_simp = [f(x) for x in x_range_simp]
    y_range1 = [inter(x_range_simp, y_range_simp, degree+1, x) for x in x_range]
    plt.plot(x_range, y_range1, label="Интерполяция")
    plt.scatter(x_range_simp, y_range_simp, color='red')

    plt.xlabel('x')
    plt.ylabel('y')
    plt.legend()

    if not os.path.isdir("./data"):
        os.mkdir("./data")
    plt.savefig("./data/newton.png")


if __name__ == "__main__":
    main()
