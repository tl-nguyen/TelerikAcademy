#include <iostream>
#include <string.h>
#define MAXN 64
using namespace std;
int C;
bool adjMatrix[MAXN][MAXN];
long long cache[MAXN];

long long findSalary(int employee)
{
    if (cache[employee] > 0)
    {
        return cache[employee];
    }
    long long salary = 0;
    for (int i = 0; i < C; i++)
    {
        if (adjMatrix[employee][i])
        {
            salary += findSalary(i);
        }
    }
    if (salary == 0) salary = 1;
    cache[employee] = salary;
    return salary;
}

int main()
{
    // Read matrix
    cin >> C;
    for(int i = 0; i < C; i++)
    {
        string line;
        cin >> line;
        for(int j = 0; j < C; j++)
        {
            adjMatrix[i][j] = (line[j] == 'Y');
        }
    }

    // Sum all salaries
    long long sumOfSalaries = 0;
    for(int i = 0; i < C; i++)
    {
        sumOfSalaries += findSalary(i);
    }
    cout << sumOfSalaries << endl;
    return 0;
}
