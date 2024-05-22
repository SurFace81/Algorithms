import random
import matplotlib.pyplot as plt

def rotate(A,B,C):
    return (B[0]-A[0])*(C[1]-B[1])-(B[1]-A[1])*(C[0]-B[0])

def grahamscan(A: list):
    n = len(A)
    P = list(range(n))
    
    for i in range(1,n):
        if A[P[i]][0] < A[P[0]][0]:
            P[i], P[0] = P[0], P[i]
            
    for i in range(2,n):
        j = i
        while j > 1 and (rotate(A[P[0]], A[P[j-1]], A[P[j]]) < 0): 
            P[j], P[j - 1] = P[j - 1], P[j]
            j -= 1
            
    S = [P[0],P[1]]
    for i in range(2,n):
        while rotate(A[S[-2]], A[S[-1]], A[P[i]]) < 0:
            del S[-1]
        S.append(P[i])
        
    return S

pnts = []
for i in range(10):
    pnts.append([random.randint(-10, 10), random.randint(-10, 10)])
res = grahamscan(pnts)

x, y = [], []
x1, y1 = [], []

for i in range(len(pnts)):
    x.append(pnts[i][0])
    y.append(pnts[i][1])

for i in res:    
    x1.append(pnts[i][0])
    y1.append(pnts[i][1])

x1.append(pnts[res[0]][0])
y1.append(pnts[res[0]][1])
    
plt.plot(x, y, '.')
plt.plot(x1, y1, '.-')
plt.show()