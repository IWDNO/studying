from typing import Tuple, Callable


class Equation:
    @staticmethod
    def input_equation() -> Callable:
        n = int(input())
        coefficients = [float(eval(x)) for x in input().split()]
        equation = "0"
        for i in range(n + 1):
            equation += f" + {coefficients[i]} * x**{n-i}"
        
        return lambda x: eval(equation)

    @staticmethod
    def bisection_method(func: Callable, a: float, b: float, epsilon: float) -> Tuple[int, float] | Tuple[None, None]:
        if func(a) * func(b) > 0:
            print("Метод бисекции не применим. Начальные значения функции на концах интервала одного знака.")
            return None, None

        iteration = 0
        while (b - a) > 2 * epsilon:
            mid_point = (a + b) / 2
            if func(mid_point) == 0:
                print(f"Найден корень: {mid_point}")
                return mid_point
            elif func(mid_point) * func(a) < 0:
                b = mid_point
            else:
                a = mid_point
            iteration += 1

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