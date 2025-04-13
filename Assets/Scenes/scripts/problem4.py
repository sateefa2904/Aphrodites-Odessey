import numpy as np
import matplotlib.pyplot as plt

# Define the matrix A
A = np.array([[1, -2],
              [-4, 1]])

# Calculate eigenvalues and eigenvectors
eigenvalues, eigenvectors = np.linalg.eig(A)

# Plot standard basis vectors
plt.quiver(0, 0, 1, 0, angles='xy', scale_units='xy', scale=1, color='r', label='Standard Basis Vector [1, 0]')
plt.quiver(0, 0, 0, 1, angles='xy', scale_units='xy', scale=1, color='b', label='Standard Basis Vector [0, 1]')

# Plot vectors defined by columns of A
plt.quiver(0, 0, A[0,0], A[1,0], angles='xy', scale_units='xy', scale=1, color='g', label='Column Vector [1, -4]')
plt.quiver(0, 0, A[0,1], A[1,1], angles='xy', scale_units='xy', scale=1, color='m', label='Column Vector [-2, 1]')

# Plot calculated eigenvectors
for i in range(len(eigenvalues)):
    plt.quiver(0, 0, eigenvectors[0, i], eigenvectors[1, i], angles='xy', scale_units='xy', scale=1, color='y', label=f'Eigenvector {i+1}')

# Set plot properties
plt.xlim(-5, 5)
plt.ylim(-5, 5)
plt.xlabel('x')
plt.ylabel('y')
plt.axhline(0, color='k',linewidth=0.5)
plt.axvline(0, color='k',linewidth=0.5)
plt.grid(color = 'gray', linestyle = '--', linewidth = 0.5)
plt.legend()
plt.title('Plot of Standard Basis Vectors, Vectors from A, and Eigenvectors')
plt.gca().set_aspect('equal', adjustable='box')
plt.savefig('plot.png')
plt.show()