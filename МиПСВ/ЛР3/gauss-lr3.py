def gauss(matrix):
    n = len(matrix)
    for i in range(n-1):

        #
        # Поиск максимального элемента в столбце
        #

        max_row = i
        for k in range(i + 1, n):
            if abs(matrix[k][i]) > abs(matrix[max_row][i]):
                max_row = k
                
        #
        # Обмен строки с максимальным элементом со строкой i
        #
        
        matrix[i], matrix[max_row] = matrix[max_row], matrix[i]

        #
        # Приведение матрицы к верхнетреугольному виду
        #
        
        for k in range(i + 1, n):
            factor = matrix[k][i] / matrix[i][i]
            for j in range(i, n + 1):
                matrix[k][j] -= factor * matrix[i][j]
        
    #
    # Обратный ход метода Гаусса
    #

    x = [0] * n
    for i in range(n - 1, -1, -1):
        x[i] = matrix[i][n] / matrix[i][i]
        for k in range(i - 1, -1, -1):
            matrix[k][n] -= matrix[k][i] * x[i]

    return x


if __name__ == "__main__":
    n = int(input("Введите размерность системы уравнений: "))
    matrix = []
    print("Введите матрицу коэффициентов и столбец свободных членов:")
    for i in range(n):
        row = list(map(float, input().split()))
        matrix.append(row)

    solution = gauss(matrix)

    print("Решение системы уравнений:")
    for i in range(n):
        print(f"x{i + 1} = {solution[i]}")
