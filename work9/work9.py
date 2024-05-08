import numpy as np
import matplotlib.pyplot as plt
from utils import plot_np, plot_my
import time

def signal(t):
    return np.sin(2 * np.pi * 3 * t) + np.cos(2 * np.pi * 4 * t)

t_min, t_max = -15, 15
def fft(y):
    N = len(y)
    dft = np.zeros(len(y))
    for k in range(len(dft)):
        for n in range(N):
            dft[k] += (y[n] * np.exp(-2j * np.pi * k * n / N)).real
    return dft

def ifft(y):
    N = len(y)
    idft = np.zeros_like(y)
    for n in range(len(idft)):
        for k in range(N):
            idft[n] += (y[k] * np.exp(2j * np.pi * k * n / N)).real
    return idft / N


x = np.linspace(t_min, t_max, 1024)
y = signal(x)

# numpy
start_time = time.time()
for i in range(1024):
    dft = np.fft.fft(y)
time1 = (time.time() - start_time) * 1000

start_time = time.time()
for i in range(1024):
    restored = np.fft.ifft(dft)
time2 = (time.time() - start_time) * 1000

plot_np(x, y, dft, restored, time1, time2)

# mine
start_time = time.time()
dft = fft(y)
time1 = (time.time() - start_time) * 1000

start_time = time.time()
restored = ifft(dft)
time2 = (time.time() - start_time) * 1000
plot_my(x, y, dft, restored, time1, time2)