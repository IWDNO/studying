from bisection import Equation


class Solution(Equation):
    @staticmethod
    def scan_method(func, a, b, epsilon, max_iterations=5):
        # Начальное значение шага
        step = (b - a) / 2.0

        for iteration in range(max_iterations):
            # Разделение интервала с текущим шагом
            intervals = [(a + i * step, a + (i + 1) * step) for i in range(int((b - a) / step))]

            # Поиск отрезка, где функция меняет знак или не превосходит epsilon
            for interval in intervals:
                if func(interval[0]) * func(interval[1]) <= 0 or abs(func(interval[0])) <= epsilon:
                    # Найден отрезок, на котором функция меняет знак или не превосходит epsilon
                    # Можно взять любую точку этого отрезка в качестве решения
                    solution = (interval[0] + interval[1]) / 2.0

                    # Уточнение решения с более мелким шагом
                    for refinement_step in range(iteration + 1):
                        step /= 2.0
                        if func(interval[0]) * func(solution) <= 0:
                            interval = (interval[0], solution)
                        else:
                            interval = (solution, interval[1])
                        solution = (interval[0] + interval[1]) / 2.0

                    return solution



def main():
    # print("размерность \nкоэффициенты \na b \ne")
    func = Solution.input_equation()
    a, b = list(map(float, input().split()))
    e = float(input())

    solution = Solution.scan_method(func, a, b, e)
    print(solution)
    

if __name__ == "__main__":
    main()