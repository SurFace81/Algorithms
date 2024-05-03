import numpy as np
import matplotlib.pyplot as plt

def plot_np(x, y, dft, restored, time1, time2):
    plt.figure(figsize=(12, 6))

    plt.subplot(3, 1, 1)
    plt.plot(x, y)
    plt.title('Signal')
    plt.grid(True)

    plt.subplot(3, 1, 2)
    plt.plot(np.abs(dft))
    plt.title(f'np DFT, {round(time1, 2)} ms')
    plt.grid(True)

    plt.subplot(3, 1, 3)
    plt.plot(x, restored.real)
    plt.title(f'np IDFT, {round(time2, 2)} ms')
    plt.grid(True)

    plt.tight_layout()
    plt.show()
    
def plot_my(x, y, dft, restored, time1, time2):
    plt.figure(figsize=(12, 6))

    plt.subplot(3, 1, 1)
    plt.plot(x, y)
    plt.title('Signal')
    plt.grid(True)

    plt.subplot(3, 1, 2)
    plt.plot(np.abs(dft))
    plt.title(f'my DFT, {round(time1, 2)} ms')
    plt.grid(True)

    plt.subplot(3, 1, 3)
    plt.plot(x, restored.real)
    plt.title(f'my IDFT, {round(time2, 2)} ms')
    plt.grid(True)

    plt.tight_layout()
    plt.show()